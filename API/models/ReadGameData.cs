using System.Collections.Generic;
using System.Data.SQLite;
using API.models.interfaces;

namespace API.models
{
    public class ReadGameData : IGetAllGames, IGetGame
    {
        public List<Game> GetAllGames()
        {
            List<Game> allGames = new List<Game>();

            string cs = @"URI=file:/Users/alliesans/Documents/MIS 321 Make-Up/Source/Repos/gamedatabase/game.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM games";
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                allGames.Add(new Game(){Id = rdr.GetInt32(0), Title = rdr.GetString(1), Genre = rdr.GetString(2)});
            }

            return allGames;
        }

        public Game GetGame(int id)
        {
            string cs = @"URI=file:/Users/alliesans/Documents/MIS 321 Make-Up/Source/Repos/gamedatabase/game.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM games WHERE id = @id";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Game(){Id = rdr.GetInt32(0), Title = rdr.GetString(1), Genre = rdr.GetString(2)};
        }
    }
}