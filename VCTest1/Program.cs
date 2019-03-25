using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCTest1
{
 
    class Program
    {
        //其中控件启动和结束。Main 方法是创建对象和执行其他方法的位置。Main 方法是驻留在类或结构中的静态方法
        static void Main(string[] args)
        {
            
            MyClass mm = new MyClass();
            mm.A();
            B diB = new B();
            diB.DoWork(1);

            Console.ReadKey();

        }
    }

    public abstract class A {
        public abstract void DoWork(int i);
    }
    public class B : A
    {
        enum Day { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
        public override void DoWork(int i) {
            //var array = new int[i][,];
            //for (int j = 0; j < array.Length; j ++) {
            //    array[j] = new int[,] { { j , j+1 } , { j+2 , j+3 } };
            //    int[,] insetArray = array[j];
            //    foreach(int eachEle in insetArray)
            //    Console.WriteLine("{0}", eachEle);
            //}
           
            Day today = Day.Monday;
            int dayNumber = (int)today;
            if (dayNumber == i)
            {
                Console.WriteLine("Today is Monday.");
            }
            else {
                Console.WriteLine("Today is not Monday.");
            }
            
        }
    }

    class MyClass
    {
        public void A()
        {
            try
            {
                B();
                int[] intArray = new int[] {1,2,3,4,5};
                foreach (int i in intArray) {
                    Console.WriteLine("A--eachElements:{0}",i);
                }
                try {
                    Console.WriteLine("A--theTenthElement:{0}", intArray[10]);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("A--Message:{0}", e.Message);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("A--Message:{0}", e.Message);
            }
        }
        void B()
        {
            int i = 100;
            try
            {
                int j = 0;
                int a = i / j;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("A--Message:{0}", e.Message);
            }

        }

    }

}
