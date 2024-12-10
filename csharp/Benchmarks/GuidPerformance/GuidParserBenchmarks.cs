using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Google.Protobuf;

namespace GuidPerformance;

[MemoryDiagnoser]
[SimpleJob(launchCount: -1, iterationCount: 5,
    warmupCount: -1)]
public class GuidParserBenchmarks
{

   private readonly Guid guid;
   private readonly Guid guid2;

   private readonly String guidString;

   private readonly String guidString2;

   private readonly byte[] guidArray;
   private readonly byte[] guidArray2;

   private readonly ByteString guidBs;

    public GuidParserBenchmarks()
    {
      guid = Guid.NewGuid();
      guid2 = Guid.NewGuid();
      guidString = guid.ToString();
      guidString2 = guid2.ToString();
      guidArray = guid.ToByteArray();
      guidArray2 = guid2.ToByteArray();

      var b = guid.ToByteArray();
      var bs = ByteString.CopyFrom(b);
		
    }

   [Benchmark]
   public void GuidToString()
   {
      var b = guid.ToString();
   }
   
   [Benchmark]
   public void GuidParseString1()
   {
      var b = new Guid(guidString);
   }

   [Benchmark]
   public void GuidParseString2()
   {
      var b = Guid.Parse(guidString);
   }


   [Benchmark]
   public void GuidEqualsString1()
   {
      var g = Guid.Parse(guidString2);
      var b = g == guid;
   }

   [Benchmark]
   public void GuidEqualsString2()
   {
      var str = guid.ToString();
      var b = str == guidString2;
   }

   [Benchmark]
   public void GuidToTwoInt64AndParse()
   {
		Span<byte> sp  = stackalloc byte[16];
		var b = guid.TryWriteBytes(sp);
		var l = BitConverter.ToInt64(sp);
		var l2 = BitConverter.ToInt64(sp.Slice(8,8));
		Span<byte> sp2 = stackalloc byte[16];

		BitConverter.TryWriteBytes(sp2, l);
		BitConverter.TryWriteBytes(sp2.Slice(8,8), l2);
		var gg = new Guid(sp2);
   }


/*
   [Benchmark]
   public void GuidToByteString()
   {
      var b = guid.ToByteArray();
      var bs = ByteString.CopyFrom(b);
   }

   [Benchmark]
   public void GuidToByteString()
   {
      var b = guid.ToByteArray();
      Repeated
      var bs = ByteString.CopyFrom(b);
   }

      [Benchmark]
   public void GuidParseByteString()
   {
      var bs = guidBs.ToArray();
      var b = new Guid(bs);
   }
*/
/*

   [Benchmark]
   public void GuidParseArray()
   {
      var b = new Guid(guidArray);
   }
   */



/*
   [Benchmark]
   public void GuidTwoArrayEquals()
   {
      var b= Array.Equals(guidArray, guidArray2);
   }

   [Benchmark]
   public void GuidTwoStringEquals()
   {
      var b = guidString == guidString2;
   }
*/
/*
   [Benchmark]
   public void GuidEquals()
   {
      var b = guid == guid2;
   }
   
   [Benchmark]
   public void GuidEquals2()
   {
      var b = guid.Equals(guid2);
   }
*/
}
