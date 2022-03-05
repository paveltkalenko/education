// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Weekend
{
  class Calendar
  {
    /// <summary>
    /// Считаем рабочие дни от стартовой даты(не включительно)
    /// </summary>
    /// <param name="workDays">рабочие дни</param>
    /// <param name="startDayed"></param>
    /// <param name="weekends"></param>
    /// <returns>Рабочий день</returns>
    public DateTime GetWorkDay(int workDays, DateTime startDayed, IEnumerable<DateTime> weekends)
    {
      DateTime current = startDayed;
      while(workDays != 0)
      {
    //    Console.WriteLine(current);
        current = current.AddDays(1);
        if (!weekends.Any(a => current == a))
        {
          workDays--;
        }
      }
      return current;
    }
  }
  public class Program
  {
    public static void Main(string[] args)
    {
      var calendar = new Calendar();
     // DateTime test = new DateTime(2022, 03, 03);
    //  test = test.AddDays(1);
      Console.WriteLine($"{calendar.GetWorkDay(3, new DateTime(2022, 03, 03), new List<DateTime>{new DateTime(2022,03,5)})}");
    }
  }
}