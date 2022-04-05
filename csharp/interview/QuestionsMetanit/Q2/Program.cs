using System;
using Q2;

namespace Q2
{
  public struct S : IDisposable
  {
    private bool dispose;

    public void Dispose()
    {
      dispose = true;
      Console.WriteLine("disposing...");
    }
    public bool GetDispose()
    {
      return dispose;
    }
  }
}
class Program
{
  static void Main(string[] args)
  {
    //var s = new S();
    using (var s = new S())
    {
      Console.WriteLine(s.GetDispose());
    }
    //Console.WriteLine(s.GetDispose());
    //Console.WriteLine("Hello World!");
  }
}
