using SurveyTool.EntityFramework;
using System.Linq;

namespace SurveyTool.Core.GetSurveyAnswerPage
{
    public class GetSurveyAnswerPageHandler : IHandleRequest<GetSurveyAnswerPageRequest, GetSurveyAnswerPageResponse>
    {
        private readonly SurveyToolContext dbContext;

        public GetSurveyAnswerPageHandler(SurveyToolContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public GetSurveyAnswerPageResponse Handle(GetSurveyAnswerPageRequest request)
        {
            var surveyAnswerId = request.SurveyAnswerId;
            var pageNumber = request.PageNumber;

            var page = dbContext.SurveyAnswers
                .Where(surveyAnswer => surveyAnswer.Id == surveyAnswerId)
                .Select(surveyAnswer => new
                {
                    Pages = surveyAnswer.Survey.Pages
                   .Where(page => page.PageNumber == pageNumber)
                   .Select(page => new PageWithQuestionsAndAnswersDto
                   {
                       PageNumber = page.PageNumber,
                       Questions = page.Questions.Select(question => new QuestionWithAnswerDto
                       {
                           QuestionId = question.Id,
                           Title = question.Title,
                           AnswerText = question.Answers.Where(answer => answer.SurveyAnswer.Id == surveyAnswerId).SingleOrDefault().AnswerText ?? ""
                       })
                   })
                })
                .Single().Pages.Single();

            return new GetSurveyAnswerPageResponse
            {
                Page = page
            };
        }
    }
}
