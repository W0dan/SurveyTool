using System;
using System.Collections.Generic;

namespace SurveyTool.Core.GetSurveyAnswerPage
{
    internal class QuestionPartWithAnswerDto : QuestionAnswerDto
    {
        public Guid Id { get; internal set; }
        public QuestionPartAnswerDto Answer { get; internal set; }
    }
}