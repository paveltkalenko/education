using System;

namespace question7
{
  public class A
  {
    public virtual void Print1()
    {
      Console.Write("A");
    }
    public void Print2()
    {
      Console.Write("A");
    }
  }
  public class B : A
  {
    public override void Print1()
    {
      Console.Write("B");
    }
  }
  public class C : B
  {
    public void Print2()
    {
      Console.Write("C");
    }
  }
  public class TestA
  {
    public void Method1()
    {
      Console.WriteLine("TEST A METHOD1 EXECUTED");
    }
  }

  public class TestB : TestA
  {
    public void Method1()
    {
      Console.WriteLine("TESTB METHOD1 EXECUTED");
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      var c = new C(); // c класс С
      A a = c;
      // метод класса A
      a.Print2();

      // метод класса B т.к. помечен virtual и имеет override на классе B
      a.Print1();

      // метод класса С
      c.Print2();

      Console.WriteLine("\nслед пример");
      var testa = new TestA();
      testa.Method1();
      testa = new TestB();
      testa.Method1();
      Console.WriteLine("Привидение");
      ((TestB)testa).Method1();
      var testb = new TestB();
      testb.Method1();
    }
  }
}
