using System.Collections.Generic;

namespace SurveyTool.Core.ListSurveys
{
    public class ListSurveysResponse
    {
        public List<SurveyDto> Surveys { get; internal set; }
    }
}
