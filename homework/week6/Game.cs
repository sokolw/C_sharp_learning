using System;
using System.Collections.Generic;
using System.Text;

namespace week6
{
    class Game
    {
        public Question[] Questions { get; private set; }
        public User User { get; private set; }
        public static bool EndGame { get; private set; } = false;

        public void Prepare()
        {
            Questions = new Question[] {
                new Question("Как зовут актера который играл Гермиону Грейнджер?", new Answer[] {
                    new CorrectAnswer("Эмма Уотсон"),
                    new WrongAnswer("Лайонел Уигрэм"),
                    new WrongAnswer("Дж. К. Роулинг"),
                    new WrongAnswer("Rotten Tomatoes")}),
                new Question("Существует ли в природе перелетные звери?", new Answer[] {
                    new CorrectAnswer("Да, существуют"),
                    new WrongAnswer("Нет"), 
                    new WrongAnswer("Я гладиолус"), 
                    new WrongAnswer("Существуют в параллельной вселенной")}),
                new Question("Кто из президентов США написал свой собственный рассказ про Шерлока Холмса?", new Answer[] {
                    new CorrectAnswer("Франклин Рузвельт"), 
                    new WrongAnswer("Джон Кеннеди"), 
                    new WrongAnswer("Рональд Рейган"), 
                    new WrongAnswer("Барак Обама")}),
                new Question("Что в Российской империи было вещевым эквивалентом денег?", new Answer[] {
                    new CorrectAnswer("Шкуры пушных зверей"),
                    new WrongAnswer("Крупный рогатый скот"),
                    new WrongAnswer("Табак"),
                    new WrongAnswer("Женские серьги")}),
                new Question("Что из этого является видом ткани?", new Answer[] {
                    new CorrectAnswer("Креп-жоржет"),
                    new WrongAnswer("Креп-лизет"),
                    new WrongAnswer("Креп-мюзет"),
                    new WrongAnswer("Креп-жаннет")}),
                new Question("Какую икру больше всего любил Джеймс Бонд?", new Answer[] {
                    new CorrectAnswer("Белужью"),
                    new WrongAnswer("Осетровую"),
                    new WrongAnswer("Севрюжью"),
                    new WrongAnswer("Стерляжью")}),
                new Question("У кого из \"вампиров\" кровь пьют только самки?", new Answer[] {
                    new CorrectAnswer("Комары"),
                    new WrongAnswer("Летучие мыши"),
                    new WrongAnswer("Пиявки"),
                    new WrongAnswer("Клещи")}),
                new Question("Какого зайца НЕ бывает?", new Answer[] {
                    new CorrectAnswer("Чувак"),
                    new WrongAnswer("Тумак"),
                    new WrongAnswer("Русак"),
                    new WrongAnswer("Беляк")}),
                new Question("В какое море впадает Жёлтая река?", new Answer[] {
                    new CorrectAnswer("Жёлтое море"),
                    new WrongAnswer("Ионическое море"),
                    new WrongAnswer("Чёрное море"),
                    new WrongAnswer("Каспийское море")}),
                new Question("Какого города нет в Казахстане?", new Answer[] {
                    new CorrectAnswer("Самарканд"),
                    new WrongAnswer("Шымкент"),
                    new WrongAnswer("Караганда"),
                    new WrongAnswer("Пвлодар")})
            };
        }

        public void Start()
        {
            RulesOfGame();
            CreateUser();

            for (int i = 0; i < Questions.Length; i++)
            {
                PrintQuestion(i);

                User.Choose(Questions[i].Answers[InputNumberOfAnswer()]);
                if (EndGame) i = Questions.Length;

                if(i == Questions.Length - 1)
                {
                    GameWin();
                }
                else if(!EndGame)
                {
                    i = ContinueGame(i);
                }
            }

        }

        public void RulesOfGame()
        {
            Console.WriteLine("Правила игры \"Кто хочет стать миллионером\":\n\r\n\rЭта игра подразумевает серию вопросов, \n\r" +
                "в которой правильный ответ на каждый следующий вопрос удваивает количество денег, полученных игроком. \n\r" +
                "Первй правильный ответ приносит 100BYN. Каждый вопрос подразумевает наличие 4х вариантов ответа.\n\r" +
                "Один из которых является верным.\n\r\n\r" +
                "Всего 10 вопросов glhf)\n\r\n\r" +
                "Для ответа на вопрос вводить цифру в диапазоне 1-4 .\n\r\n\r"
                );
        }

        public void CreateUser()
        {
            Console.WriteLine("Введите ваше имя (4-32 символа):");
            string name = Console.ReadLine();
            if (name.Length > 3 && name.Length < 33)
            {
                User = new User(name);
                return;
            }
            CreateUser();
        }

        public void PrintQuestion(int i)
        {
            Console.WriteLine($"Ваш {i + 1}-ый вопрос:\n\r\n\r{Questions[i].QuestionText}\n\r" +
                    $"Варианты ответа:\n\r");

            for (int a = 0; a < Questions[i].Answers.Length; a++)
                Console.WriteLine($"{a + 1}. {Questions[i].Answers[a].AnswerText};\n\r");
        }

        public int InputNumberOfAnswer()
        {
            int number = 0;
            if (int.TryParse(Console.ReadLine(), out number) && number >=1 && number <= 4)
            {
                return number-1;
            }
            Console.WriteLine("Введите число от 1 до 4");
            return InputNumberOfAnswer();
        }

        public static void GameOver()
        {
            EndGame = true;
        }

        public int ContinueGame(int i)
        {
            Console.WriteLine("Продолжить игру или забрать деньги? Введите: Игра|Деньги");
            string choose = Console.ReadLine();
            if (choose.Equals("игра", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Игра продолжается!");
                return i;
            }
            else if (choose.Equals("деньги", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Конец игры ваш выйгрыш составил: {User.Score.Number} BYN.");
                return Questions.Length;
            }
            return ContinueGame(i);
        }

        public void GameWin()
        {
            Console.WriteLine($"Вы победили ответив на все вопросы. Ваш выйгрыш составил: {User.Score.Number} BYN.");
        }
    }
}
