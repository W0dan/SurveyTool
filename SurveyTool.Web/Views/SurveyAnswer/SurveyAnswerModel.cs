using SurveyTool.Core.GetSurveyAnswerPage;
using SurveyTool.Web.Views.Shared;
using System;
using System.Collections.Generic;

namespace SurveyTool.Web.Views.SurveyAnswer
{
    public class SurveyAnswerModel : ViewModelBase
    {
        public Guid Id { get; set; }
        public List<QuestionWithAnswerModel> Questions { get; set; }
        public int PageNumber { get; set; }

        public string Next { get; set; }
        public string Previous { get; set; }
    }
}
