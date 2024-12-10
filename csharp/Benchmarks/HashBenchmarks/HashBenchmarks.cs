using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace HashBenchmarks;

[MemoryDiagnoser]
[SimpleJob(launchCount: -1, iterationCount: 5,
    warmupCount: -1)]
public class HashBenchmarks
{

  // private object anonymous;

  // private (Guid, int, DateTime) tuple;

  private HashSet<(Guid, int, DateTime)> _hash;

  private HashSet<Object> _hashobject; 

   private Guid g;

   private DateTime dt;

   private Int32 value;

   public HashBenchmarks()
   {
      
      _hash = new HashSet<(Guid, int, DateTime)>();
      _hashobject = new HashSet<Object>();
      for (int i = 0; i < 100; i++)
      {
         var g1 = Guid.NewGuid();
         var dt1 = DateTime.UtcNow.AddMinutes(i);
         var value1 = (int)(dt.Ticks+i*100);
         _hash.Add((g1,value1,dt1));
         _hashobject.Add(new {uid = g1, date = dt1, value = value1});
         if (i == 50)
         {
            g = g1;
            dt = dt1;
            value = value1;
         }
      }

   }

   [Benchmark]
   public void HashCodeFromAnonymous()
   {
      var exist = _hashobject.Contains(new {uid = g, date = dt, value = value});
     // Console.WriteLine(exist);
   }



      [Benchmark]
   public void HashCodeFromTuple()
   {
      var exist = _hash.Contains((g, value, dt));
    //  Console.WriteLine(exist);
   }




}
