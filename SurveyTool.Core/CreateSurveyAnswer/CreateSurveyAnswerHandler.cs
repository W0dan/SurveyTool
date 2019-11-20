using SurveyTool.EntityFramework;
using System;
using System.Linq;

namespace SurveyTool.Core.CreateSurveyAnswer
{
    public class CreateSurveyAnswerHandler : IHandleCommand<CreateSurveyAnswerCommand>
    {
        private readonly SurveyToolContext dbContext;

        public CreateSurveyAnswerHandler(SurveyToolContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Guid Handle(CreateSurveyAnswerCommand command)
        {
            var answer = new SurveyAnswer
            {
                Id = Guid.NewGuid()
            };

            var survey = dbContext.Surveys.Single(x => x.Id == command.SurveyId);
            dbContext.SurveyAnswers.Add(answer);
            survey.Answers.Add(answer);

            return answer.Id;
        }
    }
}
