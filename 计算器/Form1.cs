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
        string beforeInput = " ";
        List<KeyValueModel> keyValuePairs = new List<KeyValueModel>();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 文本解析
        /// </summary>
        /// <param name="currentInput">当前输入字符 一般为当前触发按键</param>
        public void TextInput(string currentInput)
        {
            string text = "";
            foreach (KeyValueModel keyValue in keyValuePairs)
            {
                text += keyValue.ToString();
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
        /// <summary>
        /// 数值参数
        /// </summary>
        /// <param name="input"></param>
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

        /// <summary>
        /// 字符参数
        /// </summary>
        /// <param name="symbol"></param>
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

        /// <summary>
        /// 清除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Clear_Click(object sender, EventArgs e)
        {
            TB_1.Text = "0";
            TB_2.Text = "";
            currentNum = 0;
            beforeInput = " ";
            keyValuePairs.Clear();
        }

        /// <summary>
        /// 退格按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (currentNum == 0)
            {
                if (keyValuePairs.Count == 0)
                {
                    Button_Clear_Click(sender, e);
                }
                else if (TB_1.Text.Length > 1)
                {
                    string lastStr = TB_1.Text.Last().ToString();
                    string lastStr2 = TB_1.Text.Substring(TB_1.Text.Length - 2, 1).ToString();
                    if ((lastStr2 == "+" || lastStr2 == "-" || lastStr2 == "*" || lastStr2 == "/") && lastStr == "0")
                    {
                        beforeInput = lastStr2;
                    }
                    else
                    {
                        long value = keyValuePairs.Last().Value;
                        keyValuePairs.RemoveAt(keyValuePairs.Count - 1);

                        currentNum = value;

                        beforeInput = value.ToString().Last().ToString();
                    }
                }
                else
                {
                    throw new Exception("TB_1.Text.Length=" + TB_1.Text.Length + ";TB_1.Text=" + TB_1.Text);
                }
            }
            else
            {
                long before = currentNum;
                while (before > 10)
                {
                    before %= 10;
                }
                beforeInput = before.ToString();
                currentNum /= 10;
            }

            TextInput(beforeInput);
        }

        private void Button_sum_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

        private void Button_Negative_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

        private void Button_Multi_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);

        private void Button_Dev_Click(object sender, EventArgs e) => HandleInput(((Button)sender).Text);
        /// <summary>
        /// 实现四则运算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Equal_Click(object sender, EventArgs e)
        {
            TextInput(beforeInput);
            if (currentNum == 0 && (beforeInput == "+" || beforeInput == "-"))
            {
                TB_2.Text = TB_1.Text.TrimEnd(beforeInput.ToCharArray()[0]) + "=";
            }
            else
            {
                TB_2.Text = TB_1.Text + "=";
            }

            List<string> symbolList = new List<string>() { "*", "/", "+", "-" };
            for (int round = 0; round < symbolList.Count; round += 2)
            {
                List<string> currSymbolList = new List<string>() { symbolList[round], symbolList[round + 1] };

                for (int i = 0; i < keyValuePairs.Count; i++)
                {
                    if (currSymbolList.Contains(keyValuePairs[i].Key))
                    {
                        if (i < keyValuePairs.Count - 1)//判断算式末尾
                        {
                            keyValuePairs[i + 1].Value = Eq(keyValuePairs[i].Key, keyValuePairs[i].Value, keyValuePairs[i + 1].Value);
                        }
                        else
                        {
                            if (currentNum == 0 && beforeInput != "0")
                            {
                                currentNum = keyValuePairs[i].Value;
                            }
                            else
                            {
                                currentNum = Eq(keyValuePairs[i].Key, keyValuePairs[i].Value, currentNum);
                            }
                            beforeInput = currentNum.ToString().Last().ToString();
                        }

                        keyValuePairs.RemoveAt(i--);
                    }
                }
            }

            TB_1.Text = currentNum.ToString();
        }

        /// <summary>
        /// 四则运算处理
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private long Eq(string symbol, long a, long b)
        {
            if (symbol == "/" && b == 0)
            {
                throw new Exception("不能除0!");
            }
            switch (symbol)
            {
                case "*": return a * b;
                case "/": return a / b;
                case "+": return a + b;
                case "-": return a - b;
                default:
                    throw new Exception("未支持运算符");
            }
        }
    }
}

