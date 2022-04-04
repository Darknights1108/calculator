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

        public void HandleInput(int input)
        {
            currentNum = currentNum * 10 + input;
        }

        private void Button_1_Click(object sender, EventArgs e)
        {
            HandleInput(1);
            TextInput(1);
        }

        private void Button_2_Click(object sender, EventArgs e)
        {
            HandleInput(2);
            TextInput(2);
        }

        private void Button_3_Click(object sender, EventArgs e)
        {
            HandleInput(3);
            TextInput(3);
        }

        private void Button_4_Click(object sender, EventArgs e)
        {
            HandleInput(4);
            TextInput(4);
        }

        private void Button_5_Click(object sender, EventArgs e)
        {
            HandleInput(5);
            TextInput(5);
        }

        private void Button_6_Click(object sender, EventArgs e)
        {
            HandleInput(6);
            TextInput(6);
        }

        private void Button_7_Click(object sender, EventArgs e)
        {
            HandleInput(7);
            TextInput(7);
        }

        private void Button_8_Click(object sender, EventArgs e)
        {
            HandleInput(8);
            TextInput(8);
        }

        private void Button_9_Click(object sender, EventArgs e)
        {
            HandleInput(9);
            TextInput(9);
        }

        private void Button_0_Click(object sender, EventArgs e)
        {
            HandleInput(0);
            TextInput(0);
        }

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
    }
}

