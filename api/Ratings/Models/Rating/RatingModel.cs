namespace RatingApi.Ratings.Models.Rating
{
    public class RatingModel
    {
        public RatingModel(string name, int score, int id)
        {
            Name = name;
            Score = score;
            Id = id;
        }
        public string Name { get; set; }
        public int Id { get; }
        public int Score { get; set; }

    }
}
