using Application.ViewModels;
using Domain.Customers;
using Mc2.CrudTest.Persistence.Contexts;

namespace Mc2.CrudTest.Data.Tools;

public class ContextUpdater
{
    private readonly CacheContext _cacheContext;
    private readonly ApplicationContext _context;

    public ContextUpdater(CacheContext cacheContext, ApplicationContext context)
    {
        _cacheContext = cacheContext;
        _context = context;
    }

    public void AddCustomer(Customer customer)
    {
        var addedCustomer = _context.Customers.Add(customer).Entity;
        _context.SaveChanges();

        _cacheContext.Customers[addedCustomer.Id] = new CustomerView(
            FirstName: addedCustomer.FirstName,
            LastName: addedCustomer.LastName,
            DateOfBirth: addedCustomer.DateOfBirth,
            Email: addedCustomer.Email,
            PhoneNumber: addedCustomer.PhoneNumber,
            BankAccountNumber: addedCustomer.BankAccountNumber
        );
    }

    public void UpdateCustomer(Customer customer)
    {
        var updatedCustomer = _context.Customers.First(c => c.Id == customer.Id);
        _context.Entry(updatedCustomer).CurrentValues.SetValues(customer);
        _context.SaveChanges();

        _cacheContext.Customers[updatedCustomer.Id] = new CustomerView(
            FirstName: updatedCustomer.FirstName,
            LastName: updatedCustomer.LastName,
            DateOfBirth: updatedCustomer.DateOfBirth,
            Email: updatedCustomer.Email,
            PhoneNumber: updatedCustomer.PhoneNumber,
            BankAccountNumber: updatedCustomer.BankAccountNumber
        );
    }

    public void RemoveCustomer(long id)
    {
        var customer = _context.Customers.First(c => c.Id == id);
        _context.Customers.Remove(customer);
        _context.SaveChanges();

        _cacheContext.Customers.TryRemove(_cacheContext.Customers.First(c => c.Key == id));
    }
}