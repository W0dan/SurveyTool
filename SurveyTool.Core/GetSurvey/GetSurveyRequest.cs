using System;

namespace SurveyTool.Core.GetSurvey
{
    public class GetSurveyRequest : IRequest
    {
        public Guid SurveyId { get; set; }
    }
}
