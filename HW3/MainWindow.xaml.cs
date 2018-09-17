using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFCalc
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

        private void KeyboardEvent(object sender, KeyEventArgs e)
        {
                      
            switch (e.Key.ToString())
            {
                case "NumPad0":
                    inputbox.Text += "0";
                    break;
                    
                case "NumPad1":
                    inputbox.Text += "1";
                    break;

                case "NumPad2":
                    inputbox.Text += "2";
                    break;

                case "NumPad3":
                    inputbox.Text += "3";
                    break;

                case "NumPad4":
                    inputbox.Text += "4";
                    break;

                case "NumPad5":
                    inputbox.Text += "5";
                    break;

                case "NumPad6":
                    inputbox.Text += "6";
                    break;

                case "NumPad7":
                    inputbox.Text += "7";
                    break;

                case "NumPad8":
                    inputbox.Text += "8";
                    break;

                case "NumPad9":
                    inputbox.Text += "9";
                    break;

                case "Multiply":
                    inputbox.Text += "*";
                    break;

                case "Divide":
                    inputbox.Text += "/";
                    break;

                case "Add":
                    inputbox.Text += "+";
                    break;

                case "Subtract":
                    inputbox.Text += "-";
                    break;

                case "Decimal":
                    inputbox.Text += ".";
                    break;

                case "Enter":
                    try
                    {
                        ParseInputBox();
                        history.Text = inputbox.Text + "\n" + history.Text;
                    }
                    catch (Exception exception)
                    {
                        inputbox.Text = "Error!";
                    }
                    break;
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
        private void ClrEvent(object sender, RoutedEventArgs e)
        {
            inputbox.Text = "";
        }

        private void MyCommand()
        {
            inputbox.Text = history.Text;
        }
    }
}
