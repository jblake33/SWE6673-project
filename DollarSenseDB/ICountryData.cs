using DollarSenseDB.Models;

namespace DollarSenseDB
{
    public interface ICountryData
    {
        Task<List<CountryModel>> GetCountries();
        Task<List<CountryModel>> GetCountry(string countryName);
    }
}