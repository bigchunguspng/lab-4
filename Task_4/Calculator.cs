using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Task_4
{
    /// <summary>
    /// Дозволяє рахувати в системах числення з основами 2, 8, 16, 10
    /// </summary>
    public static class Calculator
    {
        private static readonly string Operations = "+-*/";
        private static string _number1 = "0", _number2;
        private static byte _numeralSystem;
        private static readonly byte[] Bases = {2, 8, 10, 16};

        private static readonly string[] Hex =
        {
            "0", "1", "2", "3", "4", "5", "6", "7", 
            "8", "9", "A", "B", "C", "D", "E", "F"
        };

        public static void Run()
        {
            while (true)
            {
                if (ApplicationLicense.License == License.Common)
                {
                    _numeralSystem = 10;
                    Program.Say("Введiть вираз у десятковiй системi (наприклад 25.3 + 18.895 або 91,2/0,33)");
                }
                else
                {
                    if (_numeralSystem == 0)
                        do
                        {
                            Program.Say("Оберiть систему числення: [2] [8] [10] [16]");
                            byte.TryParse(Console.ReadLine(), out _numeralSystem);
                        } while (!Bases.Contains(_numeralSystem));

                    Program.Say("Введiть вираз (наприклад 10.01 + 11010.010101 або 9F,2*0,2), чи виберiть iншу систему числення:");
                }

                string expression = Console.ReadLine();
                Operate(expression);
                if (ApplicationLicense.License == License.Trial) ApplicationLicense.UpdateTrial();
            }
        }

        private static void Operate(string expression)
        {
            expression = expression.Replace('.', ',');
            expression = expression.Replace(" ", "");
            if (expression.IndexOfAny(Operations.ToCharArray()) < 0) //якщо вираз не містить операцій
            {
                if (ApplicationLicense.License > 0 && Byte.TryParse(expression, out byte numeralSystem))
                {
                    numeralSystem = Byte.Parse(expression);
                    if (Bases.Contains(numeralSystem)) _numeralSystem = numeralSystem;
                    Program.Say($"Вибрано систему з основою {_numeralSystem}");
                    _number1 = "0";
                }
                return;
            }
            expression = expression.ToUpper();
            string[] expr = expression.Split(Operations.ToCharArray());
            
            _number1 = String.IsNullOrEmpty(expr[0]) ? _number1 : expr[0];
            _number2 = expr[1];
            byte operation = (byte) Operations.IndexOf(expression[expression.IndexOfAny(Operations.ToCharArray())]);

            double a, b;
            if (_numeralSystem != 10)
            {
                a = ToDecimal(_number1);
                b = ToDecimal(_number2);
            }
            else
            {
                a = double.Parse(_number1);
                b = double.Parse(_number2);
            }
            
            double result = 0;
            switch (operation)
            {
                case 0:
                    result = a + b;
                    break;
                case 1:
                    result = a - b;
                    break;
                case 2:
                    result = a * b;
                    break;
                case 3:
                    result = a / b;
                    break;
            }
            _number1 = _numeralSystem == 10 ? result.ToString(CultureInfo.CurrentCulture) : ToBinOctHex(result);
            Console.WriteLine(_number1);
        }

        private static double ToDecimal(string number) //конвертує з 2-ї 8-ї та 16-ї системи в 10-кову
        {
            string[] digits = new string[number.Length];
            for (var i = 0; i < number.Length; i++) digits[i] = number[i].ToString();

            if (_numeralSystem == 16)
                for (var i = 0; i < digits.Length; i++)
                for (var j = 0; j < Hex.Length; j++)
                    if (digits[i].Equals(Hex[j]))
                        digits[i] = j.ToString();

            int integer = 0;
            double fractional = 0;
            int commaPosition = number.IndexOf(',');
            if (commaPosition != -1)
                for (int f = commaPosition + 1; f < digits.Length; f++)
                    fractional += Math.Pow(_numeralSystem, commaPosition - f) * Int32.Parse(digits[f]);
            else
                commaPosition = digits.Length;
            for (int i = commaPosition - 1; i >= 0; i--)
                integer += (int) Math.Pow(_numeralSystem, commaPosition - 1 - i) * Int32.Parse(digits[i]);

            return integer + fractional;
        }

        private static string ToBinOctHex(double number) //конвертує з 10-ї системи у поточну
        {
            if (Math.Abs(number) < 0.00001)
                return "0";
            bool negative = false;
            if (number < 0)
            {
                number = -number;
                negative = true;
            }

            int integer = (int)number;
            double fractional = number - integer;
            List<int> fractionDigits = new List<int>();
                
            //переведення дробової частини
            while (Math.Abs(fractional) > 0.001 && fractionDigits.Count < 45)
            {
                fractional *= _numeralSystem;
                int integerPart = (int) fractional;
                fractionDigits.Add(integerPart);
                fractional -= integerPart;
            }
            //переведення цілої частини
            Stack<int> integerDigits = new Stack<int>();
            if (integer == 0)
                integerDigits.Push(0);
            else
                while (integer > 0)
                {
                    integerDigits.Push(integer % _numeralSystem);
                    integer /= _numeralSystem;
                }

            string output = "";
            foreach (int i in integerDigits)
                if (_numeralSystem == 16) output += ToHex(i);
                else output += i.ToString();
            output += ",";
            foreach (int i in fractionDigits)
                if (_numeralSystem == 16) output += ToHex(i);
                else output += i.ToString();

            if (output.Contains(','))
            {
                output = output.TrimEnd('0');
                output = output.TrimEnd(',');
            }

            if (negative) output = "-" + output;
            
            return output;
        }

        private static char ToHex(int x) //заміняє числа на літери при конвертуванні в 16-кову систему
        {
            if (x< 10) return Convert.ToChar(x.ToString());

            char[] letters = {'A', 'B', 'C', 'D', 'E', 'F'};
            return letters[x - 10];
        }
    }
}