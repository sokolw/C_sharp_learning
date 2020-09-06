using System;
using System.Collections.Generic;
using System.Text;

namespace week6
{
    abstract class Answer
    {
        public string AnswerText;

        public Answer(string answerText)
        {
            AnswerText = answerText;
        }
    }
}
