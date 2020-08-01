using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Midterm_GenerateASquareMatrix_QingqingWu
{
    class SearchForStringRegular : SearchForString
    {

        // Private fields declaration
        private char[,] charInGridArray;
        private List<string> searchForString;
        private string a = "";
        private string result = "";
        private int length;

        // Constructor with parameters 
        // also inherits the member from the base class SearchForString
        public SearchForStringRegular(int length, char[,] charInGridArray, List<string> searchForString, string searchString)
            : base(searchString)
        {
            this.charInGridArray = charInGridArray;
            this.length = length;
            this.searchForString = searchForString;
        }

        // Override method from the abstract class SearchForString
        public override string compareString()
        {
            char[] tempCharArray = new char[length];

            // Horizontal
            for (int row = 0; row < length; row++)
            {
                for (int column = 0; column < length; column++)
                {
                    tempCharArray[column] = charInGridArray[row, column];
                }
                a = new string(tempCharArray);
                searchForString.Add(a);
                tempCharArray = new char[length];
                a = "";
            }
            tempCharArray = new char[length];
            a = "";

            // Vertical
            for (int column = 0; column < length; column++)
            {
                for (int row = 0; row < length; row++)
                {
                    tempCharArray[row] = charInGridArray[row, column];
                }
                a = new string(tempCharArray);
                searchForString.Add(a);
                tempCharArray = new char[length];
                a = "";
            }
            tempCharArray = new char[length];
            a = "";

            // Diagonals
            /*
             * 00 11 22 33 44
             */
            for (int row = 0; row < length; row++)
            {
                for (int column = 0; column < length; column++)
                {
                    if(row == column)
                    {
                        tempCharArray[column] = charInGridArray[row, column];
                    }
                }
            }
            a = new string(tempCharArray);
            searchForString.Add(a);
            tempCharArray = new char[length];
            a = "";

            // Upper Diagonals
            /*
             * 01 12 23 34 
             * 02 13 24
             * 03 14
             * 04
             */
            for (int row = 0; row < length - 2; row++)
            {
                int tempRow = 0; // temporary row-- since the char will be gone through always from row at 0
                for (int column = row + 1; column < length; column++)
                {
                    tempCharArray[tempRow] = charInGridArray[tempRow, column];
                    tempRow++;
                }
                a = new string(tempCharArray);
                searchForString.Add(a);
                tempCharArray = new char[length];
                a = "";
            }
            tempCharArray = new char[length];
            a = "";


            // Down Diagonals
            /*
             * 10 21 32 43
             * 20 31 42
             * 30 41
             * 40
             */
            int tempLengthDown = length;
            for (int side = 1; side < length - 1; side++)
            { 
                int row = side;
                for (int column = 0; column < tempLengthDown - 1; column++)
                {
                    tempCharArray[row] = charInGridArray[row, column];
                    row++;
                }
                a = new string(tempCharArray);
                searchForString.Add(a);
                tempLengthDown--;
                tempCharArray = new char[length];
                a = "";
            }

            // Iterate and check whether each strings contains the string that user wanted to search for or not
            // If contains, return result with success info.
            foreach (string temp in searchForString)
            {
                if (temp.Contains(base.SearchString))
                {
                    result = "Success";
                }
            }

            return result;
        }

    }
}
