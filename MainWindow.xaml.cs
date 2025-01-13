using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace A2IshratVohra
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = (sender as System.Windows.Controls.Button).Content.ToString();

            if (buttonContent == "Off")
            {
                Application.Current.Shutdown();
            }
            else if (buttonContent == "Del")
            {
                txtDisplay.Text = string.Empty;
            }
            else if (buttonContent == "R")
            {
                if (txtDisplay.Text.Length > 0)
                {
                    txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
                }
            }
            else if (buttonContent == "=")
            {
                try
                {
                    txtDisplay.Text = EvaluateExpression(txtDisplay.Text).ToString();
                }
                catch (Exception)
                {
                    txtDisplay.Text = "Error!";
                }
            }
            else if ("/*-+".Contains(buttonContent))
            {
                if (txtDisplay.Text.Length > 0 && "/*-+".Contains(txtDisplay.Text[txtDisplay.Text.Length - 1].ToString()))
                {
                    txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1) + buttonContent;
                }
                else
                {
                    txtDisplay.Text += buttonContent;
                }
            }
            else
            {
                if (txtDisplay.Text == "Error!")
                {
                    txtDisplay.Text = string.Empty;
                }
                txtDisplay.Text += buttonContent;
            }
        }


        // Evaluates a mathematical expression
        // Learned this method from a Stack Overflow post:
        // Title: "How to evaluate a math expression given in string form?"
        // Author: dario_ramos (as of March 29, 2011)
        // URL: https://stackoverflow.com/questions/11077969/how-to-evaluate-a-math-expression-given-in-string-form
        private static double EvaluateExpression(string expression)
        {
            var dataTable = new System.Data.DataTable();
            return Convert.ToDouble(dataTable.Compute(expression, string.Empty));
        }
    }
}
