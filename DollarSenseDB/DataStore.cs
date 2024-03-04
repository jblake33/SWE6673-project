using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarSenseDB
{
    public static class DataStore
    {
        // This class would contain three DataTables of the static Cost-of-living data.
        // No tables of data are included as they are not needed for now...
        // Below are the methods used for reading data from the table (data is never written).

        public static bool CheckConnection()
        {
            return true;
        }
        #region Reading a row of data from a table
        /// <summary>
        /// Returns csv values: cindex,grocery,housing,utilities,transportation,health,misc
        /// </summary>
        /// <param name="stateName"></param>
        /// <returns></returns>
        public static string GetUSStateData(string stateName)
        {
            return "";
        }
        /// <summary>
        /// Returns csv values: cindex,rent,groceries,restaurant,pp
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public static string GetUSCityData(string cityName)
        {
            return "";
        }
        /// <summary>
        /// Returns csv values: cindex,rent,groceries,restaurant,pp
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        public static string GetCountryData(string countryName)
        {
            return "";
        }
        #endregion
        #region Reading all names from a table
        public static string GetUSStateNames()
        {
            return "";
        }
        public static string GetUSCityNames()
        {
            return "";
        }
        public static string GetCountryNames() 
        {
            return "";
        }
        #endregion
    }
}
