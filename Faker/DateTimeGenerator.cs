using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    public class DateTimeGenerator : TypedValueGenerator<DateTime>
    {
        protected override DateTime Generate(GeneratorContext context)
        {
            int year = context.Random.Next(DateTime.MinValue.Year, DateTime.MaxValue.Year + 1);
            int month = context.Random.Next(DateTime.MinValue.Month, DateTime.MaxValue.Month + 1);
            int day = context.Random.Next(1, DateTime.DaysInMonth(year,month) + 1);
            int hour = context.Random.Next(DateTime.MinValue.Hour, DateTime.MaxValue.Hour + 1);
            int minute = context.Random.Next(DateTime.MinValue.Minute, DateTime.MaxValue.Minute + 1);
            int second = context.Random.Next(DateTime.MinValue.Second, DateTime.MaxValue.Second + 1);
            int millisecond = context.Random.Next(DateTime.MinValue.Millisecond, DateTime.MaxValue.Millisecond + 1);

            return new DateTime(year, month, day, hour, minute, second, millisecond);
        }
    }
}
