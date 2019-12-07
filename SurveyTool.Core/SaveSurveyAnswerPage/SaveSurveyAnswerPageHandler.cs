using Microsoft.EntityFrameworkCore;
using SurveyTool.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyTool.Core.SaveSurveyAnswerPage
{
    public class SaveSurveyAnswerPageHandler : IHandleCommand<SaveSurveyAnswerPageCommand>
    {
        private readonly SurveyToolContext dbContext;

        public SaveSurveyAnswerPageHandler(SurveyToolContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Guid Handle(SaveSurveyAnswerPageCommand command)
        {
            var surveyAnswer = dbContext.SurveyAnswers.Single(x => x.Id == command.Id);

            var questionAnswers = dbContext.QuestionAnswers
                .Include(a => a.QuestionPartAnswers)
                .Where(a => a.SurveyAnswer.Id == command.Id && a.Question.SurveyPage.PageNumber == command.PageNumber)
                .ToList();

            // first remove current answers for this page
            foreach (var answer in questionAnswers)
            {
                foreach (var answerPart in answer.QuestionPartAnswers)
                {
                    dbContext.QuestionPartAnswers.Remove(answerPart);
                }
                dbContext.QuestionAnswers.Remove(answer);
            }
            dbContext.SaveChanges();

            // then insert the new answers
            foreach (var questionWithAnswerDto in command.QuestionsWithAnswers)
            {
                var question = dbContext.Questions.Single(x => x.Id == questionWithAnswerDto.QuestionId);
                var questionAnswer = new QuestionAnswer
                {
                    Id = Guid.NewGuid(),
                    AnswerText = questionWithAnswerDto.Answer.Text,
                    Question = question,
                    SurveyAnswer = surveyAnswer
                };
                dbContext.QuestionAnswers.Add(questionAnswer);

                // insert the answer parts if any
                if (questionWithAnswerDto.Answer.Parts != null)
                {
                    foreach (var questionPartId in questionWithAnswerDto.Answer.Parts)
                    {
                        var questionPart = dbContext.QuestionParts.Single(x => x.Id == questionPartId);
                        var answerPart = new QuestionPartAnswer
                        {
                            Id = Guid.NewGuid(),
                            Text = questionWithAnswerDto.Answer.Text, // obsolete ? text on questionAnswer maybe enough ?
                            QuestionAnswer = questionAnswer,
                            QuestionPart = questionPart
                        };
                        dbContext.QuestionPartAnswers.Add(answerPart);
                    }
                }
            }
            dbContext.SaveChanges();

            return command.Id;
        }
    }
}
