using System;
using System.Threading;

namespace ThreadsPool
{
  class Program
  {
    static void JobForAThread(object state)
    {
      if (Thread.CurrentThread.IsThreadPoolThread)
      {
        for (int i = 0; i < 30; i++)
        {
          Console.WriteLine("цикл {0}, выполнение внутри потока из пула {1}",
              i, Thread.CurrentThread.ManagedThreadId);
          Thread.Sleep(50);
        }
      } else 
      {
        for (int i = 0; i < 30; i++)
        {
          Console.WriteLine("отдельный поток цикл {0}",i);
          Thread.Sleep(50);
        }        
      }
    }
    static void Main(string[] args)
    {
      int worker, competition;
      ThreadPool.GetAvailableThreads(out worker, out competition);
      
      Console.WriteLine($"Hello World!worker = {worker}\t competition={competition}");
      for (int i = 0; i < 50; i++)
        ThreadPool.QueueUserWorkItem(JobForAThread);
      Thread.Sleep(10000);
      Console.WriteLine("sleep");
      
      for (int i = 0; i < 50; i++)
      {
        Thread myThread1 = new Thread(JobForAThread);
        myThread1.Start();
      }
      Console.WriteLine("End");
      Console.ReadLine();
    }
  }
}
