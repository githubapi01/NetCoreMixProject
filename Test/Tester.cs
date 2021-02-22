using NetCoreMixProject.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreMixProject.Test
{
    public class Tester :ITest
    {
        public void Test()
        {
            "start".C();
            Task<int> t = AddAsync(1, 2);                             
            "wait 1 second.".C();
            Thread.Sleep(1000);
            "wake up".C();
            $"result: {t.Result}".C();
            "done".C();
            Console.ReadKey();
        }

        static int Add(int n, int m)
        {
            Thread.Sleep(3000);
            "Add".C();
            return n + m;
        }

        static async Task<int> AddAsync(int n, int m)
        {
            "AddAsync start".C();
            int val = await Task.Run(() => Add(n, m));
            "AddAsync end".C();
            return val;
        }
    }
}
