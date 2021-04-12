using _3.OnlineRouletteDataAccess.Interface;
using _4.OnlineRouletteBusinessEntities.Wrappers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace _3.OnlineRouletteDataAccess
{
    public class CreateRouletteRepository : ICreateRouletteRepository
    {
        private readonly IConfiguration _configuration;
        public CreateRouletteRepository(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }
        public async Task<IdRoulette_Wrapper> CreateRoulette()
        {
            
            var connectionString = _configuration.GetConnectionString("develop");

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("No connection string in config.json");

            
            await using (var con = new SqlConnection(connectionString))
            {
                await using (var cmd = new SqlCommand("[SP_InsertRoulette]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var reader =  await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                    IdRoulette_Wrapper IdRoulette = new IdRoulette_Wrapper();
                    IdRoulette.idRoulette = Int64.Parse(reader.ToString());
                    return IdRoulette;                    
                }
            }

            
        }
    }
}
