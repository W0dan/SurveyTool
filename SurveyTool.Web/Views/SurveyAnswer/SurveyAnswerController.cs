using Microsoft.AspNetCore.Mvc;
using SurveyTool.Core.GetSurveyAnswerPage;
using SurveyTool.Web.Mediator;
using SurveyTool.Web.Views.Shared;
using System;

namespace SurveyTool.Web.Views.SurveyAnswer
{
    [Route("survey")]
    public class SurveyAnswerController : Controller
    {
        private readonly IRequestDispatcher requestDispatcher;

        public SurveyAnswerController(IRequestDispatcher requestDispatcher)
        {
            this.requestDispatcher = requestDispatcher;
        }

        [HttpGet]
        [Route("answer/{id:guid}")]
        public IActionResult Index(Guid id)
        {
            var response = requestDispatcher.Dispatch<GetSurveyAnswerPageRequest, GetSurveyAnswerPageResponse>(new GetSurveyAnswerPageRequest { SurveyAnswerId = id, PageNumber = 1 });

            return View(new SurveyAnswerModel { Title = "Answer Survey", Page = response.Page });
        }
    }
}
