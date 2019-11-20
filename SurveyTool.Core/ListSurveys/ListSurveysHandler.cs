using SurveyTool.EntityFramework;
using System.Linq;

namespace SurveyTool.Core.ListSurveys
{
    public class ListSurveysHandler : IHandleRequest<ListSurveysRequest, ListSurveysResponse>
    {
        private readonly SurveyToolContext dbContext;

        public ListSurveysHandler(SurveyToolContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ListSurveysResponse Handle(ListSurveysRequest request)
        {
            var surveys = dbContext.Surveys
                .Select(x => new SurveyDto { Id = x.Id, Name = x.Name })
                .ToList();

            return new ListSurveysResponse
            {
                Surveys = surveys
            };
        }
    }
}
