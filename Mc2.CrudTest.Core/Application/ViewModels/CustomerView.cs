using Domain.Customers;

namespace Application.ViewModels;

public record CustomerView(string FirstName, string LastName, DateTime DateOfBirth, PhoneNumber PhoneNumber,
    string Email, string BankAccountNumber);