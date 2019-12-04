﻿using System;

namespace SurveyTool.EntityFramework
{
    public class QuestionPartAnswer
    {
        public Guid Id { get; set; }
        public QuestionPart QuestionPart { get; set; }
        public QuestionAnswer QuestionAnswer { get; set; }
        public string Text { get; set; }
    }
}