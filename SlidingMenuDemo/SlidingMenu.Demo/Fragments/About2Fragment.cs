using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace SlidingMenu.Demo.Fragments
{
  public class About2Fragment : Fragment
  {
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      return inflater.Inflate(Resource.Layout.About2Fragment, container, false);
    }
  }
}