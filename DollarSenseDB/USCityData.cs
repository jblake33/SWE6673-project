using DollarSenseDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarSenseDB
{
    public class USCityData : IUSCityData
    {
        private readonly ISQLDataAccess _db;

        public USCityData(ISQLDataAccess db)
        {
            _db = db;
        }
        /// <summary>
        /// Gets the names of the US city in the USCity table of the DB.
        /// </summary>
        /// <returns></returns>
        public Task<List<USCityModel>> GetUSCities()
        {
            string sql = "select city from dbo.USCities";
            return _db.LoadData<USCityModel, dynamic>(sql, new { });
        }
        /// <summary>
        /// Gets the COL data from the USCity table of the DB with a matching US city name.
        /// </summary>
        /// <param name="usCityName"></param>
        /// <returns></returns>
        public Task<List<USCityModel>> GetUSCity(string usCityName)
        {
            string sql = @"select * from dbo.USCities where city = (@usCityName)";
            return _db.LoadData<USCityModel, dynamic>(sql, new { });
        }
    }
}
