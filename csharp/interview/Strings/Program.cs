using System;
using System.Text;

var str1 = 1 + 2 + "A";
Console.WriteLine(1 + 2 + 'A'); //68

Console.WriteLine(1 + 'A' + 2); //68

Console.WriteLine('A' + 1 + 2); //68


Console.WriteLine(((String)null + null + null) == null); //False

Console.WriteLine(((String)null + null + null) == (String)null); //False

Console.WriteLine(((String)null + null + null) == ""); //True

Console.WriteLine(((String)null + null + null) == (String)null + null); //True

Console.WriteLine("=======Интернирование=====");
string a = new string(new char[] { 'a', 'b', 'c' });
object o = String.Copy(a);
Console.WriteLine(object.ReferenceEquals(o, a)); // выведет false т.к. ссылаются на разные объекты
String.Intern(o.ToString()); // добавляет в пул интернирования ссылку(объект o) на строку o
Console.WriteLine(object.ReferenceEquals(o, String.Intern(a))); // True String.Intern(a) возвращает ссылку (объект o) на строку

object o2 = String.Copy(a);
String.Intern(o2.ToString()); // o2 ничего не добавляет но возвращает ссылку (объект o) на строку 
Console.WriteLine(object.ReferenceEquals(o2, String.Intern(a))); //false т.к. o2 ссылается на отличное от объекта o место.
//Console.WriteLine(1 + 'A')
Console.WriteLine("---Задача что выведет код?---");
String x = "AB";
String y = new StringBuilder().Append('A').Append('B').ToString();
String z = String.Intern(y); // Т.к. существует литерал AB в переменной x, а он уже интернирован то ввернется ссылка на X
Console.WriteLine(x == y); // true
Console.WriteLine(y == z); // true
Console.WriteLine(x == z); // True
Console.WriteLine((Object)x == (Object)y); //False
Console.WriteLine((Object)x == (Object)z); //True
Console.WriteLine((Object)y == (Object)z); //False