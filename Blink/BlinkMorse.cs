using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Blink
{
    class BlinkMorse
    {
        private Collection<Morse> visualMorseCode;
        private MorseTranslator morseTranslator;
        public BlinkMorse()
        {
            morseTranslator = new MorseTranslator();
        }

        public void Start()
        {
            string translateToMorse = "Привет как дела";

            visualMorseCode = morseTranslator.Translate(translateToMorse);
            ShowMorseCode();
        }

        private void ShowMorseCode()
        {
            foreach (Morse item in visualMorseCode)
            {
                item.SendMessage();
            }
        }
    }
}
