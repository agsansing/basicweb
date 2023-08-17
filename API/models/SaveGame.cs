using System.Data.SQLite;
using API.models.interfaces;

namespace API.models
{
    public class SaveGame : IInsertGame
    {
      public void InsertGame(Game value)
      {
        string cs = @"URI=file:/Users/alliesans/Documents/UA Summer 2023/MIS 321 Make-Up/Source/Repos/GameX/API/game.db";
        using var con = new SQLiteConnection(cs);
        con.Open();

        using var cmd = new SQLiteCommand(con);

        cmd.CommandText = @"INSERT INTO games(title,genre) VALUES(@title,@genre)";
        cmd.Parameters.AddWithValue("@title",value.Title);
        cmd.Parameters.AddWithValue("@genre",value.Genre);
        cmd.Prepare();
        cmd.ExecuteNonQuery();

        cmd.CommandText = @"INSERT INTO ratings(gameid,rating) VALUES(@id,@rating)";
        cmd.Parameters.AddWithValue("@id",value.Id);
        cmd.Parameters.AddWithValue("@rating",value.Rating);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
      }
    }
}