using DollarSenseDB.Models;

namespace DollarSenseDB
{
    public interface IUSCityData
    {
        Task<List<USCityModel>> GetUSCities();
        Task<List<USCityModel>> GetUSCity(string usCityName);
    }
}