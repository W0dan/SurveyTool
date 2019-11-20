using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyTool.EntityFramework
{
    public class SurveyPage
    {
        public Guid Id { get; internal set; }
        public ICollection<Question> Questions { get; internal set; }
    }
}
