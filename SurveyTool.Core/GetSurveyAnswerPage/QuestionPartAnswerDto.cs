using System;

namespace SurveyTool.Core.GetSurveyAnswerPage
{
    public class QuestionPartAnswerDto
    {
        public Guid? QuestionPartAnswerId { get; internal set; }
        public string Text { get; internal set; }
    }
}