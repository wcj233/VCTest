using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace TaskTest
{
    delegate void CallBack();//delegate

    class CountTest
    {

        public event CallBack countNumCallBack;//create
        public async void asyncCountFunc()
        {
            WebClient wc = new WebClient();
            Console.WriteLine("start");
            string result = await wc.DownloadStringTaskAsync(new Uri("http://www.microsoft.com"));
            Console.WriteLine("end");
        }

        public void countNumber()
        {
            for (int i = 0; i < 1000000; i++)
            {
                if (i % 12 == 0)
                {
                    //countNumCallBack();//Trigger
                }
            }
            countNumCallBack();//Trigger
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
            c.asyncCountFunc();
            c.countNumber();
            Console.ReadKey();
        }
    }
}
