using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace SlidingMenu.Demo.Fragments
{
  public class MenuFragment : global::Android.Support.V4.App.ListFragment
  {
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      return inflater.Inflate(Resource.Layout.MenuList, null);
    }

    public override void OnActivityCreated(Bundle savedInstanceState)
    {
      base.OnActivityCreated(savedInstanceState);

      ListAdapter = new MenuAdapter(Activity);
    }

    public override void OnListItemClick(ListView listView, View view, int position, long id)
    {
      MenuItem menuItem = ((MenuAdapter)ListAdapter).GetMenuItem(position);

      var intent = new Intent(Activity, menuItem.Activity);
      StartActivity(intent);
    }

    public class MenuItem
    {
      public MenuItem(string name, Type activity)
      {
        Name = name;
        Activity = activity;
      }

      public int Icon;
      public string Name;
      public Type Activity;
    }

    public class MenuSection
    {
      public string Name;
      public int SectionIndex;
    }

    public class MenuAdapter : BaseAdapter<MenuItem>
    {
      const int TypeSectionHeader = 0;
      const int TypeSectionSample = 1;

      readonly Activity context;
      readonly IList<object> rows = new List<object>();

      readonly ArrayAdapter<string> headers;
      readonly Dictionary<string, IAdapter> sections = new Dictionary<string, IAdapter>();

      static readonly Dictionary<string, List<MenuItem>> menuItems = new Dictionary<string, List<MenuItem>>
      {
        { 
          "Section 1", 
          new List<MenuItem> {
            new MenuItem ("Main", typeof(MainActivity)),
            new MenuItem ("About", typeof(AboutActivity)),
            new MenuItem ("Login", typeof(LoginActivity)),
          } 
        },
      };

      public MenuAdapter(FragmentActivity context)
      {
        this.context = context;
        headers = new ArrayAdapter<string>(context, Resource.Layout.MenuSection, Resource.Id.MenuSectionText);

        rows = new List<object>();
        foreach (var section in menuItems.Keys)
        {
          headers.Add(section);
          
          sections.Add(section, new ArrayAdapter<MenuItem>(context, Resource.Layout.MenuItem, menuItems[section]));
          
          rows.Add(new MenuSection { Name = section, SectionIndex = sections.Count - 1 });

          foreach (var session in menuItems[section])
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
        {
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
        return rows[position] is MenuSection
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
        return !(rows[position] is MenuSection);
      }

      public override View GetView(int position, View convertView, ViewGroup parent)
      {
        var item = rows[position];
        View view;

        var menuItemHeader = item as MenuSection;
        if (menuItemHeader != null)
        {
          view = headers.GetView(menuItemHeader.SectionIndex, convertView, parent);
          view.Clickable = false;
          view.LongClickable = false;
        }
        else
        {
          view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.MenuItem, null);
          view.FindViewById<TextView>(Resource.Id.MenuItemText1).Text = ((MenuItem)item).Name;
        }

        return view;
      }
    }
  }
}