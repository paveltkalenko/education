static int GetResult(List<int> parcels, int m)
{
  int result = 0;
  List<int> sortedParcels = new List<int>(parcels);
  sortedParcels.Sort();
  int l = 0, r = sortedParcels.Count - 1;
  while(l != r) 
  {
    if (sortedParcels[l]+sortedParcels[r] > m) 
    {
      r--;
    } else if (sortedParcels[l]+sortedParcels[r] < m)
    {
      l++;
    } else if (sortedParcels[l]+sortedParcels[r] == m)
    {
      result++;
      l++;
    }
  }
  return result;
}
// See https://aka.ms/new-console-template for more information
Console.WriteLine(GetResult( new List<int>{2,4,3,6,1}, 5));
