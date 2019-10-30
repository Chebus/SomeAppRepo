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
        [HttpGet]
        [ProducesResponseType(200)]
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
        /// <response code="404">If the Review does not exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
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
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] ReviewDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var review = dto.ToEntity();
                    _reviewService.CreateReview(review);
                }
                else
                {
                    var errors = new List<string>();
                    foreach (var state in ModelState)
                    {
                        foreach (var error in state.Value.Errors)
                        {
                            errors.Add(error.ErrorMessage);
                        }
                    }
                    return BadRequest(errors);
                }
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
