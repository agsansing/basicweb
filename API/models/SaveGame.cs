using System.Data.SQLite;
using API.models.interfaces;

namespace API.models
{
    public class SaveGame : IInsertGame
    {
      public void InsertGame(Game value)
      {
        string cs = @"URI=file:/Users/alliesans/Documents/MIS 321 Make-Up/Source/Repos/gamedatabase/game.db";
        using var con = new SQLiteConnection(cs);
        con.Open();

        using var cmd = new SQLiteCommand(con);

        cmd.CommandText = @"INSERT INTO games(title,genre) VALUES(@title,@genre)";
        cmd.Parameters.AddWithValue("@title",value.Title);
        cmd.Parameters.AddWithValue("@genre",value.Genre);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
      }
    }
}