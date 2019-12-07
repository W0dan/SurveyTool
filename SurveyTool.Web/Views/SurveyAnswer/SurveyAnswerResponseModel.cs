using SurveyTool.Core.SaveSurveyAnswerPage;
using System;
using System.Collections.Generic;

namespace SurveyTool.Web.Views.SurveyAnswer
{
    public class SurveyAnswerResponseModel
    {
        public Guid Id { get; set; }
        public List<QuestionAnswerDto> Questions { get; set; }
        public int PageNumber { get; set; }

        public string Next { get; set; }
        public string Previous { get; set; }
    }
}
