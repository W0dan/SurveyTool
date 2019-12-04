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
                .Where(a => a.SurveyAnswer.Id == command.Id && a.Question.SurveyPage.PageNumber == command.PageNumber)
                .ToList();

            // first remove current answers for this page
            foreach (var answer in questionAnswers)
            {
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

                //foreach (var questionPartWithAnswerDto in questionWithAnswerDto.QuestionParts)
                //{
                //    var questionPart = dbContext.QuestionParts.Single(x => x.Id == questionPartWithAnswerDto.Id);
                //    var answerPart = new QuestionPartAnswer
                //    {
                //        Id = Guid.NewGuid(),
                //        Text = questionPartWithAnswerDto.Answer.Text,
                //        QuestionAnswer = questionAnswer,
                //    };
                //    dbContext.QuestionPartAnswers.Add(answerPart);
                //}
            }
            dbContext.SaveChanges();

            return command.Id;
        }
    }
}
