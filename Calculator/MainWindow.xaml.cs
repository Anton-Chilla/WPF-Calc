using System;
using System.Windows;
using System.Windows.Controls;


namespace Calculator
{

    public partial class MainWindow : Window 
    {
        Calculate cal = new Calculate();

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void delBt_Click(object sender, RoutedEventArgs e)
        {
            TbCalc.Text = "";
            TbWayCalc.Text = "";
        }

        private void numBt_Click(object sender, RoutedEventArgs e)
            {
                Button button = (Button)sender;
           
            if (button.Content.ToString() == "π")
            {
                TbCalc.Text += "3,14"; 
            }
            else
            {
                TbCalc.Text += button.Content.ToString();
            }


        }


        private void calBt_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    Calculate();
                    TbWayCalc.Text = TbCalc.Text.Substring(0, TbCalc.Text.IndexOf('='));
                    TbCalc.Text = TbCalc.Text.Substring(TbCalc.Text.IndexOf('=') + 2);
                    
                }
                catch (Exception)
                {
                    TbCalc.Text = "Error! Try again.";
                } 
                
                
            }

        private void Calculate()
        {
            double value1 = 0;
            double value2 = 0;
            double result = 0;
            string op = "";

            char[] operators = { '×', '÷', '+', '-', '^' };
            int opPos = TbCalc.Text.IndexOfAny(operators);

            if (opPos == -1)
            {
                TbCalc.Text = "Invalid expression!";
                return;
            }

            value1 = Double.Parse(TbCalc.Text.Substring(0, opPos));
            op = TbCalc.Text.Substring(opPos, 1);
            value2 = Double.Parse(TbCalc.Text.Substring(opPos + 1, TbCalc.Text.Length - opPos - 1));

            switch (op)
            {
                case "×":
                    result = cal.multiply(value1, value2);
                    break;
                case "÷":
                    if (value2 == 0)
                    {
                        TbCalc.Text = "Cannot divide by zero!";
                        return;
                    }
                    result = cal.divide(value1, value2);
                    break;
                case "+":
                    result = cal.add(value1, value2);
                    break;
                case "-":
                    result = cal.subtract(value1, value2);
                    break;
                case "^":
                    result = cal.power(value1, value2);
                    break;
                default:
                    TbCalc.Text = "Invalid operator!";
                    return;
            }
            TbCalc.Text += "= " + result.ToString();
        }
    }
}
