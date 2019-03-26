using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventTest
{
    delegate void CallBack();//delegate

    class CountTest
    {
        public event CallBack countNumCallBack;//create
        public void countFunc()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 12 == 0)
                {
                    countNumCallBack();//Trigger
                }
            }
        }
    }

    class SubscribeTest
    {
        public SubscribeTest(CountTest c)
        {
            c.countNumCallBack += subFunc;//subscribe
        }
        public void subFunc()
        {
            Console.WriteLine("Warning warning ~~");//handle
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CountTest c = new CountTest();
            SubscribeTest s = new SubscribeTest(c);
            c.countFunc();
            Console.ReadKey();
        }
    }
}
