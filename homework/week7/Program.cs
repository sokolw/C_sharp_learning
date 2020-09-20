using System;

namespace week7
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            try
            {
                game.Prepare();
            }
            catch (Exception)
            {
                Console.WriteLine("Файл с вопросам не найден. Поместите его рядом с исполняемым файлом игры. Название файла: questions.txt");
                return;
            }
            game.Start();
        }
    }
}
