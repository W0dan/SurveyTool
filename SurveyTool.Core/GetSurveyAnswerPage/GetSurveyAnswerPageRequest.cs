using System;

namespace SurveyTool.Core.GetSurveyAnswerPage
{
    public class GetSurveyAnswerPageRequest : IRequest
    {
        public Guid SurveyId { get; set; }
        public Guid SurveyAnswerId { get; set; }
        public int PageNumber { get; set; }
    }
}