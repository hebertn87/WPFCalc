using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace HW3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        //Takes a button event and puts it to string in input box
        private void ButtonEvent(object sender, RoutedEventArgs e)
        {
            Button b = (Button) sender;
            inputbox.Text += b.Content.ToString();
        }

        //This event happens when the user hits the enter button
        private void EnterEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                ParseInputBox();
                history.Text = inputbox.Text + "\n" + history.Text;
            }
            catch(Exception exception)
            {
                inputbox.Text = "Error!";
            }
        }

        //This method parses the inputted string, converts it to double and performs the operation
        private void ParseInputBox()
        {
            //Parse String
            String opString;
            int opindex = 0;

            if (inputbox.Text.Contains("+"))
            {
                opindex = inputbox.Text.IndexOf("+");
            }
            else if (inputbox.Text.Contains("-"))
            {
                opindex = inputbox.Text.IndexOf("-");
            }
            else if (inputbox.Text.Contains("*"))
            {
                opindex = inputbox.Text.IndexOf("*");
            }
            else if (inputbox.Text.Contains("/"))
            {
                opindex = inputbox.Text.IndexOf("/");
            }

            //Convert To Double
            opString = inputbox.Text.Substring(opindex, 1);
            double num1 = Convert.ToDouble(inputbox.Text.Substring(0, opindex));
            double num2 = Convert.ToDouble(inputbox.Text.Substring(opindex + 1, inputbox.Text.Length - opindex - 1));

            //Perform Operations
            switch (opString)
            {
                case "+":
                    inputbox.Text = "";
                    inputbox.Text += (num1 + num2);
                    break;
                case "-":
                    inputbox.Text = "";
                    inputbox.Text += (num1 - num2);
                    break;
                case "*":
                    inputbox.Text = "";
                    inputbox.Text += (num1 * num2);
                    break;
                case "/":
                    inputbox.Text = "";
                    inputbox.Text += (num1 / num2);
                    break;
            }    
        }

        //Private method to delete one item from the input box
        private void DelEvent(object sender, RoutedEventArgs e)
        {
            if(inputbox.Text.Length > 0)
            {
                inputbox.Text = inputbox.Text.Substring(0, inputbox.Text.Length - 1);
            }
        }
         
        //Private method to clear all data from the input box
        public void ClrEvent(object sender, RoutedEventArgs e)
        {
            inputbox.Text = "";
        }
    }
}
