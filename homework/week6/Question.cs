﻿using System;
using System.Collections.Generic;
using System.Text;

namespace week6
{
    class Question
    {
        public string QuestionText { get; private set; }
        public Answer[] Answers { get; private set; }

        public Question(string questionText, Answer[] answers)
        {
            QuestionText = questionText;
            Answers = answers;
        }
    }
}
