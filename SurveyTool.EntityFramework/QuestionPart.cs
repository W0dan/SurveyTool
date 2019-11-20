using System;

namespace SurveyTool.EntityFramework
{
    public class QuestionPart
    {
        public Guid Id { get; internal set; }
        public QuestionPartType Type { get; set; }
    }
}