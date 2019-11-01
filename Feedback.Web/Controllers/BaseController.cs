using Microsoft.AspNetCore.Mvc;

namespace Feedback.UserInterface.Controllers
{
    public class BaseController : Controller
    {
        //Sets a Success or Failure message that will be displayed on the UI
        protected void SetResultsMessage(string message, bool isError = false)
        {
            TempData["ResultsMessage"] = message;
            TempData["ResultsMessageIsError"] = isError;
        }
    }
}
