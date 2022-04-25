using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 计算器
{
    public partial class Form1 : Form
    {
        long currentNum = 0;
        long totalNum = 0;
        Dictionary<string, long> keyValuePairs = new Dictionary<string, long>();

        public Form1()
        {
            InitializeComponent();
        }

        public void TextInput(int number)
        {
            if (number == 0 && currentNum == 0)
            {
                return;
            }
            if (TB_1.Text == "0")
            {
                TB_1.Text = number.ToString();
                return;
            }
            TB_1.Text += number;
        }

        public void HandleInput(string input)
        {
            currentNum = currentNum * 10 + input;
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

        }

        private void Button_Delete_Click(object sender, EventArgs e)
        {
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

        private void Button_sum_Click(object sender, EventArgs e)
        {
            keyValuePairs.Add("+",currentNum);
            currentNum = 0;
        }

        private void Button_Negative_Click(object sender, EventArgs e)
        {
            keyValuePairs.Add("-",currentNum);
            currentNum = 0;

        }

        private void Button_Multi_Click(object sender, EventArgs e)
        {
            keyValuePairs.Add("*", currentNum);
            currentNum = 0;
        }

        private void Button_Dev_Click(object sender, EventArgs e)
        {
            keyValuePairs.Add("/", currentNum);
            currentNum = 0;
        }
    }
}

