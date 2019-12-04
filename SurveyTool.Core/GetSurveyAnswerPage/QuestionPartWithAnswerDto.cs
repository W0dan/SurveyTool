using System;
using System.Collections.Generic;

namespace SurveyTool.Core.GetSurveyAnswerPage
{
    public class QuestionPartWithAnswerDto
    {
        public Guid QuestionPartId { get; internal set; }
        public QuestionPartAnswerDto Answer { get; internal set; }
        public string Text { get; internal set; }
    }
}