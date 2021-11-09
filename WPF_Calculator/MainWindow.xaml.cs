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
        Operation op;
        Operation lastOp;
        KeypadState ks = KeypadState.REPLACE;
        string textBox = "";
        decimal num1;
        decimal num2;
        bool num1Set = false;
        bool showingResult = false;
        bool numEntered = false;
        int roundingPrecision = 10;
        
        private enum Operation
        {
            START,
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

        public MainWindow()
        {
            InitializeComponent();
        }

        // Methods

        private void AddNum(string btnNum)
        {
            if (showingResult) Clear(true);
            bool isPeriod = btnNum.Contains(".");
            bool hasPeriod = textBox.Contains(".");

            if (isPeriod && !hasPeriod || !isPeriod)
            {
                numEntered = true;
                switch (ks)
                {
                    case KeypadState.APPEND:
                        textBox += btnNum;
                        break;
                    case KeypadState.REPLACE:
                        textBox = btnNum;
                        ks = KeypadState.APPEND;
                        break;
                }
            }
            showingResult = false;
            Update();
        }

        private void Update()
        {
            resultBox.Text = textBox;
            if (numEntered) btnClear.Content = "C";
            else btnClear.Content = "AC";
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
        }

        private void doOp(Operation currentOp)
        {
            if (!num1Set)
            {
                decimal.TryParse(textBox, out num1);
                num1Set = true;
                ks = KeypadState.REPLACE;
                op = currentOp;
            }
            else
            {
                if (op == currentOp || op == Operation.START)
                {
                    op = currentOp;
                    if (!showingResult) decimal.TryParse(textBox, out num2);
                    Calc();
                    textBox = num1.ToString();
                }
                else
                {
                    if (!showingResult)
                    {
                        decimal.TryParse(textBox, out num2);
                        Calc();
                    }
                    // do something different, but maybe not all the time.
                    op = currentOp;
                    showingResult = false;
                    ks = KeypadState.REPLACE;
                }
            }
            Update();
        }

        private void Calc()
        {
            if (op == Operation.NONE && lastOp != Operation.START) op = lastOp;
            switch (op)
            {
                case Operation.ADD:
                    num1 = num1 + num2;
                    textBox = num1.ToString();
                    break;
                case Operation.SUBTRACT:
                    num1 = num1 - num2;
                    textBox = num1.ToString();
                    break;
                case Operation.MULTIPLY:
                    num1 = Decimal.Round((Decimal)(num1 * num2), roundingPrecision);
                    textBox = num1.ToString();
                    break;
                case Operation.DIVIDE:
                    if (num2 != 0) num1 = Decimal.Round((Decimal)(num1 / num2), roundingPrecision);
                    else
                    {
                        Clear(true);
                        textBox = "NaN";
                    }
                    break;
            }
            showingResult = true;
            ks = KeypadState.REPLACE;
            lastOp = op;
        }

        private void Equals()
        {
            if (!showingResult) decimal.TryParse(resultBox.Text, out num2);
            Calc();
            op = Operation.NONE;
            textBox = num1.ToString();
            showingResult = true;
            Update();
        }

        private void Clear(bool clearAll)
        {
            if (clearAll)
            {
                textBox = "0";
                num1 = 0;
                num2 = 0;
                num1Set = false;
                showingResult = false;
                op = Operation.START;
                ks = KeypadState.REPLACE;
                lastOp = Operation.START;
                numEntered = false;
            }
            else textBox = "0";
            numEntered = false;
            Update();
        }

        // Event Handlers

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button btn = ((Button)sender);
            string btnNum = btn.Content.ToString();
            AddNum(btnNum);
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            doOp(Operation.ADD);
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            doOp(Operation.SUBTRACT);
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            doOp(Operation.DIVIDE);
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            doOp(Operation.MULTIPLY);
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            Equals();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Content.ToString().Equals("AC")) Clear(true);
            else Clear(false);
        }

        private void btnPercent_Click(object sender, RoutedEventArgs e)
        {
            decimal percent;
            decimal.TryParse(resultBox.Text, out percent);
            if (!num1Set) percent = percent / 100;
            else percent = percent / 100 * num1;
            textBox = percent.ToString();
            Update();
        }

        private void btnFlipSign_Click(object sender, RoutedEventArgs e)
        {
            textBox = resultBox.Text;
            if (textBox[0] == '-') textBox = textBox.Substring(1);
            else textBox = textBox.Insert(0, "-");
            Update();
        }

        private void OnTextInputKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift) return;
            if (e.Key == Key.D8 && Keyboard.Modifiers == ModifierKeys.Shift) doOp(Operation.MULTIPLY);
            else if (e.Key == Key.OemPlus && Keyboard.Modifiers == ModifierKeys.Shift) doOp(Operation.ADD);
            else if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                AddNum(e.Key.ToString().Replace("D", "").Replace("NumPad", ""));
            }
            else if (e.Key == Key.OemPeriod)
            {
                AddNum(".");
            }
            else if (e.Key == Key.Escape)
            {
                if (btnClear.Content.ToString().Equals("AC")) Clear(true);
                else Clear(false);
            }
            else if (e.Key == Key.Back) textBox = textBox.Substring(0, textBox.Length - 1);
            else if (e.Key == Key.Enter)
            {
                Equals();
            }
            else if (e.Key == Key.OemMinus) doOp(Operation.SUBTRACT);
            else if (e.Key == Key.D8) doOp(Operation.MULTIPLY);
            else if (e.Key == Key.Oem2) doOp(Operation.DIVIDE);
            Update();
        }
    }
}
