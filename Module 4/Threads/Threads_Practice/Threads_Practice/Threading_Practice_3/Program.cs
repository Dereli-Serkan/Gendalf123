using System;
using System.Threading;

namespace Threading_Practice_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            counter.x = 4;
            counter.y = 5;

            Thread myThread = new Thread(new ParameterizedThreadStart(Count));
            myThread.Start(counter);

            //...................
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Основной поток: " + i*counter.x * counter.y);
                Thread.Sleep(400);
            }
        }

        public static void Count(object obj)
        {
            for (int i = 0; i < 9; i++)
            {
                Counter c = (Counter)obj;

                Console.WriteLine("Второй поток:" + i * c.x * c.y);
                Thread.Sleep(400);
            }
        }
    }

    public class Counter
    {
        public int x;
        public int y;
    }
}

