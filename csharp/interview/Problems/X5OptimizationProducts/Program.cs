// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Threading;

int GetIndex(int n, List<int> price, List<int> amount, List<int> count, List<int> delivery)
{
  int res = -1;
  double total = -1;
  for (int i = 0; i < price.Count; i++)
  {
    if (count[i] <= 0)
      continue;
    int t = amount[i] * count[i];
    t = (t > n) ? n : t;
    int parts = t / amount[i];
    double totalWithDelivery = (parts * price[i] + delivery[i])/(double)t;
    if (total < 0 || totalWithDelivery < total) {
      total = totalWithDelivery;
      res = i;
    }
  }
  return res;
}

string GetResult(int n, List<int> price, List<int> amount, List<int> count, List<int> delivery)
{
  List<int> res = new List<int>(price.Count);
  while (n > 0)
  {
    var i = GetIndex(n, price, amount, count, delivery);
    if (i < 0)
      break;
    res.Add(i);
    int t = count[i] * amount[i];
    count[i] = 0;
  }

  return String.Join(",",res);
}

var price = new List<int> { 100, 200, 3000, 400 };
var amount = new List<int> { 50, 100, 500, 100 };
var count = new List<int> { 17, 36, 70, 45 };
var delivery = new List<int> { 1000, 500, 5000, 1000 };
Console.WriteLine(GetResult(28000, price, amount, count, delivery));
