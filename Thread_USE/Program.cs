using System;
using System.Threading;

namespace Thread_USE
{
    public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                Thread thread = new Thread(GelLogger.CreateLog);
                thread.Start();
            }
            Thread thread1 = new Thread(GelLogger.WriteFile);
            thread1.Start();
        }
    }
}
