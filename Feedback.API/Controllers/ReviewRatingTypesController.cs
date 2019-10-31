using Feedback.Database.Interfaces;
using Feedback.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Feedback.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewRatingTypesController : ControllerBase
    {
        private ILookupService _lookupService;

        public ReviewRatingTypesController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        // GET api/reviewratingtypes
        /// <summary>
        /// Gets a list of Review Rating Types
        /// </summary>
        /// <returns>List of Review Rating Types</returns>
        /// <response code="200">Returns the list of Review Rating Types</response>
        /// <response code="401">If the user is not authenticated</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public ActionResult<IEnumerable<ReviewRatingType>> Get()
        {
            var result = _lookupService.GetReviewRatingTypes();
            return Ok(result);
        }
    }
}
