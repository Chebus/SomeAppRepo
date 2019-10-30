using Microsoft.AspNetCore.Mvc;

namespace Feedback.UserInterface.Controllers
{
    public class BaseController : Controller
    {
        protected void SetResultsMessage(string message, bool isError = false)
        {
            TempData["ResultsMessage"] = message;
            TempData["ResultsMessageIsError"] = isError;
        }
    }
}
