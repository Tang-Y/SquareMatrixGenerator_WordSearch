using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_GenerateASquareMatrix_QingqingWu
{
    // To provide a common definition that multiple derived classes can share.
    public abstract class SearchForString
    {
        private string searchString;
        public SearchForString(string searchString)
        {
            this.searchString = searchString;
        }

        // Property
        public string SearchString
        {
            get
            {
                return searchString;
            }
            set
            {
                this.searchString = value;
            }
        }

        // To provide a common method that multiple derived classes can share.
        public abstract string compareString();
    }
}
