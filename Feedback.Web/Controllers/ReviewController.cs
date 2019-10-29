using Feedback.API.Controllers;
using Feedback.Database.Models;
using Feedback.UserInterface.Mappers;
using Feedback.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Feedback.Web.Controllers
{
    public class ReviewController : Controller
    {
        private ReviewsController _reviewsController;
        private ReviewRatingTypesController _reviewRatingTypesController;

        public ReviewController(ReviewsController reviewsController, ReviewRatingTypesController reviewRatingTypesController)
        {
            _reviewsController = reviewsController;
            _reviewRatingTypesController = reviewRatingTypesController;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View("List");
        }

        // GET: /<controller>/Add
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_Add", new ReviewViewModel());
        }

        // POST: /<controller>/Add
        [HttpPost]
        public IActionResult Add(ReviewViewModel vm)
        {
            var result = _reviewsController.Post(vm.ToReview());

            if (result.GetType() == typeof(OkResult))
            {
                //success message
            }
            else
            {
                //Error
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /<controller>/List
        [HttpGet]
        public ActionResult<IEnumerable<int>> List()
        {
            var list = new List<int>() { 0 };

            var result = _reviewsController.Get();

            if (result.Result.GetType() == typeof(OkObjectResult))
            {
                var reviews = ((result.Result as OkObjectResult).Value as IEnumerable<Review>);

                list = reviews.Select(x => x.ReviewRatingTypeId).ToList();
            }
            else if (result.Result.GetType() == typeof(NotFoundResult))
            {
                //Show 404 message
            }
            else
            {
                //Error
            }

            return Json(new { data = list });
        }

        // GET: /<controller>/Get/<id>
        [HttpGet]
        public ActionResult<ReviewViewModel> Get(int id)
        {
            ReviewViewModel reviewVm = null;

            var httpResult = (_reviewsController.Get(id).Result as ObjectResult);

            if (httpResult.StatusCode == (int)HttpStatusCode.OK)
            {
                var review = (httpResult.Value as Review);

                reviewVm = new ReviewViewModel()
                {
                    Rating = review.ReviewRatingType.EnglishText,
                    Comment = review.Comment
                };
            }
            else if (httpResult.StatusCode == (int)HttpStatusCode.NotFound)
            {
                //Show 404 message
            }
            else
            {
                //Error
            }

            return reviewVm;
        }
    }
}
