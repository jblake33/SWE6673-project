using DollarSenseDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarSenseDB
{
    public class USStateData : IUSStateData
    {
        private readonly ISQLDataAccess _db;

        public USStateData(ISQLDataAccess db)
        {
            _db = db;
        }
        /// <summary>
        /// Gets the names of the US states in the USState  table of the DB.
        /// </summary>
        /// <returns></returns>
        public Task<List<USStateModel>> GetUSStates()
        {
            string sql = "select state from dbo.USStates";
            return _db.LoadData<USStateModel, dynamic>(sql, new { });
        }
        /// <summary>
        /// Gets the COL data from the USState table of the DB with a matching US state name.
        /// </summary>
        /// <param name="usStateName"></param>
        /// <returns></returns>
        public Task<List<USStateModel>> GetUSState(string usStateName)
        {
            string sql = @"select * from dbo.USStates where state = (@usStateName)";
            return _db.LoadData<USStateModel, dynamic>(sql, new { });
        }
    }
}
