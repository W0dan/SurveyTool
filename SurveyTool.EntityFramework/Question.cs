using System;
using System.Collections.Generic;

namespace SurveyTool.EntityFramework
{
    public class Question
    {
        public Guid Id { get; set; }
        public QuestionType Type { get; set; }
        public string Title { get; set; }
        public ICollection<QuestionPart> Parts { get; set; }
    }
}