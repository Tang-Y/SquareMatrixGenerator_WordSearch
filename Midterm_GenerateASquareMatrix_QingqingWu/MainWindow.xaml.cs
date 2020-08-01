using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Midterm_GenerateASquareMatrix_QingqingWu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Fields
        int length = 0;
        string searchString = "";
        string result = "Success";
        char[,] charInGridArray;
        List<string> searchForString = new List<string>();
        RandomAlphabetGenerator randomAlphabet;
        Label squareMatrix;
        Label label;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGnerate_Click(object sender, RoutedEventArgs e)
        {
            length = Convert.ToInt32(tbLength.Text); // Get the value from textbox
            charInGridArray = new char[length, length]; // Initialize the char 2-d array
            // Length size valiadation
            if (length < 5)
            {
                MessageBox.Show("You should enter the length greater than 5!", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (length > 35)
            {
                MessageBox.Show("It is recommended to enter the length of square matrix less than 35.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                SquareGrid.Children.Clear();

                // Generate process for alphabets
                randomAlphabet = new RandomAlphabetGenerator();

                // Create Grid Controls programmatically with all properties
                for (int i = 0; i < length; i++)
                {
                    ColumnDefinition column = new ColumnDefinition();
                    RowDefinition row = new RowDefinition();
                    column.Width = new GridLength(1,GridUnitType.Star);
                    row.Height = new GridLength(1, GridUnitType.Star);
                    SquareGrid.ColumnDefinitions.Add(column);
                    SquareGrid.RowDefinitions.Add(row);
                }
                for (int row = 0; row < SquareGrid.RowDefinitions.Count; row++)
                {
                    for (int column = 0; column < SquareGrid.ColumnDefinitions.Count; column++)
                    {
                        squareMatrix = new Label();
                        squareMatrix.SetValue(Grid.RowProperty, row);
                        squareMatrix.SetValue(Grid.ColumnProperty, column);
                        squareMatrix.FontWeight = FontWeights.Bold;
                        squareMatrix.HorizontalAlignment = HorizontalAlignment.Center;
                        squareMatrix.Content = randomAlphabet.RandomAlphabet();
                        SquareGrid.Children.Add(squareMatrix);
                        charInGridArray[row, column] = char.Parse(squareMatrix.Content.ToString());

                    }

                }

                spSearch.Visibility = Visibility.Visible;
            }
        }

        // Reset for game
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            SquareGrid.Children.Clear();
            SquareGrid.RowDefinitions.Clear();
            SquareGrid.ColumnDefinitions.Clear();
            label = new Label();
            label.Content = "???";
            label.FontSize = 50;
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            label.VerticalContentAlignment = VerticalAlignment.Center;
            SquareGrid.Children.Add(label);
            tbLength.Clear();
            tbSearchString.Clear();
        }

        // Main method for word searching
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            searchString = tbSearchString.Text;
            MessageBox.Show("\nSearch String is:" + searchString + "\n");

            // Create new class objects for both two derived classes
            SearchForString[] search =
                {
                new SearchForStringReverse(length, charInGridArray, searchForString, searchString),
                new SearchForStringRegular(length, charInGridArray, searchForString, searchString)
            };

            // Compare the result
            if (result == search[0].compareString())
                MessageBox.Show(result, "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (result == search[1].compareString())
                MessageBox.Show(result, "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Failed - NO MATCHING STRING", "result", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Skin controls
        private void rbLayout1_Clicked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary skin =
             Application.LoadComponent(new Uri("Layout1.xaml", UriKind.Relative)) as ResourceDictionary;
            Resources.MergedDictionaries.Add(skin);
        }

        private void rbLayout12_Clicked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary skin =
               Application.LoadComponent(new Uri("Layout2.xaml", UriKind.Relative)) as ResourceDictionary;
            Resources.MergedDictionaries.Add(skin);
        }
    }
}
