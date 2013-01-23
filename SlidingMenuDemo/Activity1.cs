using System;

using Android.App;
using Android.Content;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Support.V4.App;

using SlidingMenuBinding.Lib;
using SlidingMenuBinding.Lib.App;
using SlidingMenuDemo.Fragments;

namespace SlidingMenuDemo
{
  [Activity(Label = "My Activity", MainLauncher = true)]
  public class Activity1 : SlidingFragmentActivity
  {
    int count = 1;

    public override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      SetContentView(Resource.Layout.Main);
      SetBehindContentView(Resource.Layout.menu_frame);
      SupportFragmentManager.BeginTransaction().Replace(Resource.Id.menu_frame, new MenuFragment()).Commit();

      SlidingMenu.SetShadowWidthRes(Resource.Dimension.shadow_width);
      SlidingMenu.SetShadowDrawable(Resource.Drawable.Shadow);
      SlidingMenu.SetBehindOffsetRes(Resource.Dimension.slidingmenu_offset);
      SlidingMenu.SetFadeDegree(0.35f);
      SlidingMenu.TouchModeAbove = SlidingMenu.TouchmodeFullscreen;

      SupportActionBar.SetDisplayHomeAsUpEnabled(true);

      var button = FindViewById<Button>(Resource.Id.MyButton);
      button.Click += (object sender, EventArgs e) =>
      {
        button.Text = string.Format("{0} clicks!", count++);
      };
    }
  }
}