using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects; 
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject<Concert> subject = new Subject<Concert>();
            List<Concert> list1 = new List<Concert> { new Concert("Godsmack", "17.11.2018", "Arena Wien", 34), new Concert("Foo Fighter", "18.11.2018", "Stadthalle Wien", 79) };
            List<Concert> list2 = new List<Concert>();

            subject.Subscribe<Concert>(x => list2.Add(x));

            for (int i = 0; i < 2; i++)
            {
                subject.OnNext(list1[i]);
                Console.WriteLine(list2[i].ToString());
            }

            Console.WriteLine("Copied list.");

            for (int i = 10; i > 0; i--)
            {
                int counter = i;
                Task<string> spinOff = Task.Run(() => longandHardWork(counter * 1000));
                spinOff.ContinueWith(t => Console.WriteLine(t.Result));
            }

            Task<string> waity = longandHardWorkAsync(5000);
            waity.ContinueWith(x => Console.WriteLine(x.Result));
            Console.WriteLine("This should pop up before async finishes.");

            //wait for sleepyheads to finish
            System.Threading.Thread.Sleep(15000);
        }

        private static string longandHardWork(int duration)
        {
            Console.WriteLine("received:" + duration);
            System.Threading.Thread.Sleep(duration);
            return "Sleep time: " + duration;
        }

        private static async Task<string> longandHardWorkAsync(int duration)
        {
            Console.WriteLine("async received:" + duration);
            await Task.Delay(duration);

            return "Sleep time asynchron: " + duration;
        }

    }
}
