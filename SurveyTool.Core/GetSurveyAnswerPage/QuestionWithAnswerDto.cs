using System;
using System.Collections.Generic;
using System.Text;
using SurveyTool.EntityFramework;

namespace SurveyTool.Core.GetSurveyAnswerPage
{
    public class QuestionWithAnswerDto
    {
        public Guid QuestionId { get; internal set; }
        public string Title { get; internal set; }
        public IEnumerable<QuestionPartWithAnswerDto> QuestionParts { get; internal set; }
        public QuestionAnswerDto Answer { get; internal set; }
        public QuestionType Type { get; internal set; }
        public bool Mandatory { get; internal set; }
    }
}
