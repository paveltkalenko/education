using System;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace TredecimalNumbers
{
  class Program
  {
    ///Тестовое задание.
    // В данной задаче будут рассматриваться 13-ти значные числа в тринадцатиричной системе исчисления(цифры 0,1,2,3,4,5,6,7,8,9, A, B, C) с ведущими нулями.
    // Например, ABA98859978C0, 6789110551234, 0000007000000
    //Назовем число красивым, если сумма его первых шести цифр равна сумме шести последних цифр.
    //Пример:
    //Число 0055237050A00 - красивое, так как 0+0+5+5+2+3 = 0+5+0+A+0+0
    //Число 1234AB988BABA - некрасивое, так как 1+2+3+4+A+B != 8+8+B+A+B+A​
    //Задача:
    //написать программу на С# печатающую в стандартный вывод количество 13-ти значных красивых чисел с ведущими нулями в тринадцатиричной системе исчисления.

    // Система исчисления
    const byte RADIX = 13;

    // Значность чисел
    const byte BITNESS = 13;

    const byte HALF_BITNESS = (BITNESS % 2 > 0) ? (BITNESS - 1) / 2 : BITNESS / 2;

    public static int GetAmount(ulong u)
    {
      int sum = 0;
      for (int i = 0; i < HALF_BITNESS; i++)
      {
        sum += (byte)(u % RADIX);
        u /= RADIX;
      }
      return sum;
    }

    static void Main(string[] args)
    {
      var m = (ulong)Math.Pow(RADIX, HALF_BITNESS);
      // массив для подсчета кол-во комбинаций сумм разрядов.
      var tred = new ulong[(RADIX) * HALF_BITNESS];
      for (ulong i = 0; i < m; i++)
      {
        tred[GetAmount(i)]++;
      }
      ulong result = (ulong)tred.Sum(s => (decimal)s*s*((BITNESS%2>0)? RADIX:1) );
       Console.WriteLine(result);
    }
  }
}
