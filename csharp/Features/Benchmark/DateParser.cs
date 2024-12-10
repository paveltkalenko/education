using System;

namespace Benchmark
{
    public class DateParser
    {
        public int GetYearFromDateTime(string dateTimeAsString)
        {
          var dateTime = DateTime.Parse(dateTimeAsString);
          return dateTime.Year;
        }
    }
}