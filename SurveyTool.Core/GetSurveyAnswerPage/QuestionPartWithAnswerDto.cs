using System;
using System.Collections.Generic;
using SurveyTool.EntityFramework;

namespace SurveyTool.Core.GetSurveyAnswerPage
{
    public class QuestionPartWithAnswerDto
    {
        public Guid QuestionPartId { get; internal set; }
        public QuestionPartAnswerDto Answer { get; internal set; }
        public string Text { get; internal set; }
        public QuestionPartType Type { get; internal set; }
    }
}