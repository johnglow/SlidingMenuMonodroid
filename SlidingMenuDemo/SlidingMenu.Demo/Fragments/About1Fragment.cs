using Android.App;
using Android.OS;
using Android.Views;

namespace SlidingMenu.Demo.Fragments
{
  public class About1Fragment : global::Android.Support.V4.App.Fragment
  {
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      return inflater.Inflate(Resource.Layout.About1Fragment, container, false);
    }
  }
}