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

            string cs = @"URI=file:/Users/alliesans/Documents/UA Summer 2023/MIS 321 Make-Up/Source/Repos/GameX/API/game.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "select games.gameid, title, genre, ratings.rating from games left join ratings on (games.gameid=ratings.gameid)";
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
            string cs = @"URI=file:/Users/alliesans/Documents/UA Summer 2023/MIS 321 Make-Up/Source/Repos/GameX/API/game.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM games WHERE gameid = @id";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Game(){Id = rdr.GetInt32(0), Title = rdr.GetString(1), Genre = rdr.GetString(2)};
        }
    }
}