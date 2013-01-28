using System;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace SlidingMenu.Demo.Fragments
{
  public class MenuFragment : ListFragment
  {
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      return inflater.Inflate (Resource.Layout.List, null);
    }

    public override void OnActivityCreated(Bundle savedInstanceState)
    {
      base.OnActivityCreated(savedInstanceState);
      var colors = Resources.GetStringArray(Resource.Array.ColorNames);

      var colorAdapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, colors);

      ListAdapter = colorAdapter;
    }

    public override void OnListItemClick(ListView lv, View v, int position, long id)
    {
      Fragment newContent = null;
      switch (position)
      {
        case 0:
          newContent = new RedColorFragment();
          break;
        case 1:
          newContent = new GreenColorFragment();
          break;
        case 2:
          newContent = new BlueColorFragment();
          break;
      }

      if (newContent !=null)
      {
        SwitchFragment(newContent);
      }
    }

    private void SwitchFragment(Fragment newContent)
    {
      // todo change this to use an interface
      var baseActivity = Activity as Activity1;
      if (baseActivity != null)
      {
        baseActivity.SwitchContent(newContent);
      }
    }
  }
}