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
    public class CloseBetsRepository : ICloseBetsRepository
    {
        private readonly IConfiguration _configuration;
        public CloseBetsRepository(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }
        public async Task<WinnerNumber_Wrapper> CloseRoulette(IdRoulette_Wrapper IdRoulette)
        {
            var connectionString = _configuration.GetConnectionString("develop");

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("No connection string in config.json");


            await using (var con = new SqlConnection(connectionString))
            {
                await using (var cmd = new SqlCommand("[SP_CloseRoulette]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRoulette", IdRoulette.IdRoulette);
                    con.Open();
                    var reader = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                    WinnerNumber_Wrapper Winner = new WinnerNumber_Wrapper();
                    Winner.WinnerNumber = Int32.Parse(reader.ToString());
                    return Winner;
                }
            }
        }
        public async Task<ICollection<Bets_Wrapper>> getBets(IdRoulette_Wrapper IdRoulette)
        {
            var connectionString = _configuration.GetConnectionString("develop");

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("No connection string in config.json");


            await using (var con = new SqlConnection(connectionString))
            {
                await using (var cmd = new SqlCommand("[SP_getsRouletteBets]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRoulette", IdRoulette.IdRoulette);
                    con.Open();
                    var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
                    ICollection<Bets_Wrapper> Bets = new List<Bets_Wrapper>();
                    while (reader.Read())
                    {
                        Bets_Wrapper Bet = new Bets_Wrapper();
                        Bet.IdRoulette = (long)(await reader.IsDBNullAsync("IdRoulette") ? 0 : reader["IdRoulette"]);
                        Bet.IdBet = (long)(await reader.IsDBNullAsync("IdBet") ? 0 : reader["IdBet"]);
                        Bet.IdUser = (String)(await reader.IsDBNullAsync("IdUser") ? null : reader["IdUser"]);
                        Bet.BetValue = (int)(await reader.IsDBNullAsync("BetValue") ? 0 : Int32.Parse(reader["BetValue"].ToString()));
                        Bet.BetNumber = (int)(await reader.IsDBNullAsync("BetNumber") ? 0 : Int32.Parse(reader["BetNumber"].ToString())); 
                        Bet.BetColor = (short)(await reader.IsDBNullAsync("BetColor") ? 0 : Int16.Parse(reader["BetColor"].ToString())); 
                        Bet.IsColorBet = (bool)(await reader.IsDBNullAsync("IsColorBet") ? 0 : reader["IsColorBet"]);
                        Bet.DateBet = (DateTime)(await reader.IsDBNullAsync("DateBet") ? DateTime.Now : reader["DateBet"]); ;
                        Bets.Add(Bet);
                    }

                    return Bets;
                }
            }

        }
    }
}
