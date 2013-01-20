using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace SlidingMenuDemo.Fragments
{
  public class ColorMenuFragment : ListFragment
  {
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      return inflater.Inflate(Resource.Layout.list, null);
    }

    public override void OnActivityCreated(Bundle savedInstanceState)
    {
      base.OnActivityCreated(savedInstanceState);
      string[] colours = Resources.GetStringArray(Resource.Array.color_names);
      var colorAdapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, colours);
      ListAdapter = colorAdapter;
    }

    public override void OnListItemClick(ListView listView, View view, int position, long id)
    {
      Fragment newContent = null;

      switch(position)
      {
        case 0: newContent = new ColorFragment(Resource.Color.red); break;
        case 1: newContent = new ColorFragment(Resource.Color.green); break;
        case 2: newContent = new ColorFragment(Resource.Color.blue); break;
        case 3: newContent = new ColorFragment(Resource.Color.white); break;
        case 4: newContent = new ColorFragment(Resource.Color.black); break;
      }

      if (newContent != null)
      {
        SwitchFragment(newContent);
      }
    }

    // the meat of switching the above fragment
    private void SwitchFragment(Fragment fragment)
    {
      if (Activity == null)
        return;

      if (Activity is FragmentChangeActivity)
      {
        var activity = (FragmentChangeActivity) Activity;
        activity.SwitchContent(fragment);
      }

      // TODO
//      if (Activity is ResponsiveUIActivity)
//      {
//        ResponsiveUIActivity ra = (ResponsiveUIActivity)Activity;
//        ra.SwitchContent(fragment);
//      }
    }
  }
}