using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using SlidingMenuBinding;
using SlidingMenuBinding.Lib;
using SlidingMenuBinding.Lib.App;

namespace SlidingMenuDemo
{
  //[Activity(Label = "MonoDroid Sliding Menu", MainLauncher = true, Icon = "@drawable/icon")]
  public class Activity1 : Activity
  {
    int count = 1;

    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      SetTitle(Resource.String.Title);
      SetContentView(Resource.Layout.Main);

      Button button = FindViewById<Button>(Resource.Id.MyButton);
      button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

      // Configure the SlidingMenu
      var menu = new SlidingMenu(this);
      menu.Mode = 0;
      menu.TouchModeAbove = SlidingMenu.TouchmodeFullscreen;
      menu.SetShadowWidthRes(Resource.Dimension.shadow_width);
      menu.SetShadowDrawable(Resource.Drawable.Shadow);
      menu.SetBehindOffsetRes(Resource.Dimension.slidingmenu_offset);
      menu.SetFadeDegree(0.35f);
      menu.AttachToActivity(this, SlidingMenu.SlidingContent);
      
      // Add in the menu view.
      menu.SetMenu(Resource.Layout.Main);
    }
  }
}