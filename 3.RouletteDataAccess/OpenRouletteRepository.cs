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
    public class OpenRouletteRepository : IOpenRouletteRepository
    {
        private readonly IConfiguration _configuration;
        public OpenRouletteRepository(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public async Task<bool> OpenRoulete(IdRoulette_Wrapper Roulette)
        {

            var connectionString = _configuration.GetConnectionString("develop");

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("No connection string in config.json");

            await using (var con = new SqlConnection(connectionString))
            {
                await using (var cmd = new SqlCommand("[SP_openRoulette]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRoulette", Roulette.idRoulette);
                    con.Open();
                    var affectedRows = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                    if (affectedRows == -1) return true;
                }
            }

            return false;
        }
    }
}
