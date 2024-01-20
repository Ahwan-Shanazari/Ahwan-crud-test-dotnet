using System.Collections.Concurrent;
using Application.ViewModels;
using Domain.Customers;

namespace Mc2.CrudTest.Persistence.Contexts;

public class CacheContext
{
    public ConcurrentDictionary<long, CustomerView> Customers { get; } = new();

    public CustomerView? GetCustomerByEmail(string email)
    {
        return Customers.FirstOrDefault(customer => customer.Value.Email == email).Value;
    } 
}