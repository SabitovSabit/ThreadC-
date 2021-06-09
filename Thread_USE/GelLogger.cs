using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Thread_USE
{
    public static class GelLogger
    {
        static readonly object _object = new object();
        static List<string> vs = new List<string>();
        static List<string> array = new List<string>();
        static string name = "logs.txt";
       
        public static void CreateLog()
        {
            int count = 0;
           
                while (true)
                {
                    count++;
                //Console.WriteLine($"log {count}" + " " + DateTime.Now + " \n ThreadId: " + Thread.CurrentThread.ManagedThreadId);                    
                lock (_object)
                {
                    vs.Add($"log {count}" + " " + DateTime.Now + " \n ThreadId: " + Thread.CurrentThread.ManagedThreadId);
                    //Console.WriteLine(vs.Count);
                }               
                }                       
        }
        //public static List<string> GetList()
        //{
        //    lock (_object)
        //    {
               
        //          foreach(var item in vs)
        //        {
        //            array.Add(item);
        //        }
                              
        //    }           
        //    return array;
        //}
        public static void WriteFile()
        {
            while (true)
            {                
                if (!File.Exists(name))
                {
                    File.Create(name);
                }                
                    using (StreamWriter writer = File.AppendText(name))
                    {
                        lock (_object)
                        {
                            
                            for(int i = 0; i < 100; i++)
                            {
                                writer.WriteLine(vs[i]);
                                Console.WriteLine(i);
                                vs.Remove(vs[i]);
                            }
                        }
                    }                
            }
        }
    }
}
