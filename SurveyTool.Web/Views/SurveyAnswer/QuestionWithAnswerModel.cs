using System;
using System.Collections.Generic;
using SurveyTool.EntityFramework;

namespace SurveyTool.Web.Views.SurveyAnswer
{
    public class QuestionWithAnswerModel
    {
        public Guid QuestionId { get; set; }
        public string Title { get; set; }
        public QuestionType Type { get; set; }
        public string Text { get; set; }
        public List<QuestionPartModel> Parts { get; set; }
        public List<Guid> SelectedParts { get; set; }
    }
}