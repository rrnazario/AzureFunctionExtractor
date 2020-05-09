using Dapper;
using ExtractInformation.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ExtractInformation.Implementations
{
    public class Extractor : IExtractor
    {
        private readonly ILogger _log;
        public Extractor(ILogger log)
        {
            _log = log;
        }
        
        public async Task ExecuteAsync()
        {
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                var result = await conn.QueryAsync<dynamic>(GetQuery());
                //Store information in another place
                //Add it on a BI
            }            
        }

        public string GetConnectionString()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(Environment.GetEnvironmentVariable("Example"))
            {
                InitialCatalog = "Extrator"
            };

            return connectionStringBuilder.ConnectionString;
        }

        public string GetQuery()
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled()
        {
            throw new NotImplementedException();
        }
    }
}
