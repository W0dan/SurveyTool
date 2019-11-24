using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyTool.Core.GetSurveyAnswerPage
{
    public class PageWithQuestionsAndAnswersDto
    {
        public int PageNumber { get; internal set; }
        public IEnumerable<QuestionWithAnswerDto> Questions { get; internal set; }
    }
}
