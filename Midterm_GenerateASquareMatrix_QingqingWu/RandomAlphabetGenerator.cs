using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_GenerateASquareMatrix_QingqingWu
{
    class RandomAlphabetGenerator
    {
        private string chars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private char tempChar;
        private Random rnd = new Random();
        public char RandomAlphabet()
        {
            for (int i = 0; i < chars.Length; i++)
            {
                tempChar = chars[rnd.Next(0, chars.Length)];
            }
            return tempChar;
        }

    }
}
