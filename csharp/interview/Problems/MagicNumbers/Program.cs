using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace MagicNumbers
{
  class Program
  {
    static List<ulong> cachedNumbers;
    static ulong GetMagicNumber(int i) 
    {
      if (i < 1) throw new Exception("ошибка");
      if (cachedNumbers is null)
      {
        cachedNumbers = new List<ulong>(100000);
      } 
      if (i > 2)
      {
        if (cachedNumbers.Count() + 2 >= i)
        {// Console.WriteLine("from cache");
          return cachedNumbers[i - 3];
        }
        ulong sum = 0;
        if (i < 26)
        {
          for (int idx = 1; idx < i; idx++)
          {
            sum += GetMagicNumber(idx);
          }
        } else if (i%2==0)
        { // четное 
          for (int idx = i-25 ; idx < i; idx+=2)
          {
            sum += GetMagicNumber(idx);
          }
        } else 
        {
          for (int idx = i-25; idx < i; idx += 2)
          { 
            sum += GetMagicNumber(idx);
          }
        }
        if (cachedNumbers.Count() + 3 == i)
        {
          cachedNumbers.Add(sum);
        }
        return sum;
      } 
      
      return (ulong)(i == 2 ? 2 : 1);
      
    }

    
    static IEnumerable<UInt64> GetMagicNumber2()
    {
      var cachedNumber = new List<UInt64>(100001);
      yield return (UInt64)1;
      cachedNumber.Add(1);
      yield return (ulong)2;
      cachedNumber.Add(2);
      int i = 2;
      while (i<100001)
      {
        i++;
        UInt64 result = 0;
        if (i < 26)
        {
          for (int idx = 1; idx < i; idx++)
          {
            result += cachedNumber[idx-1];
          }
        }
        else
        { // четное 
          for (int idx = i - 25; idx < i; idx += 2)
          {
            result += cachedNumber[idx-1];
          }
        }
        if (cachedNumber.Count() < i)
        {
          cachedNumber.Add(result);
        }
        yield return result;
      }
    }
  
    static void Main(string[] args)
    {
      foreach (var item in GetMagicNumber2().Skip(99999).Take(1))
      {
        Console.WriteLine("{0}", item);
      }

    }
  }
}
