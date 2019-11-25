using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyTool.Core.GetSurveyAnswerPage
{
    public class QuestionWithAnswerDto
    {
        public Guid Id { get; internal set; }
        public string Title { get; internal set; }
        public string AnswerText { get; internal set; }
        public Guid? AnswerId { get; internal set; }
        internal IEnumerable<QuestionPartWithAnswerDto> QuestionParts { get; set; }
        internal QuestionAnswerDto Answer { get; set; }
    }
}
