using BuberDinner.Application.Common.Interface.Services;

namespace BuberDinner.Infrastructure.Services
{
    public class DatetimeProvider : IDatetimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}