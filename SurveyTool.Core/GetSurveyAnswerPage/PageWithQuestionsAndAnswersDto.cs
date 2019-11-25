using System.Collections.Generic;

namespace SurveyTool.Core.GetSurveyAnswerPage
{
    public class PageWithQuestionsAndAnswersDto
    {
        public int PageNumber { get; internal set; }
        public IEnumerable<QuestionWithAnswerDto> Questions { get; internal set; }
    }
}
