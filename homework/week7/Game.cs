using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace week7
{
    class Game
    {
        private Question[] Questions { get; set; }
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
            if (ChooseGame())
            {
                New(0);
            }
            else
            {
                New(Load());
            }
        }

        private void RulesOfGame()
        {
            Console.WriteLine("Правила игры \"Кто хочет стать миллионером\":\n\r\n\rЭта игра подразумевает серию вопросов, \n\r" +
                "в которой правильный ответ на каждый следующий вопрос удваивает количество денег, полученных игроком. \n\r" +
                "Первй правильный ответ приносит 100BYN. Каждый вопрос подразумевает наличие 4х вариантов ответа.\n\r" +
                "Один из которых является верным.\n\r\n\r" +
                "Всего 10 вопросов glhf)\n\r\n\r" +
                "Для ответа на вопрос вводить цифру в диапазоне 1-4 .\n\r\n\r"
                );
        }

        private void CreateUser()
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

        private void PrintQuestion(int i)
        {
            Console.WriteLine($"Ваш {i + 1}-ый вопрос:\n\r\n\r{Questions[i].QuestionText}\n\r" +
                    $"Варианты ответа:\n\r");

            for (int a = 0; a < Questions[i].Answers.Length; a++)
                Console.WriteLine($"{a + 1}. {Questions[i].Answers[a].AnswerText};\n\r");
        }

        private int InputNumberOfAnswer()
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

        private int ContinueGame(int i)
        {
            Console.WriteLine("Продолжить игру или забрать деньги? Введите: Игра|Деньги. Для сохранения игры введите: save или s");
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
            else if (choose.Equals("save", StringComparison.OrdinalIgnoreCase)|| choose.Equals("s", StringComparison.OrdinalIgnoreCase))
            {
                Save(i);
            }
            return ContinueGame(i);
        }

        private void GameWin()
        {
            Console.WriteLine($"Вы победили ответив на все вопросы. Ваш выйгрыш составил: {User.Score.Number} BYN.");
        }

        private void New(int stage)
        {
            if (stage == 0)
            {
                RulesOfGame();
                CreateUser();
            }
            else
            {
                Console.WriteLine($"Привет: {User.Name}! Твой счет: {User.Score.Number}. Номер пройденного вопроса: {stage+1}.");
                stage++;
            }

            for (; stage < Questions.Length; stage++)
            {
                PrintQuestion(stage);

                User.Choose(Questions[stage].Answers[InputNumberOfAnswer()]);
                if (EndGame)
                {
                    stage = Questions.Length;
                }
                else if (stage == Questions.Length - 1)
                {
                    GameWin();
                }
                else if (!EndGame)
                {
                    stage = ContinueGame(stage);
                }
            }
        }

        private void Save(int stage)
        {
            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments,0) + "/Millionaires";
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            if (!directory.Exists)
            {
                directory.Create();
            }

            directoryPath += "/" + User.Name;
            if (directory.GetDirectories(User.Name).Length == 0)
            {  
                directory = new DirectoryInfo(directoryPath);
                directory.Create();
            }

            Console.WriteLine("Введите имя сохранения от 4 до 32 символов: ");
            FileInfo saveFileInfo = new FileInfo(directoryPath + "/" + InputSaveOrLoadSymbols() + ".txt");
            if (saveFileInfo.Exists)
            {
                Console.WriteLine("Сохранение с таким названием уже существует, попробуйте снова. Введите: save или s");
                return;
            }
            FileStream saveFileStream = saveFileInfo.OpenWrite();
            using (StreamWriter saveStreamWriter = new StreamWriter(saveFileStream,Encoding.UTF8))
            {
                saveStreamWriter.Write($"{User.Name}\n{User.Score.Number}\n{stage}");
            }
        }

        private int Load()
        {
            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, 0) + "/Millionaires";
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            if (!directory.Exists)
            {
                Console.WriteLine("Вы ещё ни разу не играли. Создание новой игры...");
                return 0;
            }
            //смотрим папки
            Console.WriteLine("Выберите номер папки с сохранениями: ");
            DirectoryInfo[] directoryArray = directory.GetDirectories();
            for(int i = 0; i< directoryArray.Length; i++)
            {
                Console.WriteLine($"{i+1}. {directoryArray[i].Name}");
            }
            //смотрим файлы
            directoryPath += "/" + directoryArray[InputNumberOfRange(directoryArray.Length)].Name;
            Console.WriteLine("Выберите номер номер файла с сохранением: ");
            directory = new DirectoryInfo(directoryPath);
            FileInfo[] fileArray = directory.GetFiles();
            for (int i = 0; i < fileArray.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {fileArray[i].Name}");
            }
            //читаем файл
            directoryPath+= "/" + fileArray[InputNumberOfRange(fileArray.Length)].Name;
            FileInfo loadFileInfo = new FileInfo(directoryPath);
            FileStream loadFileStream = loadFileInfo.OpenRead();
            using (StreamReader loadStreamReader = new StreamReader(loadFileStream, Encoding.UTF8))
            {
                string data = loadStreamReader.ReadToEnd();
                string[] fields = data.Split("\n");
                User = new User(fields[0],int.Parse(fields[1]));
                return int.Parse(fields[2]);
            }
        }

        private bool ChooseGame()
        {
            Console.WriteLine("Игра \"Кто хочет стать миллионером\"");
            Console.WriteLine("Начать новую игру или загрузить? Введите: new или n для новой игры|load или l для загрузки.");
            string choose = Console.ReadLine();
            if (choose.Equals("new", StringComparison.OrdinalIgnoreCase) || choose.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            } else if (choose.Equals("load", StringComparison.OrdinalIgnoreCase) || choose.Equals("l", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            return ChooseGame();
        }

        private string InputSaveOrLoadSymbols()
        {
            string name = Console.ReadLine();
            if (name.Length > 3 && name.Length < 33)
            {
                return name;
            }
            Console.WriteLine("Попробуй ещё раз.");
            return InputSaveOrLoadSymbols();
        }

        private int InputNumberOfRange(int range)
        {
            int number = 0;
            if (int.TryParse(Console.ReadLine(), out number) && number >= 1 && number <= range)
            {
                return number - 1;
            }
            Console.WriteLine($"Введите число от 1 до {range}");
            return InputNumberOfRange(range);
        }
    }
}
