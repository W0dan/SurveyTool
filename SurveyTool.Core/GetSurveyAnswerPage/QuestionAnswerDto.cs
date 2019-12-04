using System;

namespace SurveyTool.Core.GetSurveyAnswerPage
{
    public class QuestionAnswerDto
    {
        public Guid AnswerId { get; internal set; }
        public string Text { get; internal set; }
    }
}