using Newtonsoft.Json;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IStormGlassService
    {
        Task<Root> GetStormglassDataAsync(double lat, double lng);
    }
}
