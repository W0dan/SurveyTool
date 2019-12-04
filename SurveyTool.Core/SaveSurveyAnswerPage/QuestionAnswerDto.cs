using System;

namespace SurveyTool.Core.SaveSurveyAnswerPage
{
    public class QuestionAnswerDto
    {
        public AnswerDto Answer { get; set; }
        public Guid QuestionId { get; set; }
    }
}