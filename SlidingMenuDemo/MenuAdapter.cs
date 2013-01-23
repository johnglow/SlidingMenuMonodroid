using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace SlidingMenuDemo
{
  public class MenuFragment : ListFragment
  {
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      var view = inflater.Inflate(Resource.Layout.list, null);
      return view;
    }

    public override void OnActivityCreated(Bundle savedInstanceState)
    {
      base.OnActivityCreated(savedInstanceState);
      ListAdapter = new MenuAdapter(Activity);
    }

    public override void OnListItemClick(ListView p0, View p1, int p2, long p3)
    {
      base.OnListItemClick(p0, p1, p2, p3);

      Log.Info("MenuFragment", "Menu item clicked!");
    }

    public class MenuItem
    {
      public MenuItem(string name, Type screen)
      {
        Name = name;
        Screen = screen;
      }

      public int Icon;
      public string Name;
      public Type Screen;
    }

    class MenuItemHeader
    {
      public string Name;
      public int SectionIndex;
    }

    public class MenuAdapter : BaseAdapter<MenuItem>
    {
      static readonly Dictionary<string, List<MenuItem>> samples = new Dictionary<string, List<MenuItem>>() 
      {
        { 
          "Section 1", 
          new List<MenuItem>() {
            new MenuItem ("Item 1", typeof(FragmentChangeActivity)),
            new MenuItem ("Item 2", typeof(FragmentChangeActivity)),
            new MenuItem ("Item 3", typeof(FragmentChangeActivity)),
            new MenuItem ("Item 4", typeof(FragmentChangeActivity)),
          } 
        },
        { 
          "Section 2", 
          new List<MenuItem>() {
            new MenuItem ("Item 1", typeof(FragmentChangeActivity)),
            new MenuItem ("Item 2", typeof(FragmentChangeActivity)),
            new MenuItem ("Item 3", typeof(FragmentChangeActivity)),
          } 
        },
        { 
          "Section 3", 
          new List<MenuItem>() {
            new MenuItem ("Item 1", typeof(FragmentChangeActivity)),
            new MenuItem ("Item 2", typeof(FragmentChangeActivity)),
          } 
        },
        { 
          "Section 4", 
          new List<MenuItem>() {
            new MenuItem ("Item 1", typeof(FragmentChangeActivity)),
          } 
        },
        { 
          "Section 5", 
          new List<MenuItem>() {
            new MenuItem ("Item 1", typeof(FragmentChangeActivity)),
            new MenuItem ("Item 2", typeof(FragmentChangeActivity)),
            new MenuItem ("Item 3", typeof(FragmentChangeActivity)),
            new MenuItem ("Item 4", typeof(FragmentChangeActivity)),
          } 
        },
      };

      const int TypeSectionHeader = 0;
      const int TypeSectionSample = 1;

      readonly Activity context;
      readonly IList<object> rows = new List<object>();

      readonly ArrayAdapter<string> headers;
      readonly Dictionary<string, IAdapter> sections = new Dictionary<string, IAdapter>();

      public MenuAdapter(Activity context)
      {
        this.context = context;
        headers = new ArrayAdapter<string>(context, Resource.Layout.HomeSectionHeader, Resource.Id.Text1);

        rows = new List<object>();
        foreach (var section in samples.Keys)
        {
          headers.Add(section);
          sections.Add(section, new ArrayAdapter<MenuItem>(context, Resource.Layout.MenuItem, samples[section]));
          rows.Add(new MenuItemHeader { Name = section, SectionIndex = sections.Count - 1 });
          foreach (var session in samples[section])
          {
            rows.Add(session);
          }
        }
      }

      public MenuItem GetMenuItem(int position)
      {
        return (MenuItem)rows[position];
      }

      public override MenuItem this[int position]
      {
        get
        { // this'll break if called with a 'header' position
          return (MenuItem)rows[position];
        }
      }

      public override int ViewTypeCount
      {
        get
        {
          return 1 + sections.Values.Sum(adapter => adapter.ViewTypeCount);
        }
      }

      public override int GetItemViewType(int position)
      {
        return rows[position] is MenuItemHeader
            ? TypeSectionHeader
            : TypeSectionSample;
      }

      public override long GetItemId(int position)
      {
        return position;
      }

      public override int Count
      {
        get { return rows.Count; }
      }

      public override bool AreAllItemsEnabled()
      {
        return true;
      }

      public override bool IsEnabled(int position)
      {
        return !(rows[position] is MenuItemHeader);
      }

      public override View GetView(int position, View convertView, ViewGroup parent)
      {
        var item = rows[position];
        View view;

        var menuItemHeader = item as MenuItemHeader;
        if (menuItemHeader != null)
        {
          view = headers.GetView(menuItemHeader.SectionIndex, convertView, parent);
          view.Clickable = false;
          view.LongClickable = false;
        }
        else
        {
          view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.MenuItem, null);
          view.FindViewById<TextView>(Resource.Id.Text1).Text = ((MenuItem)item).Name;
          view.FindViewById<TextView>(Resource.Id.Text2).Text = "Testing";
          view.FindViewById<ImageView>(Resource.Id.Icon).SetImageResource(Android.Resource.Drawable.IcMenuSearch);
        }

        return view;
      }
    }
  }
}