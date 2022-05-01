using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using 计算器.Manager.Compute;
using 计算器.Model;

namespace 计算器
{
    public partial class Form1 : Form
    {
        long currentNum = 0;
        string beforeInput = " ";
        List<KeyValueModel> keyValuePairs = new List<KeyValueModel>();

        ComputeManager computeManager = new ComputeManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void Button_1_Click(object sender, EventArgs e) => computeManager.HandleInput(((Button)sender).Text);

        private void Button_2_Click(object sender, EventArgs e) => computeManager.HandleInput(((Button)sender).Text);

        private void Button_3_Click(object sender, EventArgs e) => computeManager.HandleInput(((Button)sender).Text);

        private void Button_4_Click(object sender, EventArgs e) => computeManager.HandleInput(((Button)sender).Text);

        private void Button_5_Click(object sender, EventArgs e) => computeManager.HandleInput(((Button)sender).Text);

        private void Button_6_Click(object sender, EventArgs e) => computeManager.HandleInput(((Button)sender).Text);

        private void Button_7_Click(object sender, EventArgs e) => computeManager.HandleInput(((Button)sender).Text);

        private void Button_8_Click(object sender, EventArgs e) => computeManager.HandleInput(((Button)sender).Text);

        private void Button_9_Click(object sender, EventArgs e) => computeManager.HandleInput(((Button)sender).Text);

        private void Button_0_Click(object sender, EventArgs e) => computeManager.HandleInput(((Button)sender).Text);

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

            computeManager.TextInput(beforeInput);
        }

        private void Button_sum_Click(object sender, EventArgs e) => computeManager.HandleInput(((Button)sender).Text);

        private void Button_Negative_Click(object sender, EventArgs e) => computeManager.HandleInput(((Button)sender).Text);

        private void Button_Multi_Click(object sender, EventArgs e) => computeManager.HandleInput(((Button)sender).Text);

        private void Button_Dev_Click(object sender, EventArgs e) => computeManager.HandleInput(((Button)sender).Text);
        
        /// <summary>
        /// 实现四则运算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Equal_Click(object sender, EventArgs e)
        {
            computeManager.TextInput(beforeInput);
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
                            keyValuePairs[i + 1].Value = computeManager.Eq(keyValuePairs[i].Key, keyValuePairs[i].Value, keyValuePairs[i + 1].Value);
                        }
                        else
                        {
                            if (currentNum == 0 && beforeInput != "0")
                            {
                                currentNum = keyValuePairs[i].Value;
                            }
                            else
                            {
                                currentNum = computeManager.Eq(keyValuePairs[i].Key, keyValuePairs[i].Value, currentNum);
                            }
                            beforeInput = currentNum.ToString().Last().ToString();
                        }

                        keyValuePairs.RemoveAt(i--);
                    }
                }
            }

            TB_1.Text = currentNum.ToString();
        }


    }
}

