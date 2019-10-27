using System.Collections.Generic;
using Feedback.Database.Models;
using Feedback.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public ActionResult<IEnumerable<ReviewRatingType>> Get()
        {
            return _lookupService.GetReviewRatingTypes();
        }

        // GET api/reviewratingtypes/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
