using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public enum types { DELIMITER = 1, NUMBER }

    public class Parser
    {
        int i;                        // порядковый номер элемента в выражении
        string exp_ptr;               // выражение для вычисления    
        char[] token = new char[20];  // текущий элемент
        types tok_type;               // тип элемента

        public double eval_exp(string exp)
        {
            i = 0;
            double result = 0;
            exp_ptr = exp;

            if (exp_ptr == "")
                throw new ArgumentNullException();

            get_token();
            eval_exp2(ref result);

            return result;
        }

        private void get_token()
        {
            tok_type = 0;
            int j = 0;
            Array.Clear(token, 0, token.Length);
            string separator = "+-*/()";

            if (exp_ptr.Length == i)
                return;

            if (separator.IndexOf(exp_ptr[i]) != -1)
            {
                tok_type = types.DELIMITER;
                token[j] = exp_ptr[i];
                i++;
            }
            else if ((int)exp_ptr[i] >= 48 && (int)exp_ptr[i] <= 57)
            {
                do
                {
                    token[j] = exp_ptr[i];
                    i++;
                    j++;
                    if (exp_ptr.Length == i)
                        break;
                } while ((int)exp_ptr[i] >= 48 && (int)exp_ptr[i] <= 57);
                tok_type = types.NUMBER;
            }
        }

        // Сложение и вычитание
        private void eval_exp2(ref double result)
        {
            char op;
            double temp = 0;

            eval_exp3(ref result);
            while ((op = token[0]) == '+' || op == '-')
            {
                get_token();
                eval_exp3(ref temp);
                switch (op)
                {
                    case '-':
                        result = result - temp;
                        break;
                    case '+':
                        result = result + temp;
                        break;
                }
            }
        }

        // Умножение и деление
        private void eval_exp3(ref double result)
        {
            char op;
            double temp = 0;

            eval_exp4(ref result);
            while ((op = token[0]) == '*' || op == '/')
            {
                get_token();
                eval_exp4(ref temp);
                switch (op)
                {
                    case '*':
                        result = result * temp;
                        break;
                    case '/':
                        result = result / temp;
                        break;
                }
            }
        }

        // Унарный + или унарный -
        private void eval_exp4(ref double result)
        {
            char op = '0';

            if (tok_type == types.DELIMITER && token[0] == '+' || token[0] == '-')
            {
                op = token[0];
                get_token();
            }
            eval_exp5(ref result);
            if (op == '-')
                result = -result;
        }

        // Обработка выражения в скобках
        private void eval_exp5(ref double result)
        {
            if ((token[0] == '('))
            {
                get_token();
                eval_exp2(ref result);

                if (token[0] != ')')
                    throw new ArgumentException();
                get_token();
            }
            else number(ref result);
        }

        private void number(ref double result)
        {
            switch (tok_type)
            {
                case types.NUMBER:
                    result = double.Parse(new string(token));
                    get_token();
                    return;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
