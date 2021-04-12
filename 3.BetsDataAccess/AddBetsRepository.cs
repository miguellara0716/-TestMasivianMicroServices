using _3.BetsDataAccess.Interface;
using _4.BetsBusinessEntities.Wrappers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace _3.BetsDataAccess
{
    public class AddBetsRepository : IAddBetsRepository
    {
        private readonly IConfiguration _configuration;
        
        public AddBetsRepository(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }
        public async Task<NumberBet_Wrapper> AddBet(AddBets_Wrappers bet)
        {
            var connectionString = _configuration.GetConnectionString("develop");

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("No connection string in config.json");


            await using (var con = new SqlConnection(connectionString))
            {
                await using (var cmd = new SqlCommand("[SP_InsertBet]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUser", bet.IdUser);
                    cmd.Parameters.AddWithValue("@IdRoulette", bet.IdRoulette);
                    cmd.Parameters.AddWithValue("@BetValue", bet.BetValue);
                    cmd.Parameters.AddWithValue("@BetNumber", bet.BetNumber);
                    cmd.Parameters.AddWithValue("@BetColor", bet.BetColor);
                    cmd.Parameters.AddWithValue("@IsColorBet", bet.IsBetColor);
                    con.Open();
                    var reader = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                    NumberBet_Wrapper IdBet = new NumberBet_Wrapper();
                    IdBet.NumberBet = Int64.Parse(reader.ToString());
                    return IdBet;
                }
            }

        }
    }
}
