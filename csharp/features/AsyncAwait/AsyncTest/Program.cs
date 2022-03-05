using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      WriteCharAsync('#');
    }

    private static async Task WriteCharAsync(char symbol)
    {
      Console.WriteLine("Метод WriteCharAsync начал свою работу в потоке {0}", Thread.CurrentThread.ManagedThreadId);
      await Task.Run(() => WriteChar(symbol));
      Console.WriteLine("Метод WriteCharAsync окончил свою работу в потоке {0}", Thread.CurrentThread.ManagedThreadId);
    }

    private static void WriteChar(char symbol)
    {
      Console.WriteLine($"Id потока - [{Thread.CurrentThread.ManagedThreadId}]. Id задачи - [{Task.CurrentId}]");
      if (Thread.CurrentThread.IsThreadPoolThread) {
        Console.WriteLine("выполняется потоком из пула");
      }
    }

  }
}
