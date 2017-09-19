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

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string firstNumber = "";
        private string secondNumber = "";
        private string operation = "";
        private bool isFirstNumber = true;
        private bool finishedOperation = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClickNumber(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var number = button.Content.ToString();

            ProcessNumber(number);

        }

        private void ProcessNumber(string number)
        {
            if (!StartsWithZero(number))
            {

                if (finishedOperation)
                {
                    firstNumber = "";
                    secondNumber = "";
                    isFirstNumber = true;
                    CurrentOperation.Content = "";
                }

                if (!isFirstNumber)
                {
                    secondNumber += number;
                    DisplayTxt.Text = secondNumber;
                }
                else
                {
                    firstNumber += number;
                    DisplayTxt.Text = firstNumber;
                }

                finishedOperation = false;
            }
        }

        private void ClickOperation(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string op = button.Content.ToString();

            ProcessOp(op);
        }

        private void ProcessOp(string op)
        {
            operation = op;
            isFirstNumber = false;
            finishedOperation = false;
            DisplayTxt.Text = "";
            CurrentOperation.Content = firstNumber + " " + operation;
        }

        private bool IsValidOperation()
        {
            return !firstNumber.Equals("") && !secondNumber.Equals("");
        }

        private void ClickResult(object sender, RoutedEventArgs e)
        {
            if (IsValidOperation())
            {
                CurrentOperation.Content = firstNumber + " " + operation + " " + secondNumber;
                double first = Convert.ToDouble(firstNumber);
                double second = Convert.ToDouble(secondNumber);
                string result = "";
                switch (operation)
                {
                    case "+":
                        result = Convert.ToString(first + second);
                        break;
                    case "-":
                        result = Convert.ToString(first - second);
                        break;
                    case "x":
                        result = Convert.ToString(first * second);
                        break;
                    case "÷":
                        result = Convert.ToString(first / second);
                        break;
                }
                DisplayTxt.Text = result;
                CurrentOperation.Content = firstNumber + " " + operation + " " + secondNumber + " = " + result;
                firstNumber = result;
                secondNumber = "";
                isFirstNumber = false;
                finishedOperation = true;
            }
        }

        private void ClickClear(object sender, RoutedEventArgs e)
        {
            firstNumber = "";
            secondNumber = "";
            DisplayTxt.Text = "";
            CurrentOperation.Content = "";
            isFirstNumber = true;
        }

        private void ClickSQRT(object sender, RoutedEventArgs e)
        {
            double value = 0;
            if (isFirstNumber)
            {
                value = Convert.ToDouble(firstNumber);
                double result = Math.Sqrt(value);
                DisplayTxt.Text = Convert.ToString(result);
                CurrentOperation.Content = "√(" + value + ") " + " = " + result;
                firstNumber = Convert.ToString(result);

            }
            else
            {
                value = Convert.ToDouble(secondNumber);
                double result = Math.Sqrt(value);
                DisplayTxt.Text = Convert.ToString(result);
                CurrentOperation.Content += "√(" + value + ") " + " = " + result;
                secondNumber = Convert.ToString(result);
            }


        }

        private void ClickClearCurrent(object sender, RoutedEventArgs e)
        {
            if (isFirstNumber)
            {
                firstNumber = "";
            }
            else
            {
                secondNumber = "";
            }
            DisplayTxt.Text = "";

        }

        private bool StartsWithZero(string value)
        {
            if (value.Equals("0"))
            {
                if (isFirstNumber && firstNumber.Equals(""))
                {
                    return true;

                }
                else if (!isFirstNumber && secondNumber.Equals(""))
                {
                    return true;
                }
            }

            return false;
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.D1) || (e.Key == Key.NumPad1))
            {
                ProcessNumber("1");
            }
            else if ((e.Key == Key.D2) || (e.Key == Key.NumPad2))
            {
                ProcessNumber("2");
            }
            else if ((e.Key == Key.D3) || (e.Key == Key.NumPad3))
            {
                ProcessNumber("3");
            }
            else if ((e.Key == Key.D4) || (e.Key == Key.NumPad4))
            {
                ProcessNumber("4");
            }
            else if ((e.Key == Key.D5) || (e.Key == Key.NumPad5))
            {
                ProcessNumber("5");
            }
            else if ((e.Key == Key.D6) || (e.Key == Key.NumPad6))
            {
                ProcessNumber("6");
            }
            else if ((e.Key == Key.D7) || (e.Key == Key.NumPad7))
            {
                ProcessNumber("7");
            }
            else if ((e.Key == Key.D8) || (e.Key == Key.NumPad8))
            {
                ProcessNumber("8");
            }
            else if ((e.Key == Key.D9) || (e.Key == Key.NumPad9))
            {
                ProcessNumber("9");
            }
            else if ((e.Key == Key.D0) || (e.Key == Key.NumPad0))
            {
                ProcessNumber("0");
            }
            else if ((e.Key == Key.Add))
            {
                ProcessOp("+");
            }
            else if ((e.Key == Key.Subtract))
            {
                ProcessOp("-");
            }
            else if ((e.Key == Key.Multiply))
            {
                ProcessOp("x");
            }
            else if ((e.Key == Key.Divide))
            {
                ProcessOp("÷");
            }
            else if ((e.Key == Key.Decimal))
            {
                ProcessNumber(",");
            }
            else if ((e.Key == Key.Enter))
            {
                ClickResult(null,null);
            }

        }

    }
}
