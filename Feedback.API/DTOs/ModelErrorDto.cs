using System.Collections.Generic;

namespace Feedback.API.DTOs
{
    //For Swagger description
    public class ModelErrorDto
    {
        public string Id { get; set; }
        public List<string> Errors { get; set; }
    }
}
