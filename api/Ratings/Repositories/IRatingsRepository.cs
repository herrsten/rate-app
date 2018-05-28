using System.Collections.Generic;
using System.Threading.Tasks;
using RatingApi.Ratings.Models.Rating;

namespace RatingApi.Ratings.Repositories
{
    public interface IRatingsRepository
    {
        Task<RatingModel> Add(RatingInput rating);
        Task<RatingModel> Get(int id);
        Task<List<RatingModel>> Get();
        Task Delete(int id);
        Task<RatingModel> Update(int id, RatingInput rating);
    }
}
