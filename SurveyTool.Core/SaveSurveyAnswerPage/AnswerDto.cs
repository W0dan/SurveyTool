using System;
using System.Collections.Generic;

namespace SurveyTool.Core.SaveSurveyAnswerPage
{
    public class AnswerDto
    {
        public string Text { get; set; }

        public List<Guid> Parts { get; set; }
    }
}