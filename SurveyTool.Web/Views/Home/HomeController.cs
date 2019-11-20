using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SurveyTool.Core.ListSurveys;
using SurveyTool.Web.Mediator;
using SurveyTool.Web.Views.Shared;

namespace SurveyTool.Web.Views.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IRequestDispatcher requestDispatcher;

        public HomeController(ILogger<HomeController> logger, IRequestDispatcher requestDispatcher)
        {
            this.logger = logger;
            this.requestDispatcher = requestDispatcher;
        }

        public IActionResult Index()
        {
            var response = requestDispatcher.Dispatch<ListSurveysRequest, ListSurveysResponse>(new ListSurveysRequest());

            return View(new HomeViewModel { Title = "Home Page", Surveys = response.Surveys });
        }

        public IActionResult Privacy()
        {
            return View(new ViewModelBase { Title = "Privacy Policy" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
