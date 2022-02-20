using System;
using System.Collections.Generic;
using System.Linq;

namespace Deconstruct
{
    public class Person
    {
        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Name {get;set;}

        public void Deconstruct(out string fullName, out DateTime dateOfBirth, out string name)
        {
            fullName = FullName;
            dateOfBirth = DateOfBirth;
            name = Name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var pavel = new Person
            {
                FullName = "Pavel Tkalenko",
                DateOfBirth = new DateTime(1987, 06, 28)
            };

            var dict = new Dictionary<string, int>
            {
              {"Pavel", 34}
            };
            var (k,v) = dict.First();
            Console.WriteLine($"key = {k} and value = {v}");
            var (fullName, dateOfBirth, _) = pavel;
            Console.WriteLine($"{fullName} and birth {dateOfBirth:dd.MM.yyyy}");
        }
    }
}
