using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarSenseDB
{
    public  class SQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _config;
        public string ConnectionStringName { get; set; } = "Default";
        public SQLDataAccess(IConfiguration config)
        {
            _config = config;
        }
        // We are only pulling data from the DB, never saving data. The DB's data is just a few tables of cost of living data.
        /// <summary>
        /// Executes a SQL command with the specified parameters (or use "new { }" in place of no parameters).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                //Query the SQL DB using the sql statement and parameters.
                var data = await connection.QueryAsync<T>(sql, parameters);

                return data.ToList();
            }
        }
    }
}
