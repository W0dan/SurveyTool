using System;
using System.Collections.Generic;

namespace SurveyTool.EntityFramework
{
    public class Survey
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] LogoImage { get; set; }
        public ICollection<SurveyAnswer> Answers { get; set; } = new List<SurveyAnswer>();
        public ICollection<SurveyPage> Pages { get; set; } = new List<SurveyPage>();
    }
}