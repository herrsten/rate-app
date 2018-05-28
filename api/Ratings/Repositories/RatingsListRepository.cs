using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RatingApi.Ratings.Models.Rating;

namespace RatingApi.Ratings.Repositories
{
    public class RatingsListRepository : IRatingsRepository
    {
        public List<RatingModel> Ratings = new List<RatingModel>();
        private int _id = 0;

        public async Task<RatingModel> Add(RatingInput ratingInput)
        {
            var id = ++_id;
            var rating = ratingInput.ToModel(id);
            var exists = await CheckIfRatingNameExists(rating.Name);
            if (exists)
            {
                return null;
            }
            Ratings.Add(rating);
            return await Task.FromResult(rating);
        }
        public async Task<RatingModel> Get(int id)
        {
            return await Task.FromResult(Ratings.Find(x => x.Id == id));
        }

        public async Task<List<RatingModel>> Get()
        {
            return await Task.FromResult(Ratings);
        }

        public async Task<RatingModel> Update(int id, RatingInput rating)
        {
            var currentRating = Ratings.Find(x => x.Id == id);
            if (currentRating == null)
            {
                return await Add(rating);
            }

            currentRating.Score = rating.Score;
            currentRating.Name = rating.Name;
            return await Task.FromResult(currentRating);
        }

        public async Task Delete(int id)
        {
            var rating = await Get(id);
            if (rating != null)
                Ratings.Remove(rating);
        }

        private async Task<bool> CheckIfRatingNameExists(string name)
        {
            var existingRating = await Task.FromResult(Ratings.Find(x => String.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase)));
            return existingRating != null;
        }
    }
}
