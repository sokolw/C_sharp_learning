using System;
using System.Collections.Generic;
using System.Text;

namespace week7
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
