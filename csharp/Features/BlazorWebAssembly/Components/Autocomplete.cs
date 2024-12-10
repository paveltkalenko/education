using Microsoft.AspNetCore.Components;

namespace BlazorWebAssembly.Components;

public partial class Autocomplete<T>
{
  private string ll = "gerg2f";

  private Boolean popupShow = false;

  private string selectedElement = "dwdqq";

  private IList<string> elements = new List<string>
  {
    "one", "two", "three", "four", "five"
  };

  public Autocomplete()
  {

  }

  private void click(object e)
  {
    Console.WriteLine("click", e);
    popupShow = true;
    
    // inputString = SelectedString;
  }

  private void onInput(ChangeEventArgs e)
  {
    var SelectedString = e.Value.ToString();
    Console.WriteLine("It is definitely: " + SelectedString);
    // inputString = SelectedString;
  }


   [Parameter]
   public RenderFragment<T>? PopupListTemplate {get;set;}


  [Parameter]
  public Func<String, Task<IEnumerable<T>>> SearchAsync {get;set;}

}