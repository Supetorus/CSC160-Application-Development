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

namespace WPF_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum Operation
        {
            NONE,
            ADD,
            SUBTRACT,
            MULTIPLY,
            DIVIDE
        }

        private enum KeypadState
        {
            APPEND,
            REPLACE
        }

        Operation op;
        Operation lastOp;
        KeypadState ks = KeypadState.REPLACE;
        string textBox = "";
        double num1;
        bool num1Set = false;
        double num2;
        bool showingResult = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            bool isPeriod = btn.Content.ToString().Contains(".");
            bool containsPeriod = textBox.Contains(".");

            if (ks == KeypadState.APPEND)
            {
                if (isPeriod && !containsPeriod || !isPeriod)
                    textBox += btn.Content.ToString();
            }
            else
            {
                if (isPeriod && !containsPeriod || !isPeriod)
                    textBox = btn.Content.ToString();
            }

            Update();
            ks = KeypadState.APPEND;
        }

        private void Reset()
        {
            num1 = 0;
            num2 = 0;
            num1Set = false;
            textBox = "";
            op = Operation.NONE;
            ks = KeypadState.REPLACE;
            showingResult = false;
            Update();
        }

        private void Update()
        {
            resultBox.Text = textBox;
            switch (op)
            {
                case Operation.ADD:
                    btnPlus.Background = Brushes.White;
                    btnPlus.Foreground = Brushes.Orange;
                    btnMinus.Background = Brushes.Orange;
                    btnMinus.Foreground = Brushes.White;
                    btnDivide.Background = Brushes.Orange;
                    btnDivide.Foreground = Brushes.White;
                    btnMultiply.Background = Brushes.Orange;
                    btnMultiply.Foreground = Brushes.White;
                    break;
                case Operation.SUBTRACT:
                    btnPlus.Background = Brushes.Orange;
                    btnPlus.Foreground = Brushes.White;
                    btnMinus.Background = Brushes.White;
                    btnMinus.Foreground = Brushes.Orange;
                    btnDivide.Background = Brushes.Orange;
                    btnDivide.Foreground = Brushes.White;
                    btnMultiply.Background = Brushes.Orange;
                    btnMultiply.Foreground = Brushes.White;
                    break;
                case Operation.MULTIPLY:
                    btnPlus.Background = Brushes.Orange;
                    btnPlus.Foreground = Brushes.White;
                    btnMinus.Background = Brushes.Orange;
                    btnMinus.Foreground = Brushes.White;
                    btnDivide.Background = Brushes.Orange;
                    btnDivide.Foreground = Brushes.White;
                    btnMultiply.Background = Brushes.White;
                    btnMultiply.Foreground = Brushes.Orange;
                    break;
                case Operation.DIVIDE:
                    btnPlus.Background = Brushes.Orange;
                    btnPlus.Foreground = Brushes.White;
                    btnMinus.Background = Brushes.Orange;
                    btnMinus.Foreground = Brushes.White;
                    btnDivide.Background = Brushes.White;
                    btnDivide.Foreground = Brushes.Orange;
                    btnMultiply.Background = Brushes.Orange;
                    btnMultiply.Foreground = Brushes.White;
                    break;
                default:
                    btnPlus.Background = Brushes.Orange;
                    btnPlus.Foreground = Brushes.White;
                    btnMinus.Background = Brushes.Orange;
                    btnMinus.Foreground = Brushes.White;
                    btnDivide.Background = Brushes.Orange;
                    btnDivide.Foreground = Brushes.White;
                    btnMultiply.Background = Brushes.Orange;
                    btnMultiply.Foreground = Brushes.White;
                    break;
            }

            // Debug code
            txtNum1.Text = num1.ToString();
            txtNum2.Text = num2.ToString();
            if (num1Set) txtNum1.Foreground = Brushes.Black;
            else txtNum1.Foreground = Brushes.Gray;
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            op = Operation.ADD;
            if (!showingResult) doOp();
            Update();
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            op = Operation.SUBTRACT;
            if (!showingResult) doOp();
            Update();
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            op = Operation.DIVIDE;
            if (!showingResult) doOp();
            Update();
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            op = Operation.MULTIPLY;
            if (!showingResult) doOp();
            Update();
        }

        private void doOp()
        {
            ks = KeypadState.REPLACE;
            if (num1Set)
            {
                double.TryParse(resultBox.Text, out num2);
                Calc();
                textBox = num1.ToString();
                ks = KeypadState.REPLACE;
            }
            else
            {
                double.TryParse(textBox, out num1);
                num1Set = true;
            }
            showingResult = false;
        }

        private void Calc()
        {
            switch (op)
            {
                case Operation.ADD:
                    num1 = num1 + num2;
                    break;
                case Operation.SUBTRACT:
                    num1 = num1 - num2;
                    break;
                case Operation.MULTIPLY:
                    num1 = num1 * num2;
                    break;
                case Operation.DIVIDE:
                    num1 = num1 / num2;
                    break;
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (!showingResult) double.TryParse(resultBox.Text, out num2);
            else op = lastOp;
            Calc();
            textBox = num1.ToString();
            lastOp = op;
            op = Operation.NONE;
            ks = KeypadState.REPLACE;
            showingResult = true;
            Update();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            Update();
        }
    }
}
