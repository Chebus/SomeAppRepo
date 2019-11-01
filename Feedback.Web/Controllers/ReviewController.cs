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

            //Get the list of Review Ratings
            var ratingTypesResult = _reviewRatingTypesController.Get();
            if (ratingTypesResult.Result.GetType() == typeof(OkObjectResult))
            {
                //If the response was OK, get the results and convert them to a SelectList
                var ratingTypes = ((ratingTypesResult.Result as OkObjectResult).Value as IEnumerable<ReviewRatingType>);
                vm.RatingTypes = new SelectList(ratingTypes.Select(x => x.ToVm()), nameof(IdValueViewModel.Id), nameof(IdValueViewModel.Value));
            }

            return PartialView("_Add", vm);
        }

        // POST: /<controller>/Add
        [HttpPost]
        public IActionResult Add(ReviewViewModel vm)
        {
            //convert the ReviewViewModel to a DTO object accepted by the API and POST it
            var result = _reviewsController.Post(vm.ToDto());

            if (result.GetType() == typeof(OkResult))
            {
                //success message
                SetResultsMessage("Your review has been added sucessfully!");
            }
            else
            {
                //Error
                SetResultsMessage("An unknown error occured while trying to add your review. Please try again.", true);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /<controller>/List
        [HttpGet]
        public ActionResult<IEnumerable<int>> List()
        {
            var list = new List<ReviewListViewModel>();

            //get the list of REviews to display
            var result = _reviewsController.Get();

            if (result.Result.GetType() == typeof(OkObjectResult))
            {
                //If the response was OK, map the result to a ViewModel and set the View URL link
                var reviews = ((result.Result as OkObjectResult).Value as IEnumerable<Review>);
                list = reviews.Select(x => x.ToListVm(Url.Action("Get", "Review", new { id = x.ReviewId }))).ToList();
            }
            else
            {
                //Error
                SetResultsMessage("An unknown error occured while trying to get the list of reviews.", true);
            }

            return Json(new { data = list });
        }

        // GET: /<controller>/Get/<id>
        [HttpGet]
        public ActionResult<ReviewViewModel> Get(int id)
        {
            ReviewViewModel reviewVm = null;

            //Get the specific Review
            var httpResult = _reviewsController.Get(id);

            if (httpResult.Result.GetType() == typeof(OkObjectResult))
            {
                //if the responmse was OK, convert the result to a ViewModel
                var review = ((httpResult.Result as OkObjectResult).Value as Review);
                reviewVm = review.ToVm();
            }
            else if (httpResult.Result.GetType() == typeof(NotFoundResult))
            {
                //Show 404 message
                SetResultsMessage("The review you requested could not be found. Please try again.", true);
            }
            else
            {
                //Error
                SetResultsMessage("An unknown error occured while trying to get the review. Please try again.", true);
            }

            return PartialView("_View", reviewVm);
        }
    }
}
