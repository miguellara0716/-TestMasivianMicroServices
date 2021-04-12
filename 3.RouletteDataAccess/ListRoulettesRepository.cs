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
    public class ListRoulettesRepository : IListRoulettesRepository
    {
        private readonly IConfiguration _configuration;
        public ListRoulettesRepository(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }
        public async Task<ICollection<Roulettes_Wrappers>> ListRoulette()
        {

            var connectionString = _configuration.GetConnectionString("develop");

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("No connection string in config.json");

            await using (var con = new SqlConnection(connectionString))
            {
                await using (var cmd = new SqlCommand("[SP_GetRoulettes]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
                    ICollection<Roulettes_Wrappers> Roulettes = new List<Roulettes_Wrappers>();
                    while (reader.Read())
                    {
                        Roulettes_Wrappers Roulette = new Roulettes_Wrappers();
                        Roulette.IdRoulette = (long)(await reader.IsDBNullAsync("IdRoulette") ? 0 : reader["IdRoulette"]);
                        Roulette.IdState = (short)(await reader.IsDBNullAsync("IdState") ? 0 : Int16.Parse(reader["IdState"].ToString()));
                        Roulette.Description = (String)(await reader.IsDBNullAsync("Description") ? 0 : reader["Description"]);
                        Roulette.DateCreation = (DateTime)(await reader.IsDBNullAsync("DateCreation") ? DateTime.Now : reader["DateCreation"]);
                        Roulettes.Add(Roulette);

                    }

                    return Roulettes;
                }
            }
        }
    }
}
