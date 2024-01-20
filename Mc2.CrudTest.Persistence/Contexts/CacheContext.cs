using System.Collections.Concurrent;
using Application.ViewModels;

namespace Mc2.CrudTest.Persistence.Contexts;

public class CacheContext
{
    public ConcurrentDictionary<int, CustomerView> Customers { get; } = new();
}