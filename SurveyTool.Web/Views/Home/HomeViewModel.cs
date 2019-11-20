using SurveyTool.Core.ListSurveys;
using SurveyTool.Web.Views.Shared;
using System.Collections.Generic;

namespace SurveyTool.Web.Views.Home
{
    public class HomeViewModel : ViewModelBase
    {
        public List<SurveyDto> Surveys { get; set; }
    }
}
