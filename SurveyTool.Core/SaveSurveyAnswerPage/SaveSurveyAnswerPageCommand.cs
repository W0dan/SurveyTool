using System;
using System.Collections.Generic;

namespace SurveyTool.Core.SaveSurveyAnswerPage
{

    public class SaveSurveyAnswerPageCommand : ICommand
    {
        public Guid Id { get; set; }
        public int PageNumber { get; set; }
        public List<QuestionAnswerDto> QuestionsWithAnswers { get; set; }
    }
}
