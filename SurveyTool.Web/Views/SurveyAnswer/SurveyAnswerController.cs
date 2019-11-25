using Microsoft.AspNetCore.Mvc;
using SurveyTool.Core.GetSurveyAnswerPage;
using SurveyTool.Web.Mediator;
using SurveyTool.Web.Views.Shared;
using System;
using System.Linq;

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

            return View(new SurveyAnswerModel { Title = "Answer Survey", PageNumber = response.Page.PageNumber, Questions=response.Page.Questions.ToList() });
        }
    }
}
