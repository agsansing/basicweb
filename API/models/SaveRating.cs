using System.Data.SQLite;
using API.models.interfaces;

namespace API.models
{
    public class SaveRating : IInsertRating
    {
        public void InsertRating(Rating value)
      {
        string cs = @"URI=file:/Users/alliesans/Documents/UA Summer 2023/MIS 321 Make-Up/Source/Repos/GameX/API/game.db";
        using var con = new SQLiteConnection(cs);
        con.Open();

        using var cmd = new SQLiteCommand(con);

        cmd.CommandText = @"INSERT INTO ratings(userRating) VALUES(@userRating)";
        cmd.Parameters.AddWithValue("@userRating",value.UserRating);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
      }
    }
}