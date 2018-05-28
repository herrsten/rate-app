using RatingApi.Ratings.Models.Validation;

namespace RatingApi.Ratings.Models.Rating
{
    public static class RatingExtensions
    {
        public static RatingModel ToModel(this RatingInput input, int id)
        {
            return new RatingModel(input.Name, input.Score, id);
        }

        public static RatingOutput ToOutput(this RatingModel model)
        {
            return new RatingOutput(model.Name, model.Score, model.Id);
        }

        public static ValidationResult Validate(this RatingInput input, int? id = null)
        {
            if (input == null)
            {
                return new ValidationResult
                {
                    Message = $"Invalid input, input is null.",
                    IsValid = false
                };
            }

            if(id.HasValue && id < 1)
            {
                return new ValidationResult
                {
                    Message = $"Invalid Id. Provided id was {id}.",
                    IsValid = false
                };
            }

            if (input.Score < 0 || input.Score > 5)
            {
                return new ValidationResult
                {
                    Message = $"Invalid score. Provided score was {input.Score}, valid scores are 0-5.",
                    IsValid = false
                };
            }

            return new ValidationResult
            {
                IsValid = true
            };
        }

    }
}
