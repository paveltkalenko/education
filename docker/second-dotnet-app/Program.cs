using System;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace second_dotnet_app
{
  class Program
  {
    static void Main(string[] args)
    {
      IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", true, true)
        .AddEnvironmentVariables()
        .Build();

      var keyValuePairs = configuration.AsEnumerable().ToList();
      foreach (var pair in keyValuePairs)
      {
        Console.WriteLine($"{pair.Key} - {pair.Value}");
      }
      Console.WriteLine(configuration["Message:Bye"]);
    }
  }
}
