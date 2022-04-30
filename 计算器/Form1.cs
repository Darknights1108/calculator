using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using 计算器.modules;

namespace 计算器
{
    public partial class Form1 : Form
    {
        long currentNum = 0;
        string beforeInput = "";
        List<KeyValueModel> keyValuePairs = new List<KeyValueModel>();

        public Form1()
        {
            InitializeComponent();
        }

        public void TextInput(string currentInput)
        {
            string text = "";
            foreach (KeyValueModel keyValue in keyValuePairs)
            {
                text += keyValue.Value.ToString() + keyValue.Key;
            }

            if (currentNum != 0)
            {
                text += currentNum.ToString();
            }
            else if (currentNum == 0 && currentInput == "0")
            {
                text += "0";
            }

            if (text == "")
            {
                text = "0";
            }

            TB_1.Text = text;
        }

        public void HandleInput(string input)
        {
            switch (input)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    currentNum = currentNum * 10 + Convert.ToInt64(input);
                    break;
                case "+":
                case "-":
                case "*":
                case "/":
                    HandleSymbol(input);
                    break;
                default:
                    break;
            }
            TextInput(input);
            beforeInput = input;
        }

        private void HandleSymbol(string symbol)
        {
            if ((beforeInput == "+" || beforeInput == "-" || beforeInput == "*" || beforeInput == "/") && currentNum == 0)
            {
                keyValuePairs.Last().Key = symbol;
            }
            else
            {
                keyValuePairs.Add(new KeyValueModel() { Key = symbol, Value = currentNum });
                currentNum = 0;
            }
        }

        private void Button_1_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

        private void Button_2_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

        private void Button_3_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

        private void Button_4_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

        private void Button_5_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

        private void Button_6_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

        private void Button_7_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

        private void Button_8_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

        private void Button_9_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

        private void Button_0_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

        private void Button_Clear_Click(object sender, EventArgs e)
        {
            TB_1.Text = "0";
            currentNum = 0;
            beforeInput = "";
            keyValuePairs.Clear();
        }

        private void Button_Delete_Click(object sender, EventArgs e)
        {
            //todo backspace等待重做
            int txtlength = TB_1.Text.Length;
            if (txtlength != 1)
            {
                TB_1.Text = TB_1.Text.Remove(txtlength - 1);
            }
            else
            {
                TB_1.Text = 0.ToString();
                return;
            }
        }

        private void Button_sum_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

        private void Button_Negative_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

        private void Button_Multi_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

        private void Button_Dev_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

    }
}

