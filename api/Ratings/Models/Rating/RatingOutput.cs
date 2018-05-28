namespace RatingApi.Ratings.Models.Rating
{
    public class RatingOutput
    {
        public RatingOutput(string name, int score, int id)
        {
            Name = name;
            Score = score;
            Id = Id;
        }
        public string Name { get; }
        public int Id { get; }
        public int Score { get; }
    }
}
