using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AccountManagement.Infrastructure.Helpers;

public class DateTimeOffsetToDateTimeUtcConverter : ValueConverter<DateTimeOffset, DateTimeOffset>
{
    public DateTimeOffsetToDateTimeUtcConverter() 
        : base(c => c.ToUniversalTime(), c => c)
    { }
}