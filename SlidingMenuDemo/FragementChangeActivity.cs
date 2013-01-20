using Android.App;
using Android.OS;
using Android.Support.V4.App;
using SlidingMenuDemo.Fragments;

namespace SlidingMenuDemo
{
  [Activity(MainLauncher = true)]
  public class FragementChangeActivity : BaseActivity
  {
    private Fragment mContent;

    public FragementChangeActivity() : base(Resource.String.changing_fragments)
    {
    }

    public override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      
      // set the above view
      if (savedInstanceState != null)
        mContent = SupportFragmentManager.GetFragment(savedInstanceState, "mContent");

      if (mContent == null)
        mContent = new ColorFragment(Resource.Color.red);

      // set the above view
      SetContentView(Resource.Layout.content_frame);
      SupportFragmentManager.BeginTransaction()
        .Replace(Resource.Id.content_frame, mContent)
        .Commit();

      // set the behind view
      SetBehindContentView(Resource.Layout.menu_frame);
      SupportFragmentManager
        .BeginTransaction()
        .Replace(Resource.Id.menu_frame, new ColorMenuFragment())
        .Commit();

      // customize the SlidingMenu
      SlidingMenu.TouchModeAbove = SlidingMenu.TouchModeAbove;
    }

    protected override void OnSaveInstanceState(Bundle outState)
    {
      base.OnSaveInstanceState(outState);
      SupportFragmentManager.PutFragment(outState, "mContent", mContent);
    }

    public void SwitchContent(Fragment fragment)
    {
      this.mContent = fragment;
      SupportFragmentManager
        .BeginTransaction()
        .Replace(Resource.Id.content_frame, fragment)
        .Commit();
      SlidingMenu.ShowContent();
    }
  }
}