using Microsoft.AspNetCore.Mvc;
using EducationAPI.Services;
using EducationAPI.Models.Review;
using EducationAPI.Data.Exceptions;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace EducationAPI.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    [Authorize(Roles = "Admin")]

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
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReviewDTO>))]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAllReviewsAsync([FromQuery] string? searchPhrase, string? direction)
        {
            var reviews = await _reviewServices.GetAllReviewAsync(searchPhrase, direction);
            return Ok(reviews);
        }

        /// <summary>
        /// Get a review by id
        /// </summary> 
        [HttpGet("{reviewID}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ReviewDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReviewDTO>> GetReviewAsync([FromRoute] int reviewID)
        {
            var review = await _reviewServices.GetReviewByIDAsync(reviewID);
            return Ok(review);
        }

        /// <summary>
        /// Add new review 
        /// </summary>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(ReviewDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateReviewAsync([FromBody] CreateReveiwDTO createReveiwDTO)
        {
            var newReview = await _reviewServices.CreateReviewAsync(createReveiwDTO);
            return Ok(newReview);
        }


        /// <summary>
        /// Update all fields of review by id
        /// </summary> 
        [HttpPut("{reviewID}")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ReviewDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult>PutReviewAsync([FromBody] PutReviewDTO putReviewDTO, [FromRoute] int reviewID)
        {
            var updateReview = await _reviewServices.PutReviewAsync(putReviewDTO, reviewID);
            return Ok(updateReview);
        }



        /// <summary>
        /// Delete a review by id
        /// </summary> 
        [HttpDelete("{reviewID}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteReviewAsync([FromRoute] int reviewID)
        {
            await _reviewServices.DeleteReviewAsync(reviewID);
            return NoContent();
        }


        /// <summary>
        /// Update a review by id
        /// </summary> 
        [HttpPatch("{reviewID}")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ReviewDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> UpdateReviewAsync([FromBody] UpdateReviewDTO updateReviewDTO, [FromRoute] int reviewID)
        {
            var updateReview = await _reviewServices.UpdateReviewAsync(updateReviewDTO, reviewID);
            return Ok(updateReview);
        }

    }
}
