using System;
using System.Collections.Generic;

namespace SurveyTool.EntityFramework
{
    public class QuestionPart
    {
        public Guid Id { get; internal set; }
        public QuestionPartType Type { get; set; }
        public int Order { get; set; }
        public string Text { get; set; }
        public Question Question { get; internal set; }
        public ICollection<QuestionPartAnswer> QuestionPartAnswers { get; internal set; }
    }
}