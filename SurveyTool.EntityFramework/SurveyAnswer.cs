using System;
using System.Collections.Generic;

namespace SurveyTool.EntityFramework
{
    public class SurveyAnswer
    {
        public Guid Id { get; set; }
        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }
        public Survey Survey { get; internal set; }
    }
}