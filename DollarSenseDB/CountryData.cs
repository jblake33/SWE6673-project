using DollarSenseDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarSenseDB
{
    public class CountryData : ICountryData
    {
        private readonly ISQLDataAccess _db;

        public CountryData(ISQLDataAccess db)
        {
            _db = db;
        }
        /// <summary>
        /// Gets the names of the countries in the Country table of the DB.
        /// </summary>
        /// <returns></returns>
        public Task<List<CountryModel>> GetCountries()
        {
            string sql = "select country from dbo.Countries";
            return _db.LoadData<CountryModel, dynamic>(sql, new { });
        }
        /// <summary>
        /// Gets the COL data from the Country table of the DB with a matching country name.
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        public Task<List<CountryModel>> GetCountry(string countryName)
        {
            string sql = @"select * from dbo.Countries where country = (@countryName)";
            return _db.LoadData<CountryModel, dynamic>(sql, new { });
        }
    }
}
