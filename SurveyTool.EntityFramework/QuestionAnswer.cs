using System;
using System.Collections.Generic;

namespace SurveyTool.EntityFramework
{
    public class QuestionAnswer
    {
        public Guid Id { get; internal set; }
        public ICollection<QuestionPartAnswer> QuestionPartAnswers { get; set; }
        public Question Question { get; internal set; }
        public string AnswerText { get; set; }
        public SurveyAnswer SurveyAnswer { get; internal set; }
    }
}