using Microsoft.AspNetCore.Mvc;
using SurveyTool.Core.GetSurveyAnswerPage;
using SurveyTool.Core.SaveSurveyAnswerPage;
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
        private readonly ICommandDispatcher commandDispatcher;

        public SurveyAnswerController(IRequestDispatcher requestDispatcher, ICommandDispatcher commandDispatcher)
        {
            this.requestDispatcher = requestDispatcher;
            this.commandDispatcher = commandDispatcher;
        }

        [HttpGet]
        [Route("answer/{id:guid}")]
        public IActionResult Index(Guid id)
        {
            var response = requestDispatcher.Dispatch<GetSurveyAnswerPageRequest, GetSurveyAnswerPageResponse>(new GetSurveyAnswerPageRequest { SurveyAnswerId = id, PageNumber = 1 });

            return View(new SurveyAnswerModel { Title = "Answer Survey", PageNumber = response.Page.PageNumber, Questions = response.Page.Questions.ToList(), Id = id });
        }

        [HttpPost]
        public IActionResult Next(SurveyAnswerResponseModel model)
        {
            // save current page
            SaveSurveyAnswerPageCommand command = new SaveSurveyAnswerPageCommand
            {
                Id = model.Id,
                PageNumber = model.PageNumber,
                QuestionsWithAnswers = model.Questions
            };
            commandDispatcher.Dispatch(command);

            // load next page
            var newPageNr = model.PageNumber + 1;
            return RedirectToAction("ShowPage", new { surveyAnswerId = model.Id, pageNr = newPageNr });
            // return RedirectToRoute("ShowPage", new { id = model.Id, pageNr = newPageNr });
        }

        [HttpGet]
        // [Route("answer/{id:guid}/{int}", Name = "ShowPage")]
        public IActionResult ShowPage(Guid surveyAnswerId, int pageNr)
        {
            var response = requestDispatcher.Dispatch<GetSurveyAnswerPageRequest, GetSurveyAnswerPageResponse>(new GetSurveyAnswerPageRequest { SurveyAnswerId = surveyAnswerId, PageNumber = pageNr });

            return View("Index", new SurveyAnswerModel { Title = "Answer Survey", PageNumber = response.Page.PageNumber, Questions = response.Page.Questions.ToList(), Id = surveyAnswerId });
        }
    }
}
