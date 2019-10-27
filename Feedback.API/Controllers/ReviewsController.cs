using System.Collections.Generic;
using Feedback.Database.Models;
using Feedback.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            return _reviewService.GetReviews();
        }

        // GET api/review/5
        [HttpGet("{id}")]
        public ActionResult<Review> Get(int id)
        {
            return _reviewService.GetReview(id);
        }

        // POST api/review
        [HttpPost]
        public void Post([FromBody] Review review)
        {
            _reviewService.CreateReview(review);
        }
    }
}
