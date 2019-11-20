using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyTool.Core.CreateSurveyAnswer
{
    public class CreateSurveyAnswerCommand : ICommand
    {
        public Guid SurveyId { get; set; }
    }
}
