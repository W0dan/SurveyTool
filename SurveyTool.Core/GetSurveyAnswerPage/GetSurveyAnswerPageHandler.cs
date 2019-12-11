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
                       Questions = page.Questions.OrderBy(x => x.Order).Select(question => new QuestionWithAnswerDto
                       {
                           QuestionId = question.Id,
                           Title = question.Title,
                           Type = question.Type,
                           Mandatory = question.Mandatory,
                           Answer = question.Answers.Where(answer => answer.SurveyAnswer.Id == surveyAnswerId).Select(answer => new QuestionAnswerDto
                           {
                               AnswerId = answer.Id,
                               Text = answer.AnswerText
                           }).FirstOrDefault(),
                           QuestionParts = question.Parts.OrderBy(x => x.Order).Select(part => new QuestionPartWithAnswerDto
                           {
                               QuestionPartId = part.Id,
                               Text = part.Text,
                               Type = part.Type,
                               Answer = part.QuestionPartAnswers.Where(answer => answer.QuestionAnswer.SurveyAnswer.Id == surveyAnswerId).Select(answer => new QuestionPartAnswerDto
                               {
                                   QuestionPartAnswerId = answer.QuestionPart.Id,
                                   Text = answer.Text
                               }).FirstOrDefault()
                           })
                       })
                   })
                })
                .SingleOrDefault()?.Pages?.SingleOrDefault();

            return new GetSurveyAnswerPageResponse
            {
                Page = page
            };
        }
    }
}
