using System;
using System.Collections.Generic;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;

namespace SlidingMenuDemo
{
  public class BaseActivity : FragmentActivity
  {



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