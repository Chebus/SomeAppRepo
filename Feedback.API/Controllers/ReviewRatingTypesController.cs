﻿using System.Collections.Generic;
using Feedback.Database.Interfaces;
using Feedback.Database.Models;
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
            var result = _lookupService.GetReviewRatingTypes();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET api/reviewratingtypes/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}