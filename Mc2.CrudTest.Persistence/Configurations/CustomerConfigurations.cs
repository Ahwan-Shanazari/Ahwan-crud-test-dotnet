using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Persistence.Configurations;

public class CustomerConfigurations:IEntityTypeConfiguration<Customer>
{
    private const int PhoneNumberMaxlength = 50;
    private const int CountryCodeMaxlength = 10;
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.OwnsOne(customer => customer.PhoneNumber, numberBuilder =>
        {
            numberBuilder.Property(number => number.Number).HasMaxLength(PhoneNumberMaxlength);
            numberBuilder.Property(number => number.CountryCode).HasMaxLength(CountryCodeMaxlength);
        });
    }
}