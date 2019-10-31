using Feedback.API.DTOs;
using Feedback.Database.Interfaces;
using Feedback.Database.Models;
using Feedback.UserInterface.Mappers;
using Feedback.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Feedback.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET api/reviews
        /// <summary>
        /// Gets a list of Reviews
        /// </summary>
        /// <returns>List of Reviews</returns>
        /// <response code="200">Returns the list of Reviews</response>
        /// <response code="401">If the user is not authenticated</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public ActionResult<IEnumerable<Review>> Get()
        {
            var result = _reviewService.GetReviews();
            return Ok(result);
        }

        // GET api/reviews/5
        /// <summary>
        /// Gets a specific Review
        /// </summary>
        /// <returns>The specified Review</returns>
        /// <response code="200">Returns the Review</response>
        /// <response code="400">If the parameter is invalid</response>
        /// <response code="401">If the user is not authenticated</response>
        /// <response code="404">If the Review does not exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ModelErrorDto), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public ActionResult<Review> Get(int id)
        {
            var result = _reviewService.GetReview(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/reviews
        /// <summary>
        /// Creates a new Review
        /// </summary>
        /// <param name="dto">The Review to create</param>
        /// <returns>A list of errors if there were any</returns>
        /// <response code="200">The Review was created</response>
        /// <response code="400">If there were errors</response>
        /// <response code="401">If the user is not authenticated</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ModelErrorDto), 400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] ReviewDto dto)
        {
            //automatic .NET Core ModelState validation: all ModelState errors are automatically added to the response as a 400 BadRequest

            try
            {
                var review = dto.ToEntity();
                _reviewService.CreateReview(review);
            }
            catch
            {
                return BadRequest(new ModelErrorDto() { Errors = new List<string> { "An unknown error occured." } });
            }
            return Ok();
        }
    }
}
