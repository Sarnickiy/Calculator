using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Calculator;

namespace Calculator_Test
{
    public class Parser_Test
    {
        [Test]
        public void Test_Unar_Op()
        {
            Parser ob = new Parser();

            string str_1 = "-5";
            string str_2 = "78";
            double result_1, result_2;

            result_1 = ob.eval_exp(str_1);
            result_2 = ob.eval_exp(str_2);

            Assert.That(result_1, Is.EqualTo(-5));
            Assert.That(result_2, Is.EqualTo(78));
        }

        [Test]
        public void Test_Addition_Subtraction()
        {
            Parser ob = new Parser();

            string str_1 = "12+8";
            string str_2 = "-8+3";
            double result_1, result_2;

            result_1 = ob.eval_exp(str_1);
            result_2 = ob.eval_exp(str_2);

            Assert.That(result_1, Is.EqualTo(20));
            Assert.That(result_2, Is.EqualTo(-5));
        }

        [Test]
        public void Test_Multiplication_Division()
        {
            Parser ob = new Parser();

            string str_1 = "12*5";
            string str_2 = "-3*15";
            double result_1, result_2;

            result_1 = ob.eval_exp(str_1);
            result_2 = ob.eval_exp(str_2);

            Assert.That(result_1, Is.EqualTo(60));
            Assert.That(result_2, Is.EqualTo(-45));
        }

        [Test]
        public void Test_Brackets()
        {
            Parser ob = new Parser();

            string str_1 = "(3+4)*5";
            string str_2 = "(-2+7)*(18-15)";
            double result_1, result_2;

            result_1 = ob.eval_exp(str_1);
            result_2 = ob.eval_exp(str_2);

            Assert.That(result_1, Is.EqualTo(35));
            Assert.That(result_2, Is.EqualTo(15));
        }
    }
}
