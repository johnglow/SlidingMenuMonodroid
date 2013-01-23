using System;
using ActionbarSherlock.App;
using Android.App;
using Android.Content;
using Android.Preferences;
using Android.Runtime;
using Android.Util;
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
  public class Activity1 : SlidingFragmentActivity, ActionBar.ITabListener
  {
    int count = 1;

    public override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      // Activate the action bar and display it in navigation mode.
      RequestWindowFeature(WindowFeatures.ActionBar);

      SetContentView(Resource.Layout.Main);
      SetBehindContentView(Resource.Layout.menu_frame);
      SupportFragmentManager.BeginTransaction().Replace(Resource.Id.menu_frame, new MenuFragment()).Commit();

      SlidingMenu.SetShadowWidthRes(Resource.Dimension.shadow_width);
      SlidingMenu.SetShadowDrawable(Resource.Drawable.Shadow);
      SlidingMenu.SetBehindOffsetRes(Resource.Dimension.slidingmenu_offset);
      SlidingMenu.SetFadeDegree(0.35f);
      SlidingMenu.TouchModeAbove = SlidingMenu.TouchmodeFullscreen;


      // We have to use the ActionBarSherlock ActionBar
      ActionBar actionBar = SupportActionBar;

      // Set the action bar to Tab mode
      actionBar.NavigationMode = ActionBar.NavigationModeTabs;

      // Create a new tab (CreateTabSpec on the TabControl)
      var tab1 = actionBar.NewTab().SetTabListener(this).SetText("Tab 1");
      var tab2 = actionBar.NewTab().SetTabListener(this).SetText("Tab 2");
      var tab3 = actionBar.NewTab().SetTabListener(this).SetText("Tab 3");
      
      actionBar.AddTab(tab1);
      actionBar.AddTab(tab2);
      actionBar.AddTab(tab3);

      //SupportActionBar.SetDisplayHomeAsUpEnabled(true);

      var button = FindViewById<Button>(Resource.Id.MyButton);
      button.Click += (object sender, EventArgs e) =>
      {
        button.Text = string.Format("{0} clicks!", count++);
      };
    }

    void ActionBar.ITabListener.OnTabSelected(ActionBar.Tab tab, FragmentTransaction ft)
    {
      Console.WriteLine("Tab Selected");
      Log.Info("Activity1", "Tab Selected");

//      TitlesFragment titleFrag = (TitlesFragment)FragmentManager.FindFragmentById(Resource.Id.frag_title);
//      titleFrag.PopulateTitles(tab.Position);
//      titleFrag.SelectPosition(0);
    }

    void ActionBar.ITabListener.OnTabUnselected(ActionBar.Tab tab, FragmentTransaction ft)
    {

    }

    void ActionBar.ITabListener.OnTabReselected(ActionBar.Tab tab, FragmentTransaction ft)
    {

    }
  }
}