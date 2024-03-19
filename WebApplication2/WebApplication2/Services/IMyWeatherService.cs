using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IMyWeatherService
    {
        Task<Root> GetWeatherAsync(string city);
    }
}
