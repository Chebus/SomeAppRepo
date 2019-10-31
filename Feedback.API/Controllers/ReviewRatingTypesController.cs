using Feedback.API.DTOs;
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

        // GET api/reviewratingtypes/5
        /// <summary>
        /// Gets a specific Review Rating Type
        /// </summary>
        /// <returns>The specified Review Rating Type</returns>
        /// <response code="200">Returns the Review Rating Type</response>
        /// <response code="400">If the parameter is invalid</response>
        /// <response code="401">If the user is not authenticated</response>
        /// <response code="404">If the Review Rating Type does not exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ModelErrorDto), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public ActionResult<ReviewRatingType> Get(int id)
        {
            var result = _lookupService.GetReviewRatingType(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
