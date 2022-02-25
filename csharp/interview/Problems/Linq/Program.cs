using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading.Tasks;

namespace Linq
{
  public static class test
  {
    public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> input, Func<T, Boolean> func)
    {
      foreach (var el in input)
      {
        if (func(el))
        {
          yield return el;
        }
      }

    }

    public static IEnumerable<T> MyWhereTwo<T>(this IEnumerable<T> input, Predicate<T> func)
    {
      IEnumerator<T> enumerator = input.GetEnumerator();
      while (enumerator.MoveNext())
      {
        if (func(enumerator.Current))
        {
          yield return enumerator.Current;
        }
      } 
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      var test = new List<int>() { 1, 2, 3 };
      var res = test.MyWhere(w => w >= 2);
      var res2 = test.MyWhereTwo(w => w >= 2);
      Console.WriteLine(String.Join(" ", res2));
      foreach (var el in res)
      {

        Console.WriteLine($"{el}");
      }
    }
  }
}
