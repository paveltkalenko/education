using System;
using System.Collections.Generic;

namespace part1
{
  class Program
  {
    private static Object syncObject = new Object();

    static void Main(string[] args)
    {
/*
      Что будет выведено на консоль? Варианты ответов:

      0, 1, 2, 3, 4, 5, 6, 7, 8, 9

    10, 10, 10, 10, 10, 10, 10, 10, 10, 10

    Код сгенерирует исключение

    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    */
      List<Action> actions = new List<Action>();
      for(var count=0; count<10; count++)
      {
          actions.Add(() => Console.WriteLine(count));
      }
      foreach(var action in actions)
      {
        action();
      }
      
      // Что будет выведено на консоль в результате следующих операций:
      int i = 1;
      object obj = i;
      ++i;
      Console.WriteLine(i);
      Console.WriteLine(obj);
      // Console.WriteLine((short)obj); выведет ошибку

      lock (syncObject)
      {
        Console.WriteLine("Hello World!");
        lock (syncObject)
        {
          Console.WriteLine("test");
          lock (syncObject)
          {
            Console.WriteLine("cdd");
          }
        }
      }
    }
    }
}
