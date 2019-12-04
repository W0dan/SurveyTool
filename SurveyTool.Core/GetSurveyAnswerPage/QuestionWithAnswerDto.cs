using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyTool.Core.GetSurveyAnswerPage
{
    public class QuestionWithAnswerDto
    {
        public Guid QuestionId { get; internal set; }
        public string Title { get; internal set; }
        //public string AnswerText { get; internal set; }
        //public Guid? AnswerId { get; internal set; }
        public IEnumerable<QuestionPartWithAnswerDto> QuestionParts { get; internal set; }
        public QuestionAnswerDto Answer { get; internal set; }
    }
}
