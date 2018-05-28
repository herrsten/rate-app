using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RatingApi.Ratings.Models.Rating;
using RatingApi.Ratings.Repositories;

namespace RatingApi.Controllers
{
    [Route("api/[controller]")]
    public class RatingsController : Controller
    {
        private readonly IRatingsRepository _ratingsRepository;

        public RatingsController(IRatingsRepository ratingsRepository)
        {
            _ratingsRepository = ratingsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ratings = await _ratingsRepository.Get();
                return Ok(ratings);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("Invalid Id");
                }
                var rating = await _ratingsRepository.Get(id);
                if (rating == null)
                {
                    return NotFound();
                }
                return Ok(rating);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RatingInput rating)
        {
            try
            {
                var validationResult = rating.Validate();
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Message);
                }
              
                var created = await _ratingsRepository.Add(rating);

                if (created == null)
                {
                    return BadRequest($"There is already a rating with the name {rating.Name}");
                }
                return Created($"api/ratings/{created.Id}", created);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromBody]RatingInput rating, int id)
        {
            try
            {
                var validationResult = rating.Validate(id);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Message);
                }
                var result = await _ratingsRepository.Update(id, rating);

                if (result == null)
                {
                    return BadRequest($"There is already a rating with the name {rating.Name}");
                }

                if (result.Id != id)
                {
                    return Created($"api/ratings/{result.Id}", result);
                }
             
                return NoContent();

            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("Invalid Id");
                }
                await _ratingsRepository.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
