using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyAuto.CSharpCore
{
    public class MyWait
    {
        public void Wait()
        {
            Console.WriteLine("开始执行线程:{0},Sleep5.", Thread.CurrentThread.ManagedThreadId.ToString());
            Thread.Sleep(5 * 1000);
            Console.WriteLine("{0}线程执行结束。", Thread.CurrentThread.ManagedThreadId.ToString());
        }
        public  Task TaskWait()
        {
            return new Task(() => Wait());
        }
        public async Task TaskWaitAsync()
        {
            int result = 0;
            var a = new Task(() => Wait());
            var b = new Task(() => WaitSecond());
            var c = new Task(() => Wait(8));
            var d = new Task<int>(() => WaitWith(2));
            a.Start();
            b.Start();
            c.Start();
            d.Start();
            await b;
            result = d.Result;
            Task.WaitAll(a, b, c, d);
            
        }

        public void WaitSecond()
        {
            Console.WriteLine("开始执行线程:{0},Sleep3.", Thread.CurrentThread.ManagedThreadId.ToString());
            Thread.Sleep(3 * 1000);
            Console.WriteLine("{0}线程执行结束。", Thread.CurrentThread.ManagedThreadId.ToString());
        }
        public Task TaskWaitSecond()
        {
            return new Task(() => WaitSecond());
        }

        public void Wait(int time)
        {
            Console.WriteLine("开始执行线程:{0},Sleep{1}.", Thread.CurrentThread.ManagedThreadId.ToString(), time);
            Thread.Sleep(time * 1000);
            Console.WriteLine("{0}线程执行结束。", Thread.CurrentThread.ManagedThreadId.ToString());
        }
        public Task TaskWait(int time)
        {
            return new Task(() => Wait(time));
        }

        public int WaitWith(int time)
        {
            Console.WriteLine("开始执行线程:{0},Sleep{1}.", Thread.CurrentThread.ManagedThreadId.ToString(), time);
            Thread.Sleep(time * 1000);
            Console.WriteLine("{0}线程执行结束。", Thread.CurrentThread.ManagedThreadId.ToString());
            return time;
        }
        public Task<int> TaskWaitWith(int time)
        {
            return new Task<int>(() => WaitWith(time));
        }

    }
}
