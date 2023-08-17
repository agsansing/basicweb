using System.Collections.Generic;
using System.Data.SQLite;
using API.models.interfaces;

namespace API.models
{
    public class ReadRatingData : IGetAllRatings, IGetRating
    {
        public List<Rating> GetAllRatings()
        {
            List<Rating> allRatings = new List<Rating>();

            string cs = @"URI=file:/Users/alliesans/Documents/UA Summer 2023/MIS 321 Make-Up/Source/Repos/GameX/API/game.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM ratings";
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                allRatings.Add(new Rating(){UserId = rdr.GetInt32(0), GameId = rdr.GetInt32(1), UserRating = rdr.GetInt32(2)});
            }

            return allRatings;
        }

        public Rating GetRating(int gameId)
        {
            string cs = @"URI=file:/Users/alliesans/Documents/UA Summer 2023/MIS 321 Make-Up/Source/Repos/GameX/API/game.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM ratings WHERE gameId = @gameId";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@gameId", gameId);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Rating(){UserId = rdr.GetInt32(0), GameId = rdr.GetInt32(1), UserRating = rdr.GetInt32(2)};
        }
    }
}