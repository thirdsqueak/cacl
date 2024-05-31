using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public enum Operators
    {
        Add, Sub, Mul, Div
    }
    public partial class Calculator : Form
    {
        public double Result = 0;
        public bool isNewNum = true;
        public Operators Opt = Operators.Add;
        public Calculator()
        {
            InitializeComponent();
        }
        //set number when button click
        public void SetNum(string num)
        {
            if (isNewNum){
                lbScreen.Text = num;
                isNewNum = false;
            }
            else if (lbScreen.Text == "0"){
                lbScreen.Text = num;
            }else{
                lbScreen.Text += num;
            }
        }
        private void btnNum_Click(object sender, EventArgs e)
        {
            Button btnNum = (Button)sender;
            SetNum(btnNum.Text);
        }
        //calculate when operator click
        private void btnOperator_Click(object sender, EventArgs e)
        {
            double num = double.Parse(lbScreen.Text);
            //calculate with two number
            if (!isNewNum) {
                if (Opt == Operators.Add)
                    Result += num;
                else if (Opt == Operators.Sub)
                    Result -= num;
                else if (Opt == Operators.Mul)
                    Result *= num;
                else if (Opt == Operators.Div) {
                    Result /= num;
                    Result = Math.Round(Result * 1000)/1000;
                }
                lbScreen.Text = Result.ToString();
                lbProcess.Text += lbOperator.Text + " " + num.ToString() + " ";
                isNewNum = true;
            }
            //operator click - show process bar, send enum for calculation
            Button optButton = (Button)sender;
            if (optButton.Text == "+"){
                lbOperator.Text = "+";
                Opt = Operators.Add;
            }else if (optButton.Text == "-"){
                lbOperator.Text = "-";
                Opt = Operators.Sub;
            }else if (optButton.Text == "x"){
                lbOperator.Text = "x";
                Opt = Operators.Mul;
            }else if (optButton.Text == "÷"){
                lbOperator.Text = "÷";
                Opt = Operators.Div;
            }
            
        }
        private void btnResult_Click(object sender, EventArgs e)
        {
            //calculate with two number
            double num = double.Parse(lbScreen.Text);
            if (lbOperator.Text == "+"){
                Result += num;
            }
            else if (lbOperator.Text == "-"){
                Result -= num;
            }
            else if (lbOperator.Text == "x"){
                Result *= num;
            }
            else if (lbOperator.Text == "÷"){
                Result /= num;
                Result = Math.Round(Result * 1000) / 1000;
            }
            lbScreen.Text = Result.ToString();
            lbProcess.Text += lbOperator.Text + " " + num.ToString() + " ";
            isNewNum = true;
        }
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            Result = 0;
            isNewNum = true;
            Opt = Operators.Add;
            lbScreen.Text = "0";
            lbProcess.Text = "";
            lbOperator.Text = "";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            isNewNum = true;
            Opt = Operators.Add;
            lbScreen.Text = "0";
        }
        private void btnGoBack_Click(object sender, EventArgs e)
        {
            lbScreen.Text = lbScreen.Text.Remove(lbScreen.Text.Length - 1);
            if (lbScreen.Text.Length == 0)
                lbScreen.Text = "0";
        }
        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            double num = double.Parse(lbScreen.Text);
            num = -num;
            lbScreen.Text = num.ToString();
        }
        private void btnDot_Click(object sender, EventArgs e)
        {
            double num = double.Parse(lbScreen.Text);
            //if number is integer, add dot
            if (num == (int)num) {
                lbScreen.Text = num.ToString() + ",";
            }
            else {
                lbScreen.Text = "0,";
            }
        }
    }
}
