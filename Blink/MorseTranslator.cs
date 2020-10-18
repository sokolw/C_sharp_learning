using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Blink
{
    class MorseTranslator
    {
        private MorseCode morseCode;
        private Collection<Morse> visualMorseCode;
        public MorseTranslator()
        {
            morseCode = new MorseCode();
        }

        public Collection<Morse> Translate(string msg)
        {
            visualMorseCode = new Collection<Morse>();
            char[] symbols = msg.ToCharArray();

            foreach (char symbol in symbols)
            {
                if(!symbol.Equals(' '))
                {
                    Interpitator(morseCode.RuMorseCode[symbol.ToString().ToUpper()]);
                }
                else
                {
                    visualMorseCode.Add(new WordDelimiter());
                }
            }
            return visualMorseCode;
        }

        private void Interpitator(string code)
        {
            char[] symbols = code.ToCharArray();
            foreach (char symbol in symbols)
            {
                if (symbol.Equals('·'))
                {
                    visualMorseCode.Add(new Dot());
                } 
                else if (symbol.Equals('−'))
                {
                    visualMorseCode.Add(new Dash());
                }
            }
        }
    }
}
