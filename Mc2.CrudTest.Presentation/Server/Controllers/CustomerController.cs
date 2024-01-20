using Domain.Customers;
using Mc2.CrudTest.Data.Tools;
using Mc2.CrudTest.Persistence.Contexts;
using Mc2.CrudTest.Presentation.Shared.Helpers;
//using Mc2.CrudTest.Presentation.Shared.Helpers.libphonenumber.PhoneNumbers;
using Mc2.CrudTest.Presentation.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using PhoneNumbers;

//using PhoneNumber = Mc2.CrudTest.Presentation.Shared.Helpers.libphonenumber.PhoneNumbers.PhoneNumber;

namespace Mc2.CrudTest.Presentation.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    #region Ctor & Fields

    private readonly CacheContext _cacheContext;
    private readonly ContextUpdater _contextUpdater;

    private string _errorMessage = "";

    public CustomerController(CacheContext cacheContext, ContextUpdater contextUpdater)
    {
        _cacheContext = cacheContext;
        _contextUpdater = contextUpdater;
    }

    #endregion

    #region Actions

    [HttpPost]
    public IActionResult Create(CustomerModel model)
    {
        if (!ValidateCustomer(model))
            return StatusCode(406, _errorMessage);

        _contextUpdater.AddCustomer(new Customer(model.FirstName, model.LastName,
            new Domain.Customers.PhoneNumber(model.CountryCode, model.Number), model.Email, model.BankAccountNumber));
        
        return Ok();
    }

    [HttpGet]
    public IActionResult Read(long id)
    {
        var customer = _cacheContext.Customers.GetValueOrDefault(id);
        return Ok(customer);
    }

    #endregion

    private bool ValidateCustomer(CustomerModel model)
    {
        if (!EmailValidator.IsValid(model.Email))
        {
            _errorMessage = "not a valid phone number";
            return false;
        }

        if (!BankAccountValidator.IsValid(model.BankAccountNumber))
        {
            _errorMessage = "not a valid bank account number";
            return false;
        }

        var phoneNumberUtil = PhoneNumberUtil.GetInstance();
        var phoneNumber = phoneNumberUtil.Parse(model.CountryCode + model.Number, null);
        if (!phoneNumberUtil.IsValidNumber(phoneNumber))
        {
            _errorMessage = "not a valid phone number";
            return false;
        }

        if (_cacheContext.GetCustomerByEmail(model.Email) is not null)
        {
            _errorMessage = "a customer with that email already exist";
            return false;
        }

        return true;
    }
}