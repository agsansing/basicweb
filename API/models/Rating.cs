namespace API.models
{
    public class Rating
    {
        public int UserId{get; set;}
        public int GameId{get; set;}
        public int UserRating{get; set;}

        public override string ToString()
        {
            return UserId + " " + GameId + " " + UserRating;
        }
    }
}