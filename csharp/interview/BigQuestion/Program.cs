using System;

namespace EmployeeTest
{
  abstract class A
  {
    public virtual string Foo()
    {
      return "A"
      ;
    }
    public virtual string Bar()
    {
      return "A"
      ;
    }
  }
  class B : A
  {
    public override string Foo()
    {
      return "B"
      ;
    }
    public string Bar()
    {
      return "B"
      ;
    }
  }
  class C :B
  {
    public string Output(ref string input)
    {
      try
      {
        input = "1";
        return input;
      }
      finally
      {
        input = "2";
      }
    }
    public string Output(string input)
    {
      try
      {
        input = "3";
        return input;
      }
      finally
      {
        input = "4";
      }
    }

public int Output(ref int input)
    {
      input = 1;
      return input;
    }
    public int Output(int input
    )
    {
      input = 2;
      return input;
    }
  }

  public class Program
  {
    public static void Main(string[] args)
    {
      A b = new B();
      C c = new C();

      Console.WriteLine("01: {0}", b.Foo());

      Console.WriteLine("02: {0}", b.Bar());
      // Вопрос 3
      Console.WriteLine("03: {0}", c.Foo());
      // Вопрос 4
      Console.WriteLine("04: {0}", c.Bar());

      string input = "0"; // это - ноль
                          // Вопрос 5
      Console.WriteLine("05: {0}", c.Output(ref input));  //2 вернет 1 потом сработает finally и присвоится 2
      // Вопрос 6
      Console.WriteLine("06: {0}", input); //2
      // Вопрос 7
      Console.WriteLine("07: {0}", c.Output(input)); //4
      // Вопрос 8
      Console.WriteLine("08: {0}", input); //2

      int i = 0;
      // Вопрос 9
      Console.WriteLine("09: {0}", c.Output(ref i)); //мой ответ 1
      // Вопрос 10
      Console.WriteLine("10: {0}", i); // мой ответ 1
      // Вопрос 11
      Console.WriteLine("11: {0}", c.Output(i)); //мой ответ 2
      // Вопрос 12
      Console.WriteLine("12: {0}", i); //мой ответ 1

      i = 1;
      object o = 1;
      object o2 = 1;
      byte i2 = 1;
/*
      Если текущий экземпляр является типом значения, Equals(Object) метод проверяет равенство значений. Равенство значений означает следующее:

    Два объекта имеют один и тот же тип. Как показано в следующем примере, Byte объект со значением 12 не равен Int32 объекту со значением 12, 
    поскольку два объекта имеют разные типы времени выполнения.*/
      // Вопрос 13
      Console.WriteLine("13: {0}", o.Equals(i));

      Console.WriteLine("14: {0}", o.Equals(o2));

      Console.WriteLine("15: {0}", o.Equals(i2));
      // Вопрос 14
      Console.WriteLine("16: {0}", o == (object)i);

    }
  }
}
