using Feedback.Database.Interfaces;
using Feedback.Database.Models;
using Microsoft.AspNetCore.Authorization;
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

        // GET api/review
        [HttpGet]
        public ActionResult<IEnumerable<Review>> Get()
        {
            var result = _reviewService.GetReviews();
            return Ok(result);
        }

        // GET api/review/5
        [HttpGet("{id}")]
        public ActionResult<Review> Get(int id)
        {
            var result = _reviewService.GetReview(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/review
        [HttpPost]
        public StatusCodeResult Post([FromBody] Review review)
        {
            try
            {
                _reviewService.CreateReview(review);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
