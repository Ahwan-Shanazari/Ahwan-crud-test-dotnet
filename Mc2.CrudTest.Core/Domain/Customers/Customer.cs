namespace Domain.Customers;

public class Customer
{
    public long Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string Email { get; private set; }
    public string BankAccountNumber { get; private set; }

    public Customer(string firstName, string lastName, PhoneNumber phoneNumber, string email, string bankAccountNumber,long? id =null)
    {
        if (id is not null)
            id = id;
        
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }
}