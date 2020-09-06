using System;

namespace week4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Правила игры \"Кто хочет стать миллионером\":\n\r\n\rЭта игра подразумевает серию вопросов, \n\r" +
                "в которой правильный ответ на каждый следующий вопрос удваивает количество денег, полученных игроком. \n\r" +
                "Первй правильный ответ приносит 100BYN. Каждый вопрос подразумевает наличие 4х вариантов ответа.\n\r" +
                "Один из которых является верным.\n\r\n\r" +
                "Всего 10 вопросов glhf)\n\r\n\r" +
                "Для ответа на вопрос вводить цифру в диапазоне 1-4 .\n\r\n\r" +
                "Введите ваше имя :");
            string name;
            do
            {
                name = Console.ReadLine();
            } while (name=="");
            User user = new User(name);
            user.StartGame();
        }
    }
    class User
    {
        public string Name { get; private set; }
        public int Money { get; private set; } = 0;
        private Question[] Questions { get; set; }


        public User(string name)
        {
            Name = name;
        }

        public void StartGame()
        {
            Questions = InitQuestions();

            for(int i=0; i< Questions.Length; i++)
            {
                bool check;
                int answer;
                string continueGame;
                Console.WriteLine($"Ваш {i + 1}-ый вопрос:\n\r\n\r{Questions[i].Name}\n\r" +
                    $"Варианты ответа:\n\r");

                for (int k=0; k< Questions[i].AnswerOptions.Length;k++)
                    Console.WriteLine($"{k+1}. {Questions[i].AnswerOptions[k]};\n\r");

                do
                {
                    check = !int.TryParse(Console.ReadLine(), out answer);
                    if (answer <= 4 && answer >= 1)
                    {
                        check = false;
                    }
                    else
                    {
                        check = true;
                    }
                } while (check);

                if (Questions[i].IsTrue(answer-1))
                {
                    if (Money == 0) Money = 100;
                    else Money *= 2;
                    Console.WriteLine($"Это праавильный ответ! На счету: {Money} BYN.");
                    //выйгрыш
                    if (i == 9)
                    {
                        Console.WriteLine($"Вы победили ответив на все вопросы. Ваш выйгрыш составил: {Money} BYN.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Вы проиграли");
                    i = Questions.Length;
                    continue;
                }
                
                Console.WriteLine("Продолжить игру или забрать деньги? Введите: Игра|Деньги");
                
                do
                {
                    continueGame = Console.ReadLine();
                    if (continueGame.Equals("игра", StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine("Игра продолжается!");
                    else if(continueGame.Equals("деньги", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Конец игры ваш выйгрыш составил: {Money} BYN.");
                        i = Questions.Length;
                    }
                        
                }
                while (!continueGame.Equals("игра", StringComparison.OrdinalIgnoreCase) && !continueGame.Equals("деньги", StringComparison.OrdinalIgnoreCase));
            }

        }

        private Question[] InitQuestions()
        {
            Question[] initQuestions = new Question[10] { 
                new Question("Как зовут актера который играл Гермиону Грейнджер?", new string[] {"Эмма Уотсон", "Лайонел Уигрэм", "Дж. К. Роулинг", "Rotten Tomatoes"}, 0),
                new Question("Существует ли в природе перелетные звери?", new string[] { "Да, существуют", "Нет", "Я гладиолус", "Существуют в параллельной вселенной"}, 0),
                new Question("Кто из президентов США написал свой собственный рассказ про Шерлока Холмса?", new string[] { "Франклин Рузвельт", "Джон Кеннеди", "Рональд Рейган", "Барак Обама"}, 0),
                new Question("Что в Российской империи было вещевым эквивалентом денег?", new string[] { "Шкуры пушных зверей", "Крупный рогатый скот", "Табак", "Женские серьги"}, 0),
                new Question("Что из этого является видом ткани?", new string[] { "Креп-жоржет", "Креп-лизет", "Креп-мюзет", "Креп-жаннет"}, 0),
                new Question("Какую икру больше всего любил Джеймс Бонд?", new string[] { "Белужью", "Осетровую", "Севрюжью", "Стерляжью"}, 0),
                new Question("У кого из \"вампиров\" кровь пьют только самки?", new string[] { "Комары", "Летучие мыши", "Пиявки", "Клещи"}, 0),
                new Question("Какого зайца НЕ бывает?", new string[] { "Чувак", "Тумак", "Русак", "Беляк"}, 0),
                new Question("В какое море впадает Жёлтая река?", new string[] { "Жёлтое море", "Ионическое море", "Чёрное море", "Каспийское море"}, 0),
                new Question("Какого города нет в Казахстане?", new string[] { "Самарканд", "Шымкент", "Караганда", "Пвлодар"}, 0)
            };
            return initQuestions;
        }
    }

    class Question
    {
        public string Name { get; private set; }
        public string[] AnswerOptions { get; private set; }
        private int TrueAnswer {  get;  set; }

        public Question(string name, string[] answerOptions, int trueAnswer)
        {
            Name = name;
            AnswerOptions = answerOptions;
            TrueAnswer = trueAnswer;
        }
        public bool IsTrue(int variant)
        {
            if (variant == TrueAnswer)
                return true;
            else
                return false;
        }
    }
}
