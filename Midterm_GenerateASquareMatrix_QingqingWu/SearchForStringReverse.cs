using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Midterm_GenerateASquareMatrix_QingqingWu
{
    public class SearchForStringReverse : SearchForString
    {

        // Private fields declaration
        private char[,] charInGridArray;
        private List<string> searchForString;
        private string a = "";
        private string result = "";
        private int length;

        // Constructor with parameters 
        // also inherits the member from the base class SearchForString
        public SearchForStringReverse(int length, char[,] charInGridArray, List<string> searchForString, string searchString)
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
            for (int row = length - 1; row >= 0; row--)
            {
                int tempRowForNewCharArray = 0;
                for (int column = length - 1; column >= 0; column--)
                {
                    tempCharArray[tempRowForNewCharArray] = charInGridArray[row, column];
                    tempRowForNewCharArray++;
                }
                a = new string(tempCharArray);
                Console.WriteLine("Reverse Horizontal Strings is: " + a + "\n");
                searchForString.Add(a);
                tempCharArray = new char[length];
                a = "";
            }
            tempCharArray = new char[length];
            a = "";

            // Vertical
            for (int row = length - 1; row >= 0; row--)
            {
                int tempRowForNewCharArray = 0;
                for (int column = length - 1; column >= 0; column--)
                {
                    tempCharArray[tempRowForNewCharArray] = charInGridArray[row, column];
                    tempRowForNewCharArray++;
                }
                a = new string(tempCharArray);
                Console.WriteLine("Reverse Vertical Strings is: " + a + "\n");
                searchForString.Add(a);
                tempCharArray = new char[length];
                a = "";
            }
            tempCharArray = new char[length];
            a = "";

            // Diagonals
            /*
             * 44 33 22 11 00
             */
            int tempRowForNewCharArrayDiagonals = 0;
            for (int row = length - 1; row >= 0; row--)
            {
                for (int column = length - 1; column >= 0; column--)
                {
                    if (row == column)
                    {
                        tempCharArray[tempRowForNewCharArrayDiagonals] = charInGridArray[row, column];
                        tempRowForNewCharArrayDiagonals++;
                    }
                }
            }
            a = new string(tempCharArray);
            Console.WriteLine("Reverse Diagonals Strings is: " + a + "\n");
            searchForString.Add(a);
            tempCharArray = new char[length];
            a = "";

            // Upper Diagonals
            /*
             * 34 23 12 01
             * 24 13 02
             * 14 03
             * 04
             */
            int tempColumn1 = 0;
            for (int row = length - 2; row > 0; row--)
            {
                int tempRow1 = row;
                int tempRowForNewCharArray = 0;
                for (int column = length - 1; column > tempColumn1; column--)
                {
                    tempCharArray[tempRowForNewCharArray] = charInGridArray[tempRow1, column];
                    tempRowForNewCharArray++;
                    tempRow1--;

                }
                a = new string(tempCharArray);
                searchForString.Add(a);
                tempCharArray = new char[length];
                tempColumn1++;
                a = "";
            }
            tempCharArray = new char[length];
            a = "";

            // Down Diagonals
            /*
             * 43 32 21 10 
             * 42 31 20
             * 41 30
             * 40
             */
            int tempColumn2 = length - 2;
            int tempRow2 = length - 1;
            for (int row = tempRow2; row > 1; row--)
            {
                int tempRowForNewCharArray = 0;
                for (int column = tempColumn2; column >= 0; column--)
                {
                    tempCharArray[tempRowForNewCharArray] = charInGridArray[tempRow2, column];
                    tempRowForNewCharArray++;
                    tempRow2--;
                }
                a = new string(tempCharArray);
                searchForString.Add(a);
                tempCharArray = new char[length];
                tempRow2 = length - 1;
                tempColumn2--;
                a = "";
            }

            // Iterate and check whether each strings that are in reverse contains the string that user wanted to search for or not
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
