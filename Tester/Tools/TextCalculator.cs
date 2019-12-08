using System.Linq;

//Performs calculation of lines, words and symbols in text 

namespace Tester.Tools
{
    internal static class TextCalculator
    {
        private static readonly char[] WordDelimeters = { ' ', '.', ',', '?', '!', '\r'};


    public static void Calculate(string text, out int lines, out int words, out int symbols) {
            lines = 0;
            words = 0;
            symbols = 0;
            bool isWord = false;
            foreach (var ch in text)
            {
                if (ch == '\n')
                {
                    lines++;
                    if (isWord)
                    {
                        words++;
                        isWord = false;
                    }
                }
                else if (WordDelimeters.Contains(ch))
                {
                    words++;
                    if (ch != '\r'&& ch!=' ')
                        symbols++;
                }
                else {
                    isWord = true;
                    symbols++;
                }
            }
            if (isWord)
            {
                words++;
                if (lines == 0)
                    lines++;
            }
        }

    }
}
