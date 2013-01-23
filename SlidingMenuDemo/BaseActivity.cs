using System;
using System.Collections.Generic;
using ActionbarSherlock.App;
using ActionbarSherlock.View;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Util;
using SlidingMenuBinding.Lib;
using SlidingMenuBinding.Lib.App;
using SlidingMenuDemo.Fragments;
using IMenu = global::ActionbarSherlock.View.IMenu;
using IMenuItem = global::ActionbarSherlock.View.IMenuItem;
using MenuItem = global::ActionbarSherlock.View.MenuItem;
using ISubMenu = global::ActionbarSherlock.View.ISubMenu;

namespace SlidingMenuDemo
{
  public class BaseActivity : SlidingFragmentActivity /*FragmentActivity*/
  {
    private int titleRes;
    protected ListFragment frag;

    public BaseActivity(int titleRes)
    {
      this.titleRes = titleRes;
    }

    public override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetTitle(titleRes);

      // set the Behind View
      SetBehindContentView(Resource.Layout.MenuFrame);
      FragmentTransaction t = this.SupportFragmentManager.BeginTransaction();
      frag = new SampleListFragment();
      t.Replace(Resource.Id.MenuFrame, frag);
      t.Commit();

      // customize the SlidingMenu
      SlidingMenu sm = SlidingMenu; // note: normally a method getSlidingMenu(); this looks retarded!
      sm.SetShadowWidthRes(Resource.Dimension.shadow_width);
      sm.SetShadowDrawable(Resource.Drawable.Shadow);
      sm.SetBehindOffsetRes(Resource.Dimension.slidingmenu_offset);
      sm.SetFadeDegree(0.35f);
      sm.TouchModeAbove = SlidingMenu.TouchmodeFullscreen;

      SupportActionBar.SetDisplayHomeAsUpEnabled(true);
    }

    public override bool OnOptionsItemSelected(IMenuItem item)
    {
      Log.Info("infro", "Octocat was clicked!");
      Util.GoToGithub(this);
      
      // TODO: For some reason (Probably API level) android.R.id.home is missing (We don't really need to go to github etc.)
//      switch (item.getItemId())
//      {
//        case android.R.id.home:
//          toggle();
//          return true;
//        case R.id.github:
//          Util.goToGitHub(this);
//          return true;
//      }
      
      return base.OnOptionsItemSelected(item);
    }

    public override bool OnCreateOptionsMenu(IMenu menu)
    {
      SupportMenuInflater.Inflate(Resource.Menu.main, menu);
      return true;
    }

    public class BasePagerAdapter : FragmentPagerAdapter
    {
      private List<Fragment> fragments = new List<Fragment>();
      private ViewPager viewPager;

      public BasePagerAdapter(FragmentManager fragmentManager, ViewPager viewPager) : base(fragmentManager)
      {
        this.viewPager = viewPager;
        viewPager.Adapter = this;
        for (int i = 0; i < 3; i++)
        {
          AddTab(new SampleListFragment());
        }
      }

      public void AddTab(Fragment tab)
      {
        fragments.Add(tab);
      }

      public override int Count
      {
        get { return fragments.Count; }
      }

      public override Fragment GetItem(int position)
      {
        return fragments[position];
      }
    }
  }
}