using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace SlidingMenuDemo.Fragments
{
  public class SampleListFragment : ListFragment
  {
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      return inflater.Inflate(Resource.Layout.list, null);
    }

    public override void OnActivityCreated(Bundle savedInstanceState)
    {
      base.OnActivityCreated(savedInstanceState);
      var adapter = new SampleAdapter(Activity);
      for (int i = 0; i < 20; i++) {
        adapter.Add(new SampleItem("MenuItem List", Android.Resource.Drawable.IcMenuSearch));
      }
      this.ListAdapter = adapter;
    }

    public class SampleItem
    {
      public string Tag { get; private set; }
      public int IconRes { get; private set; }

      public SampleItem(string tag, int iconRes)
      {
        Tag = tag;
        IconRes = iconRes;
      }
    }

    public class SampleAdapter : ArrayAdapter<SampleItem>
    {
      public SampleAdapter(Context context) : base(context, 0)
      {
      }

      public override View GetView(int position, View convertView, ViewGroup parent)
      {
        if (convertView == null)
        {
          convertView = LayoutInflater.From(this.Context).Inflate(Resource.Layout.row, null);
        }

        ImageView icon = (ImageView)convertView.FindViewById(Resource.Id.row_icon);
        icon.SetImageResource(GetItem(position).IconRes);

        TextView title = (TextView)convertView.FindViewById(Resource.Id.row_title);
        title.Text = GetItem(position).Tag;

        return convertView;
      }
    }
  }
}