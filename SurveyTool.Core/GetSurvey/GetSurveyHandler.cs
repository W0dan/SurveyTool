using SurveyTool.EntityFramework;
using System.Linq;

namespace SurveyTool.Core.GetSurvey
{
    public class GetSurveyHandler : IHandleRequest<GetSurveyRequest, GetSurveyResponse>
    {
        private readonly SurveyToolContext dbContext;

        public GetSurveyHandler(SurveyToolContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public GetSurveyResponse Handle(GetSurveyRequest request)
        {
            var survey = dbContext.Surveys
                .Select(x => new SurveyDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                })
                .Single(x => x.Id == request.SurveyId);

            return new GetSurveyResponse { Survey = survey };
        }
    }
}
