using System;

namespace SurveyTool.EntityFramework
{
    public class QuestionPartAnswer
    {
        public Guid Id { get; set; }
        public QuestionPart QuestionPart { get; set; }
    }
}