using System;
using System.Collections.Generic;
using System.Text;

namespace week7
{
    class User
    {
        public string Name { get; private set; }
        public Score Score { get; private set; }

        public User(string name)
        {
            Name = name;
            Score = new Score(0);
        }

        public void Choose(Answer answer)
        {
            if (answer is CorrectAnswer)
            {
                Score.Multiply();
                Console.WriteLine($"Это праавильный ответ! На счету: {Score.Number} BYN.");
            }
            else
            {
                Console.WriteLine("Вы проиграли");
                Game.GameOver();
            }
        }
    }
}
