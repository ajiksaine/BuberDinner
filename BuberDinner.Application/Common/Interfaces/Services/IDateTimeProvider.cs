namespace BuberDinner.Application.Common.Interface.Services
{
    public interface IDatetimeProvider
    {
        DateTime UtcNow { get; }
    }
}