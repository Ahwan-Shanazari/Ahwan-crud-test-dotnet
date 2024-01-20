namespace Mc2.CrudTest.Presentation.Shared.Models;

public class CustomerModel
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string CountryCode { get; set; }
    public string Number { get; set; }
    public string Email { get; private set; }
    public string BankAccountNumber { get; private set; }
}