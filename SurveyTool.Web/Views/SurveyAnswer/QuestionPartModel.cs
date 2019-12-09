using System;
using SurveyTool.EntityFramework;

namespace SurveyTool.Web.Views.SurveyAnswer
{
    public class QuestionPartModel
    {
        public Guid QuestionPartId { get; set; }
        public string Text { get; set; }
        public Guid? QuestionPartAnswerId { get; set; }
        public QuestionPartType Type { get; set; }
    }
}