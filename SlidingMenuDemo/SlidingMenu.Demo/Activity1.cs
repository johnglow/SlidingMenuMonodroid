using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using SlidingMenu.Demo.Fragments;
using SlidingMenuBinding.Lib.App;
using Fragment = Android.Support.V4.App.Fragment;

namespace SlidingMenu.Demo
{
  [Activity(Label = "Sliding Menu Demo", MainLauncher = true)]
  public class Activity1 : SlidingFragmentActivity
  {
    private Fragment menuFragment;
    private Fragment contentFragment;

    private const string ContentFragmentType = "ContentFragmentType";

    public override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      Console.WriteLine("OnCreated called");

      RequestWindowFeature(WindowFeatures.ActionBar);
      SetSlidingActionBarEnabled(true);

      menuFragment = new MenuFragment();

      var sharedPreferences = GetSharedPreferences();
      if (sharedPreferences != null && sharedPreferences.Contains(ContentFragmentType))
      {
        var contentType = sharedPreferences.GetString(ContentFragmentType, null);
        if (!string.IsNullOrEmpty(contentType))
        {
          switch (contentType)
          {
            case "RedColorFragment":
              contentFragment = new RedColorFragment();
              break;
            case "GreenColorFragment":
              contentFragment = new GreenColorFragment();
              break;
            case "BlueColorFragment":
              contentFragment = new BlueColorFragment();
              break;
          }
        }
      }
      else
      {
        contentFragment = new RedColorFragment();  
      }

      // Setup the menu
      SetBehindContentView(Resource.Layout.MenuFrame);
      SupportFragmentManager.BeginTransaction().Replace(Resource.Id.MenuFrame, menuFragment).Commit();

      // Setup the content
      SetContentView(Resource.Layout.ContentFrame);
      SupportFragmentManager.BeginTransaction().Replace(Resource.Id.ContentFrame, contentFragment).Commit();
      
      // Setup the sliding menu
      SlidingMenu.SetShadowWidthRes(Resource.Dimension.SlidingMenuShadowWidth);
      SlidingMenu.SetShadowDrawable(Resource.Drawable.SlidingMenuShadow);
      SlidingMenu.SetBehindOffsetRes(Resource.Dimension.SlidingmenuOffset);
      SlidingMenu.SetFadeDegree(0.35f);
      SlidingMenu.TouchModeAbove = SlidingMenuBinding.Lib.SlidingMenu.TouchmodeFullscreen;

      SupportActionBar.SetDisplayHomeAsUpEnabled(true);
    }

    public void SwitchContent(Fragment content)
    {
      contentFragment = content;
      SupportFragmentManager.BeginTransaction().Replace(Resource.Id.ContentFrame, contentFragment).Commit();
      SlidingMenu.ShowContent();
    }

    protected override void OnPause()
    {
      base.OnPause();
      var sharedPreferences = GetSharedPreferences();
      var editor = sharedPreferences.Edit();
      editor.PutString(ContentFragmentType, contentFragment.GetType().Name);
      editor.Commit();
    }

    public override bool OnOptionsItemSelected(ActionbarSherlock.View.IMenuItem item)
    {
      switch (item.ItemId)
      {
        case global::Android.Resource.Id.Home : 
          Toggle();
          return true;
      }

      return base.OnOptionsItemSelected(item);
    }
    
    private ISharedPreferences GetSharedPreferences()
    {
      var sharedPreferences = GetSharedPreferences(GetType().Name, FileCreationMode.Private);
      return sharedPreferences;
    }
  }
}