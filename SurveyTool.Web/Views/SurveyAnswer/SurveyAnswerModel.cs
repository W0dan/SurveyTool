using SurveyTool.Core.GetSurveyAnswerPage;
using SurveyTool.Web.Views.Shared;
using System;
using System.Collections.Generic;

namespace SurveyTool.Web.Views.SurveyAnswer
{
    public class SurveyAnswerModel : ViewModelBase
    {
        public Guid Id { get; set; }
        public List<QuestionWithAnswerDto> Questions { get; set; }
        public int PageNumber { get; internal set; }
    }
}
