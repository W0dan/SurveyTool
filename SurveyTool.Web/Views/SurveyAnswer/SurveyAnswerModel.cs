using SurveyTool.Core.GetSurveyAnswerPage;
using SurveyTool.Web.Views.Shared;

namespace SurveyTool.Web.Views.SurveyAnswer
{
    public class SurveyAnswerModel : ViewModelBase
    {
        public PageWithQuestionsAndAnswersDto Page { get; set; }
    }
}
