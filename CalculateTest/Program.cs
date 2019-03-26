using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateTest
{
    class Program
    {
        public void writeSquareNum()
        {
            string squareNumStr = Console.ReadLine();
            int num = 0;
            bool isRight = int.TryParse(squareNumStr, out num);
            if (isRight && num >= 0)
            {
                double result = Math.Sqrt(num);
                Console.WriteLine("Result is:{0}", result);
            }
            else
            {
                Console.WriteLine("Input error, enter an integer:");
                writeSquareNum();
            }
        }

        public void writeOtherFirstNum(string way)
        {
            string firstNumStr = Console.ReadLine();
            int firstNum = 0;
            bool isRight = int.TryParse(firstNumStr, out firstNum);
            if (isRight)
            {
                Console.WriteLine("Please enter the second number:");
                writeOtherSecondNum(way, firstNum);
            }
            else
            {
                Console.WriteLine("Input error, enter an integer:");
                writeOtherFirstNum(way);
            }
        }

        public void writeOtherSecondNum(string way, int firstNum)
        {
            string secondNumStr = Console.ReadLine();
            int secondNum = 0;
            bool isSecondRight = int.TryParse(secondNumStr, out secondNum);
            if (isSecondRight)
            {
                calculate(way, firstNum, secondNum);
            }
            else
            {
                Console.WriteLine("Input error, enter an integer:");
                writeOtherSecondNum(way, firstNum);
            }
        }

        public void calculate(string way, int firstNum, int secondNum)
        {
            if (way.Equals("+"))
            {
                Console.WriteLine("Result is: {0}+{1}={2}", firstNum, secondNum, firstNum + secondNum);
            }
            else if (way.Equals("-"))
            {
                Console.WriteLine("Result is: {0}-{1}={2}", firstNum, secondNum, firstNum - secondNum);
            }
            else if (way.Equals("*"))
            {
                Console.WriteLine("Result is: {0}*{1}={2}", firstNum, secondNum, firstNum * secondNum);
            }
            else if (way.Equals("/"))
            {
                Console.WriteLine("Result is: {0}/{1}={2}", firstNum, secondNum, firstNum / secondNum);
            }
            else if (way.Equals("^"))
            {
                Console.WriteLine("Result is: {0}^{1}={2}", firstNum, secondNum, firstNum ^ secondNum);
            }
        }

        public void calculateFunc()
        {
            Console.WriteLine("Please enter the method of calculation you want to make (+,-,*,/, √, ^):");
            string way = Console.ReadLine();
            string[] calculates = { "+", "-", "*", "/", "^" };
            if (way.Equals("√"))
            {
                Console.WriteLine("Please enter a number to open the square:");
                writeSquareNum();
            }
            else if (Array.IndexOf<string>(calculates, way) != -1)
            {//contains right cal
                Console.WriteLine("Please enter the first number:");
                writeOtherFirstNum(way);
            }
            else
            {
                Console.WriteLine("Please enter the correct calculation method:");
                calculateFunc();
            }
        }

        static void Main(string[] args)
        {
            Program pro = new Program();
            pro.calculateFunc();
            Console.ReadKey();
        }
    }
}
