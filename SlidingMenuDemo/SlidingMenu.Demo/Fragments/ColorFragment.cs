using System;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace SlidingMenu.Demo.Fragments
{
  public class RedColorFragment : ColorFragment
  {
    public RedColorFragment()
      : base(Resource.Color.red)
    {
    }
  }

  public class BlueColorFragment : ColorFragment
  {
    public BlueColorFragment()
      : base(Resource.Color.blue)
    {
    }
  }

  public class GreenColorFragment : ColorFragment
  {
    public GreenColorFragment()
      : base(Resource.Color.green)
    {
    }
  }

  public abstract class ColorFragment : Fragment
  {
    private readonly int colorId;
    private int counter = 0;

    protected ColorFragment(int colorId)
    {
      this.colorId = colorId;
    }

    public override View OnCreateView(LayoutInflater intInflater, ViewGroup container, Bundle savedInstanceState)
    {
      View view = intInflater.Inflate(Resource.Layout.ColorFrame, container, false);
      view.SetBackgroundColor(Resources.GetColor(colorId));
      return view;
    }

    public override void OnViewCreated(View p0, Bundle p1)
    {
      base.OnViewCreated(p0, p1);

      var preferences = GetSharedPreferences();
      counter = preferences.GetInt("Counter", 0);

      var button = View.FindViewById<Button>(Resource.Id.button1);
      button.Text = string.Format("Clicked {0}", counter);
      button.Click += (sender, args) =>
      {
        counter++;
        button.Text = string.Format("Clicked {0}", counter);
      };
    }
    
    public override void OnPause()
    {
      base.OnPause();
      var preferences = GetSharedPreferences();
      var editor = preferences.Edit();
      editor.PutInt("Counter", counter);
      editor.Commit();
    }

    private ISharedPreferences GetSharedPreferences()
    {
      var sharedPreferences = Activity.GetSharedPreferences(GetType().Name, FileCreationMode.Private);
      return sharedPreferences;
    }
  }
}