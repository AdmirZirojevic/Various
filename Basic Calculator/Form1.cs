using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        string display=null;
        string helper = null;

        double? firstDigit;
        double? secondDigit;
        double? result = 0;
        string operation;
        bool isNegative;
        
        string inputHistory;
        string inputHelper;
        
        public Form1()
        {
            InitializeComponent();          
        }

        private void button0_Click(object sender, EventArgs e)
        {    
            if (inputHistory == null)
                inputHistory = 0.ToString();
            else
                inputHistory = inputHistory + 0;

            inputHistoryTextBox.Text = inputHistory;

            if (display == result.ToString())
                display = null;

            if (display == null)
            {
                if (isNegative == true)
                    display = "" + -0;
                else
                    display = "" + 0;

                resultBox.Text = helper + display;
            }
            else
            {
                display = display + 0;
                resultBox.Text = helper + display;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inputHistory == null)
                inputHistory = 1.ToString();
            else
                inputHistory = inputHistory + 1;

            inputHistoryTextBox.Text = inputHistory;

            if (display == result.ToString())
                display = null;
            
            if (display == null)
            {
                if (isNegative == true)
                    display = "" + -1;
                else
                    display = ""+1;

                resultBox.Text = helper + display;                              
            }
            else
            {
                display = display + 1;
                resultBox.Text = helper + display;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (inputHistory == null)
                inputHistory = 2.ToString();
            else
                inputHistory = inputHistory + 2;

            inputHistoryTextBox.Text = inputHistory;

            if (display == result.ToString())
                display = null;

            if (display == null)
            {
                if (isNegative == true)
                    display = "" + -2;
                else
                    display = "" + 2;

                resultBox.Text = helper + display;
            }
            else
            {
                display = display + 2;
                resultBox.Text = helper + display;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (inputHistory == null)
                inputHistory = 3.ToString();
            else
                inputHistory = inputHistory + 3;

            inputHistoryTextBox.Text = inputHistory;

            if (display == result.ToString())
                display = null;

            if (display == null)
            {
                if (isNegative == true)
                    display = "" + -3;
                else
                    display = "" + 3;

                resultBox.Text = helper + display;
            }
            else
            {
                display = display + 3;
                resultBox.Text = helper + display;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (inputHistory == null)
                inputHistory = 4.ToString();
            else
                inputHistory = inputHistory + 4;

            inputHistoryTextBox.Text = inputHistory;

            if (display == result.ToString())
                display = null;

            if (display == null)
            {
                if (isNegative == true)
                    display = "" + -4;
                else
                    display = "" + 4;

                resultBox.Text = helper + display;
            }
            else
            {
                display = display + 4;
                resultBox.Text = helper + display;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (inputHistory == null)
                inputHistory = 5.ToString();
            else
                inputHistory = inputHistory + 5;

            inputHistoryTextBox.Text = inputHistory;

            if (display == result.ToString())
                display = null;

            if (display == null)
            {
                if (isNegative == true)
                    display = "" + -5;
                else
                    display = "" + 5;

                resultBox.Text = helper + display;
            }
            else
            {
                display = display + 5;
                resultBox.Text = helper + display;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (inputHistory == null)
                inputHistory = 6.ToString();
            else
                inputHistory = inputHistory + 6;

            inputHistoryTextBox.Text = inputHistory;

            if (display == result.ToString())
                display = null;

            if (display == null)
            {
                if (isNegative == true)
                    display = "" + -6;
                else
                    display = "" + 6;

                resultBox.Text = helper + display;
            }
            else
            {
                display = display + 6;
                resultBox.Text = helper + display;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (inputHistory == null)
                inputHistory = 7.ToString();
            else
                inputHistory = inputHistory + 7;

            inputHistoryTextBox.Text = inputHistory;

            if (display == result.ToString())
                display = null;

            if (display == null)
            {
                if (isNegative == true)
                    display = "" + -7;
                else
                    display = "" + 7;

                resultBox.Text = helper + display;
            }
            else
            {
                display = display + 7;
                resultBox.Text = helper + display;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (inputHistory == null)
                inputHistory = 8.ToString();
            else
                inputHistory = inputHistory + 8;

            inputHistoryTextBox.Text = inputHistory;

            if (display == result.ToString())
                display = null;

            if (display == null)
            {
                if (isNegative == true)
                    display = "" + -8;
                else
                    display = "" + 8;

                resultBox.Text = helper + display;
            }
            else
            {
                display = display + 8;
                resultBox.Text = helper + display;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (inputHistory == null)
                inputHistory = 9.ToString();
            else
                inputHistory = inputHistory + 9;

            inputHistoryTextBox.Text = inputHistory;

            if (display == result.ToString())
                display = null;

            if (display == null)
            {
                if (isNegative == true)
                    display = "" + -9;
                else
                    display = "" + 9;

                resultBox.Text = helper + display;
            }
            else
            {
                display = display + 9;
                resultBox.Text = helper + display;
            }
        }

        //SABIRANJE
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (inputHistory != null && inputHistory.EndsWith("+") || inputHistory != null&&(inputHistory.EndsWith("-")
             || inputHistory != null&&(inputHistory.EndsWith("x")) || inputHistory != null&& inputHistory.EndsWith("/")))
            {
               inputHistory=inputHistory.Remove(inputHistory.Length-1);                       
            }

            if (inputHistory != null)
             {            
                    inputHistory = inputHistory + "+";
                    inputHistoryTextBox.Text = inputHistory;                              
             }

            if (firstDigit != null&&display!="-"&&display!="")//ovo za "automatsko racunanje, bez da se jednako stalno pritisce
                secondDigit = Convert.ToDouble(display);

            if (firstDigit != null && secondDigit != null) //ovo za "automatsko racunanje, bez da se jednako stalno pritisce
                buttonEquals_Click(sender, e);

            if (display!=null)
            {
               if (display != "" && display != "-")
               firstDigit = Convert.ToDouble(display);

                display = null;
                operation = "+";
                resultBox.Text = firstDigit + " + ";
                helper = firstDigit + " + ";
            }                             
        }

        //ODUZIMANJE
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (inputHistory != null && inputHistory.EndsWith("+") || inputHistory != null && (inputHistory.EndsWith("-")
             || inputHistory != null && (inputHistory.EndsWith("x")) || inputHistory != null && inputHistory.EndsWith("/")))
            {
                inputHistory = inputHistory.Remove(inputHistory.Length - 1);
            }

            if (inputHistory != null)
            {
                inputHistory = inputHistory + "-";
                inputHistoryTextBox.Text = inputHistory;
            }

            if (firstDigit != null&&display!="-"&&display!="")//ovo za "automatsko racunanje, bez da se jednako stalno pritisce
                secondDigit = Convert.ToDouble(display);

            if (firstDigit != null && secondDigit != null) //ovo za "automatsko racunanje, bez da se jednako stalno pritisce
                buttonEquals_Click(sender, e);

            if (display != null)
            {
                if (display != "" && display != "-")
                firstDigit = Convert.ToDouble(display);

                display = null;
                operation = "-";
                resultBox.Text = firstDigit + " - ";
                helper = firstDigit + " - ";
            }
        }

        //MNOZENJE
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (inputHistory != null && inputHistory.EndsWith("+") || inputHistory != null && (inputHistory.EndsWith("-")
            || inputHistory != null && (inputHistory.EndsWith("x")) || inputHistory != null && inputHistory.EndsWith("/")))
            {
                inputHistory = inputHistory.Remove(inputHistory.Length - 1);
            }

            if (inputHistory != null)
            {
                inputHistory = inputHistory + "x";
                inputHistoryTextBox.Text = inputHistory;
            }

            if (firstDigit!=null&&display!="-"&&display!="") //ovo za "automatsko racunanje, bez da se jednako stalno pritisce
                secondDigit = Convert.ToDouble(display);

            if (firstDigit != null && secondDigit != null) //ovo za "automatsko racunanje, bez da se jednako stalno pritisce
                buttonEquals_Click(sender, e);

            if (display != null)
            {
                if (display != ""&&display!="-")
                    firstDigit = Convert.ToDouble(display);

                display = null;
                operation = "X";
                resultBox.Text = firstDigit + " x ";
                helper = firstDigit + " x ";
            }
        }

        //DJELJENJE
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (inputHistory != null && inputHistory.EndsWith("+") || inputHistory != null && (inputHistory.EndsWith("-")
            || inputHistory != null && (inputHistory.EndsWith("x")) || inputHistory != null && inputHistory.EndsWith("/")))
            {
                inputHistory = inputHistory.Remove(inputHistory.Length - 1);
            }

            if (inputHistory != null)
            {
                inputHistory = inputHistory + "/";
                inputHistoryTextBox.Text = inputHistory;
            }

            if (firstDigit!= null&&display!="-"&&display!= "")//ovo za "automatsko racunanje, bez da se jednako stalno pritisce
                secondDigit = Convert.ToDouble(display);

            if (firstDigit != null && secondDigit != null) //ovo za "automatsko racunanje, bez da se jednako stalno pritisce
                buttonEquals_Click(sender, e);

            if (display != null)
            {
                if (display != ""&&display!="-")
                    firstDigit = Convert.ToDouble(display);

                display = null;
                operation = "/";
                resultBox.Text = firstDigit + " / ";
                helper = firstDigit + " / ";
            }
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {          
            if (display != null && display != ""&&display!="-")
                secondDigit = Convert.ToDouble(display);

            switch (operation)
            {
                case "+":
                    result = firstDigit + secondDigit;
                    resultBox.Text = "" + result;
                    display = result.ToString();
                    firstDigit = null;
                    helper = null;
                    break;

                case "-":
                    result = firstDigit - secondDigit;
                    resultBox.Text = "" + result;
                    display = result.ToString();
                    firstDigit = null;
                    helper = null;
                    break;

                case "X":
                    result = firstDigit * secondDigit;
                    resultBox.Text = "" + result;
                    display = result.ToString();
                    firstDigit = null;
                    helper = null;
                    break;

                case "/":
                    result = firstDigit / secondDigit;
                    resultBox.Text = "" + result;
                    display = result.ToString();
                    firstDigit = null;
                    helper = null;
                    break;           
            }
          
            if (result == null)
            {
                inputHistory = null;
                inputHistoryTextBox.Text = inputHistory;
            }
                
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            operation = "";
            display = null;
            firstDigit = null;
            secondDigit = null;
            result = 0;
            helper = null;
            resultBox.Text = "";
            inputHistory = null;
            inputHistoryTextBox.Text = "";
            inputHelper = null;

            Negative.FlatStyle = FlatStyle.System;
            Negative.BackColor = SystemColors.Control;
            isNegative = false;
        }

        private void commaButton_Click(object sender, EventArgs e)
        {
            string[] arr;
            string z;

            if (inputHistory!=null&&!inputHistory.EndsWith("."))
            {
                inputHistory = inputHistory + ".";
                inputHistoryTextBox.Text = inputHistory;
               
                    if(!inputHistory.Contains("+")&&!inputHistory.Contains("-")&& !inputHistory.Contains("x")&&
                       !inputHistory.Contains("/"))
                 {                   
                    z = inputHistory;
                    arr = z.Split('.');
                    z = z.Substring(z.IndexOf('.') + 1);
                    z = z.Replace(".", "");

                    inputHistory = arr[0] + "." + z;
                 }
                else
                {
                    char[] splitter = { '+', '-', 'x', '/' };

                    z = inputHistory.Substring(inputHistory.LastIndexOfAny(splitter) + 1);
                    arr = z.Split('.');
                    z = z.Substring(z.IndexOf('.') + 1);
                    z = z.Replace(".", "");

                    inputHelper = arr[0] + "." + z;
                  
                    inputHistory = inputHistory.Remove(inputHistory.LastIndexOfAny(splitter) + 1);
                    inputHistory = inputHistory + inputHelper;                   
                }
            }
       
            if(display!=null&&display!="")
            {
                if (!display.Contains("."))
                    display = display + ".";
            }           
            resultBox.Text = helper + display;
        }

        private void Negative_Click(object sender, EventArgs e)
        {
            if(isNegative==true)
            {
                Negative.FlatStyle = FlatStyle.System;
                Negative.BackColor = SystemColors.Control;
                isNegative = false;
                if(firstDigit==null)
                {
                    display = display.Replace("-", "");
                    resultBox.Text = display;
                }
                else
                {
                    if(display!=null)
                    {
                        display = display.Replace("-", "");
                        resultBox.Text = helper + display;
                    }
                   
                }
            }
            else
            {
                Negative.FlatStyle = FlatStyle.Popup;
                Negative.BackColor = Color.WhiteSmoke;
                isNegative = true;
                if (firstDigit == null)
                {
                    display = "-" + display;
                    resultBox.Text = display;
                }
                else
                {                  
                    display = "-" + display;
                    resultBox.Text = helper+display;
                }
            }
          
        }
    }
}
