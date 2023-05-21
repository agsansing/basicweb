namespace API.models
{
    public class Game
    {
        public int Id{get; set;}
        public string Title{get; set;}
        public string Genre{get; set;}
        public override string ToString()
        {
            return Id + " " + Title + " " + Genre;
        }
    }
}