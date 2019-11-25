using SurveyTool.Core.GetSurveyAnswerPage;
using SurveyTool.Web.Views.Shared;
using System.Collections.Generic;

namespace SurveyTool.Web.Views.SurveyAnswer
{
    public class SurveyAnswerModel : ViewModelBase
    {
        public List<QuestionWithAnswerDto> Questions { get; set; }
        public int PageNumber { get; internal set; }
    }
}
