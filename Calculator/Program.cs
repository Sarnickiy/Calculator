using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
             Parser ob = new Parser();

             for (; ; )
             {
                 string str = "";

                 Console.Write("Введите выражение: ");
                 str = Console.ReadLine();
                 try
                 {
                     Console.WriteLine("Результат: " + ob.eval_exp(str) + "\n");
                 }
                 catch (ArgumentNullException)
                 {
                     Console.WriteLine("Ошибка: отсутствует выражение для вычисления!\n");
                 }
                 catch (ArgumentException)
                 {
                     Console.WriteLine("Ошибка синтаксиса!\n");
                 }
                 catch
                 {
                     Console.WriteLine("Ошибка синтаксиса!\n");
                 }
             }
        }
    }
}
