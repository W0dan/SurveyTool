using Microsoft.AspNetCore.Mvc;
using SurveyTool.Core.GetSurveyAnswerPage;
using SurveyTool.Core.SaveSurveyAnswerPage;
using SurveyTool.Web.Mediator;
using SurveyTool.Web.Views.Shared;
using System;
using System.Collections.Generic;
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

            var model = GetModel(response, id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Next(SurveyAnswerModel model)
        {
            var response = requestDispatcher.Dispatch<GetSurveyAnswerPageRequest, GetSurveyAnswerPageResponse>(new GetSurveyAnswerPageRequest { SurveyAnswerId = model.Id, PageNumber = model.PageNumber });
            var dbQuestions = response.Page.Questions.ToList();

            for (int i = 0; i < dbQuestions.Count; i++)
            {
                var question = model.Questions[i];
                if (dbQuestions[i].Type != EntityFramework.QuestionType.Text && (!question.SelectedParts?.Any() ?? true))
                {
                    ModelState.AddModelError($"question{i}", $"Gelieve een antwoord te geven op de vraag '{dbQuestions[i].Title}' aub.");
                }
            }

            if (!ModelState.IsValid)
            {
                var newModel = GetModel(response, model.Id);
                for (int i = 0; i < model.Questions.Count; i++)
                {
                    foreach (var part in newModel.Questions[i].Parts)
                    {
                        if (model.Questions[i].SelectedParts?.Contains(part.QuestionPartId) ?? false)
                            part.QuestionPartAnswerId = part.QuestionPartId;
                        else
                            part.QuestionPartAnswerId = null;
                    }
                    newModel.Questions[i].Text = model.Questions[i].Text;
                }

                return View("Index", newModel);
            }

            // save current page
            var command = GetCommand(model);
            commandDispatcher.Dispatch(command);

            // load next or previous page
            var newPageNr = model.Next != null ? model.PageNumber + 1 : model.PageNumber - 1;
            return RedirectToAction("ShowPage", new { surveyAnswerId = model.Id, pageNr = newPageNr });
        }

        [HttpGet]
        // [Route("answer/{id:guid}/{int}", Name = "ShowPage")]
        public IActionResult ShowPage(Guid surveyAnswerId, int pageNr)
        {
            var response = requestDispatcher.Dispatch<GetSurveyAnswerPageRequest, GetSurveyAnswerPageResponse>(new GetSurveyAnswerPageRequest { SurveyAnswerId = surveyAnswerId, PageNumber = pageNr });

            if (response.Page != null)
            {
                var model = GetModel(response, surveyAnswerId);
                return View("Index", model);
            }
            else
            {
                return View("LastPage", new ViewModelBase { Title = "Bedankt !" });
            }
        }

        private static SurveyAnswerModel GetModel(GetSurveyAnswerPageResponse response, Guid id)
        {
            var questions = response.Page.Questions.Select(question => new QuestionWithAnswerModel
            {
                QuestionId = question.QuestionId,
                Title = question.Title,
                Type = question.Type,
                Text = question.Answer?.Text,
                Parts = question.QuestionParts.Select(part => new QuestionPartModel
                {
                    QuestionPartId = part.QuestionPartId,
                    Text = part.Text,
                    QuestionPartAnswerId = part.Answer.QuestionPartAnswerId,
                    Type = part.Type
                }).ToList()
            }).ToList();

            return new SurveyAnswerModel { Title = "Answer Survey", PageNumber = response.Page.PageNumber, Questions = questions, Id = id };
        }

        private static SaveSurveyAnswerPageCommand GetCommand(SurveyAnswerModel model)
        {
            return new SaveSurveyAnswerPageCommand
            {
                Id = model.Id,
                PageNumber = model.PageNumber,
                QuestionsWithAnswers = model.Questions.Select(question => new Core.SaveSurveyAnswerPage.QuestionAnswerDto
                {
                    QuestionId = question.QuestionId,
                    Type = question.Type,
                    Answer = new Core.SaveSurveyAnswerPage.AnswerDto
                    {
                        Text = question.Text,
                        Parts = question.SelectedParts
                    }
                }).ToList()
            };
        }
    }
}
