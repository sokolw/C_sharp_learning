using System;
using System.Collections.Generic;
using System.Text;

namespace Blink
{
    class MorseCode
    {
        public Dictionary<string, string> RuMorseCode { get; private set; }

        public MorseCode()
        {
            RuMorseCode = new Dictionary<string, string>();
            RuMorseCode.Add("А", "·−");
            RuMorseCode.Add("Б", "−···");
            RuMorseCode.Add("В", "·−−");
            RuMorseCode.Add("Г", "−−·");
            RuMorseCode.Add("Д", "−··");
            RuMorseCode.Add("Е", "·");
            RuMorseCode.Add("Ё", "·");
            RuMorseCode.Add("Ж", "···−");
            RuMorseCode.Add("З", "−−··");
            RuMorseCode.Add("И", "··");
            RuMorseCode.Add("Й", "·−−−");
            RuMorseCode.Add("К", "−·−");
            RuMorseCode.Add("Л", "·−··");
            RuMorseCode.Add("М", "−−");
            RuMorseCode.Add("Н", "−·");
            RuMorseCode.Add("О", "−−−");
            RuMorseCode.Add("П", "·−−·");
            RuMorseCode.Add("Р", "·−·");
            RuMorseCode.Add("С", "···");
            RuMorseCode.Add("Т", "−"); 
            RuMorseCode.Add("У", "··−");
            RuMorseCode.Add("Ф", "··−·");
            RuMorseCode.Add("Х", "····");
            RuMorseCode.Add("Ц", "−·−·");
            RuMorseCode.Add("Ч", "−−−·");
            RuMorseCode.Add("Ш", "−−−−");
            RuMorseCode.Add("Щ", "−−·−");
            RuMorseCode.Add("Ъ", "−−·−−");
            RuMorseCode.Add("Ы", "−·−−");
            RuMorseCode.Add("Ь", "−··−");
            RuMorseCode.Add("Э", "··−··");
            RuMorseCode.Add("Ю", "··−−");
            RuMorseCode.Add("Я", "·−·−");
            RuMorseCode.Add("1", "·−−−−");
            RuMorseCode.Add("2", "··−−−");
            RuMorseCode.Add("3", "···−−");
            RuMorseCode.Add("4", "····−");
            RuMorseCode.Add("5", "·····");
            RuMorseCode.Add("6", "−····");
            RuMorseCode.Add("7", "−−···");
            RuMorseCode.Add("8", "−−−··");
            RuMorseCode.Add("9", "−−−−·");
            RuMorseCode.Add("0", "−−−−−");
        }
    }
}
