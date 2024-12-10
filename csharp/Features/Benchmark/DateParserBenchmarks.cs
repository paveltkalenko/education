using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
namespace Benchmark
{
  [MemoryDiagnoser]
  [Orderer(SummaryOrderPolicy.FastestToSlowest)]
  [RankColumn]
  public class DateParserBenchmarks
  {
    private const string DateTime = "2019-12-13T16:33:06Z";
      private static readonly DateParser Parser = new DateParser();

      [Benchmark]
      public void GetYearFromDateTime()
      {
        Parser.GetYearFromDateTime(DateTime);
      }
    }
}