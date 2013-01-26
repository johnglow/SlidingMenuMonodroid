using System;
using Android.App;
using Android.Content;
using Android.OS;
using SlidingMenu.Demo.Fragments;
using ActionBar = ActionbarSherlock.App.ActionBar;
using Fragment = Android.Support.V4.App.Fragment;

namespace SlidingMenu.Demo
{
  [Activity(Label = "About")]
  public class AboutActivity : BaseActivity
  {
    public AboutActivity() : base(Resource.Layout.About)
    {
    }

    public override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      SupportActionBar.NavigationMode = (int) ActionBarNavigationMode.Tabs;

      AddTab<About1Fragment>("Tab 1");
      AddTab<About2Fragment>("Tab 2");
      AddTab<About3Fragment>("Tab 3");
    }

    protected void AddTab<T>(string text) where T : Fragment, new()
    {
      SupportActionBar.AddTab(SupportActionBar.NewTab().SetText(text)
        .SetTabListener(new TabListener<T>(global::Android.Resource.Id.Content)));
    }

    protected override void OnPause()
    {
      base.OnPause();

      ISharedPreferences sharedPreferences = GetSharedPreferences("AboutActivity", FileCreationMode.Private);
      ISharedPreferencesEditor editor = sharedPreferences.Edit();

      editor.PutInt("Position", SupportActionBar.SelectedTab.Position);
      editor.Commit();
    }

    protected override void OnResume()
    {
      base.OnResume();

      ISharedPreferences sharedPreferences = GetSharedPreferences("AboutActivity", FileCreationMode.Private);
      int position = sharedPreferences.GetInt("Position", 0);

      ActionBar.Tab tabToSelect = SupportActionBar.GetTabAt(position);
      SupportActionBar.SelectTab(tabToSelect);
    }
  }
}