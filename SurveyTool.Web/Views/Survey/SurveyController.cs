using Microsoft.AspNetCore.Mvc;
using SurveyTool.Core.CreateSurveyAnswer;
using SurveyTool.Core.GetSurvey;
using SurveyTool.Web.Mediator;
using System;

namespace SurveyTool.Web.Views.Survey
{
    [Route("survey")]
    public class SurveyController : Controller
    {
        private readonly IRequestDispatcher requestDispatcher;
        private readonly ICommandDispatcher commandDispatcher;

        public SurveyController(IRequestDispatcher requestDispatcher, ICommandDispatcher commandDispatcher)
        {
            this.requestDispatcher = requestDispatcher;
            this.commandDispatcher = commandDispatcher;
        }

        [HttpGet("{id:guid}")]
        public IActionResult Index(Guid id)
        {
            var response = requestDispatcher.Dispatch<GetSurveyRequest, GetSurveyResponse>(new GetSurveyRequest { SurveyId = id });

            var model = new SurveyModel { Title = response.Survey.Name, Survey = response.Survey };

            return View(model);
        }

        [HttpPost]
        [Route("answer/create/{id:guid}")]
        public IActionResult CreateSurveyAnswer(Guid id)
        {
            var answerId = commandDispatcher.Dispatch(new CreateSurveyAnswerCommand { SurveyId = id });

            return RedirectToAction("answer", "survey", new { id = answerId });
        }
    }
}
