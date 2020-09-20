using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace week7
{
    class IOGameData
    {
        private string PathQuestions { get; } = Directory.GetCurrentDirectory();
        private string PathSaves { get; }

        public Question[] LoadQuestions()
        {
            //есть находится ли файл рядом с исполняемым файлом
            FileInfo fileQuestions = new FileInfo(PathQuestions + @"\questions.txt");
            if (!fileQuestions.Exists)
            {
                throw new FileNotFoundException();
            }
            Question[] questions;
            //начинаем чтение
            FileStream prepareRead = fileQuestions.OpenRead();

            //узнаем сколько вопросов
            using (StreamReader readQuestions = new StreamReader(prepareRead, Encoding.UTF8))
            {
                string questionCount = readQuestions.ReadToEnd();
                questions = new Question[questionCount.Split("<q>").Length - 1];
                questionCount = null;
            }

            prepareRead = fileQuestions.OpenRead();
            using (StreamReader readQuestions = new StreamReader(prepareRead,Encoding.UTF8))
            {
                //создаем вопросы
                string questionLine="";
                string answerLine = "";
                string answerString = "";
                int counter = 0;

                while (!answerLine.Equals("null"))
                {
                    if (answerLine.Equals("") || !answerLine.Contains("<q>"))
                    {
                        questionLine = readQuestions.ReadLine();
                    }
                    else
                    {
                        questionLine = answerLine;
                        answerLine = "";
                    }

                    while (!answerLine.Equals("null") && !answerLine.Contains("<q>"))
                    {
                        answerLine = readQuestions.ReadLine();
                        if (answerLine == null)
                        {
                            answerLine = "null";
                        }
                        //собираем строку из ответов
                        if (!answerLine.Equals("null") && !answerLine.Contains("<q>"))
                        {
                            answerString += answerLine + "*";
                        }
                        else
                        {
                            string[] answerArray = answerString.Split("*");
                            Answer[] answers = new Answer[answerArray.Length-1];
                            for(int i=0; i< answerArray.Length-1; i++)
                            {
                                if (answerArray[i].Contains("<true>"))
                                {
                                    answers[i] =new CorrectAnswer(answerArray[i].Substring(6));
                                }
                                else if (answerArray[i].Contains("<false>"))
                                {
                                    answers[i] = new WrongAnswer(answerArray[i].Substring(7));
                                }
                            }
                            questions[counter] = new Question(questionLine.Substring(3), answers);
                            counter++;
                            answerString = "";
                        }
                    } 
                }
            }
            return questions;
        }
    }
}
