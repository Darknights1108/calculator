using System;
using System.Collections.Generic;
using System.Linq;
using 计算器.Model;

namespace 计算器.Manager.Compute
{
    public class ComputeManager
    {
        /// <summary>
        /// 文本解析
        /// </summary>
        /// <param name="currentInput">当前输入字符 一般为当前触发按键</param>
        public string TextInput(string currentInput, ref long currentNum, ref List<KeyValueModel> keyValuePairs)
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

            return text;
        }

        /// <summary>
        /// 数值参数
        /// </summary>
        /// <param name="input"></param>
        public string HandleInput(string input, ref long currentNum, ref string beforeInput, ref List<KeyValueModel> keyValuePairs)
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
                    HandleSymbol(input, ref currentNum, ref beforeInput, ref keyValuePairs);
                    break;
                default:
                    break;
            }
            beforeInput = input;
            return TextInput(input, ref currentNum, ref keyValuePairs);
        }

        /// <summary>
        /// 字符参数
        /// </summary>
        /// <param name="symbol"></param>
        private void HandleSymbol(string symbol, ref long currentNum, ref string beforeInput, ref List<KeyValueModel> keyValuePairs)
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

        /// <summary>
        /// 四则运算处理
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public long Eq(string symbol, long a, long b)
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
