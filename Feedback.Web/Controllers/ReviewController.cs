using Feedback.API.Controllers;
using Feedback.Database.Models;
using Feedback.UserInterface.Controllers;
using Feedback.UserInterface.Mappers;
using Feedback.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Feedback.Web.Controllers
{
    public class ReviewController : BaseController
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
            var vm = new ReviewViewModel();

            var ratingTypesResult = _reviewRatingTypesController.Get();
            if (ratingTypesResult.Result.GetType() == typeof(OkObjectResult))
            {
                var ratingTypes = ((ratingTypesResult.Result as OkObjectResult).Value as IEnumerable<ReviewRatingType>);
                vm.RatingTypes = new SelectList(ratingTypes.Select(x => x.ToVm()), nameof(IdValueViewModel.Id), nameof(IdValueViewModel.Value));
            }

            return PartialView("_Add", vm);
        }

        // POST: /<controller>/Add
        [HttpPost]
        public IActionResult Add(ReviewViewModel vm)
        {
            var result = _reviewsController.Post(vm.ToEntity());

            if (result.GetType() == typeof(OkResult))
            {
                //success message
                SetResultsMessage("Your review has been added sucessfully!");
            }
            else
            {
                //Error
                SetResultsMessage("An unknown error occured while trying to add your review. Please try again.", false);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /<controller>/List
        [HttpGet]
        public ActionResult<IEnumerable<int>> List()
        {
            var list = new List<ReviewListViewModel>();

            var result = _reviewsController.Get();

            if (result.Result.GetType() == typeof(OkObjectResult))
            {
                var reviews = ((result.Result as OkObjectResult).Value as IEnumerable<Review>);
                list = reviews.Select(x => x.ToListVm()).ToList();
            }
            else
            {
                //Error
                SetResultsMessage("An unknown error occured while trying to get the list of reviews.", false);
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
                SetResultsMessage("The review you requested could not be found. Please try again.", false);
            }
            else
            {
                //Error
                SetResultsMessage("An unknown error occured while trying to get the review. Please try again.", false);
            }

            return reviewVm;
        }
    }
}
