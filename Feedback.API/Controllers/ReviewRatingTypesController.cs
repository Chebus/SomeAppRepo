using Feedback.Database.Interfaces;
using Feedback.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Feedback.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ReviewRatingTypesController : ControllerBase
    {
        private ILookupService _lookupService;

        public ReviewRatingTypesController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        // GET api/reviewratingtypes
        [HttpGet]
        public ActionResult<IEnumerable<ReviewRatingType>> Get()
        {
            var result = _lookupService.GetReviewRatingTypes();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
