using Microsoft.AspNetCore.Mvc;
using EducationAPI.Services;
using EducationAPI.Models.Review;


namespace EducationAPI.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewServices _reviewServices;
        public ReviewController(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
        }

        /// <summary>
        /// Get all reviews
        /// </summary> 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAllReviewsAsync()
        {
            var reviews = await _reviewServices.GetAllReviewAsync();
                return Ok(reviews);
        }

        /// <summary>
        /// Get a review by id
        /// </summary> 
        [HttpGet("{reviewID}")]
        public async Task<ActionResult<ReviewDTO>> GetReviewAsync([FromRoute] int reviewID)
        {
            var review = await _reviewServices.GetReviewByIDAsync(reviewID);
            return Ok(review);
        }

        /// <summary>
        /// Add new review 
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> CreateReviewAsync([FromBody] CreateReveiwDTO createReveiwDTO)
        {
            await _reviewServices.CreateReviewAsync(createReveiwDTO);
            return Ok();
        }

        /// <summary>
        /// Delete a review by id
        /// </summary> 
        [HttpDelete("{reviewID}")]
        public async Task<ActionResult> DeleteReviewAsync([FromRoute] int reviewID)
        {
            await _reviewServices.DeleteReviewAsync(reviewID);
            return NoContent();
        }


        /// <summary>
        /// Update a review by id
        /// </summary> 
        [HttpPatch("{reviewID}")]

        public async Task<ActionResult> UpdateAuthorAsync([FromBody] UpdateReviewDTO updateReviewDTO, [FromRoute] int reviewID)
        {
            await _reviewServices.UpdateReviewAsync(updateReviewDTO, reviewID);
            return Ok();
        }

    }
}
