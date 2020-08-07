using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Calculator
{
    public partial class Form1 : Form
    {
        Double answer = 0;
        Double operand = 0;
        bool newNum = false;
        bool repeatedOperation = false;
        String prevOperation = "";
        bool zeroDivide; //check if the user is dividing by zero

        public Form1()
        {
            InitializeComponent();
        }
   
        //Whenever you click a number button, add that to the result textbox
        private void number_click(object sender, EventArgs e)
        {
            if (!zeroDivide)
            {
                if (newNum)
                {
                    resultBox.Text = "0";
                    newNum = false;
                }
                if (repeatedOperation)
                {
                    prevOperation = "0";
                    answer = 0;
                }
                if(!(resultBox.Text == "0" && (Button)sender == button0) && !(((Button)sender) == buttonDot && resultBox.Text.Contains(".")))//limit the amount of decimals 
                {
                    resultBox.Text = (resultBox.Text == "0" && ((Button)sender == buttonDot) ? "0." : ((resultBox.Text == "0") ? ((Button)sender).Text : resultBox.Text + ((Button)sender).Text));
                }
            }
        }
        
        //set the operation
        private void operator_Click(object sender, EventArgs e)
        {
            if (!zeroDivide)
            {
                if(prevOperation == "0")
                {
                    prevOperation = ((Button)sender).Text;
                    answer = double.Parse(resultBox.Text);
                }
                else if (newNum)
                    prevOperation = ((Button)sender).Text;
                else
                {
                    calculate(answer, prevOperation, double.Parse(resultBox.Text));
                    prevOperation = ((Button)sender).Text;
                }
                repeatedOperation = false;
                newNum = true;
            }
        }
        
        //perform the arithmetic 
        void calculate(double prevAnswer, string prevOperation, double operand)
        {
            switch (prevOperation)
            {
                case "*":
                    resultBox.Text = (answer = (prevAnswer * operand)).ToString();
                    break;

                case "/":
                    if(operand == 0)
                    {
                        string message = "Divide by zero error";
                        string caption = "Error Detected in Input";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        var result = MessageBox.Show(message, caption, buttons);
                        zeroDivide = true;
                        resultBox.Text = "0";
                    }
                    else
                        resultBox.Text = (answer = (prevAnswer / operand)).ToString();
                    break;

                case "+":
                    resultBox.Text = (answer = (prevAnswer + operand)).ToString();
                    break;

                case "-":
                    resultBox.Text = (answer = (prevAnswer - operand)).ToString();
                    break;

                default:
                    break;
            }
        }

        //clear everything
        private void clear_Click(object sender, EventArgs e)
        {
            resultBox.Text = "0";
            prevOperation = "0";     
            answer = 0;
            operand = 0;
            zeroDivide = false;
            repeatedOperation = false;
        }
        
        //evaluate the equation
        private void equal_Click(object sender, EventArgs e)
        {
            if (!zeroDivide)
            {
                if(!repeatedOperation)
                {
                    operand = double.Parse(resultBox.Text);
                    repeatedOperation = true;
                }
                calculate(answer, prevOperation, operand);
                newNum = true;
            }
        }

        //clear the current entry
        private void buttonCE_click(object sender, EventArgs e)
        {
            resultBox.Text = "0";
        }

        //adds keyboard functionality
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(e.KeyChar.ToString())
            {
                case "0":
                    button0.PerformClick();
                    break;

                case "1":
                    button1.PerformClick();
                    break;

                case "2":
                    button2.PerformClick();
                    break;

                case "3":
                    button3.PerformClick();
                    break;

                case "4":
                    button4.PerformClick();
                    break;

                case "5":
                    button5.PerformClick();
                    break;

                case "6":
                    button6.PerformClick();
                    break;

                case "7":
                    button7.PerformClick();
                    break;

                case "8":
                    button8.PerformClick();
                    break;

                case "9":
                    button9.PerformClick();
                    break;

                case "*":
                    buttonMultiply.PerformClick();
                    break;

                case "/":
                    buttonSlash.PerformClick();
                    break;

                case "+":
                    buttonPlus.PerformClick();
                    break;

                case "-":
                    buttonMinus.PerformClick();
                    break;

                case "=":
                    buttonEqual.PerformClick();
                    break;

                case ".":
                    buttonDot.PerformClick();
                    break;

                default:
                    break;
            }
        }

        //convert a positive to a negative or vice versa
        private void buttonSignChange_Click(object sender, EventArgs e)
        {
            if (!zeroDivide)
                resultBox.Text = (double.Parse(resultBox.Text) * -1).ToString();
           
        }
    }
}
