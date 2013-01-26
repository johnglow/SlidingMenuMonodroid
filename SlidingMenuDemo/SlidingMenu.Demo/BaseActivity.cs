using Android.OS;
using Android.Views;
using SlidingMenu.Demo.Fragments;
using SlidingMenuBinding.Lib;
using SlidingMenuBinding.Lib.App;

namespace SlidingMenu.Demo
{
  public abstract class BaseActivity : SlidingFragmentActivity
  {
    private readonly int layoutResId;

    protected BaseActivity(int layoutResId)
    {
      this.layoutResId = layoutResId;
    }

    public override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      RequestWindowFeature(WindowFeatures.ActionBar);

      SetContentView(layoutResId);
      SetBehindContentView(Resource.Layout.Menu);

      SupportFragmentManager
        .BeginTransaction()
        .Replace(Resource.Id.Menu, new MenuFragment())
        .Commit();

      SlidingMenu.SetShadowWidthRes(Resource.Dimension.SlidingMenuShadowWidth);
      SlidingMenu.SetBehindOffsetRes(Resource.Dimension.SlidingmenuOffset);
      SlidingMenu.SetShadowDrawable(Resource.Drawable.SlidingMenuShadow);
      SlidingMenu.TouchModeAbove = SlidingMenuBinding.Lib.SlidingMenu.TouchmodeFullscreen;
      SlidingMenu.SetFadeDegree(0.35f);
    }
  }
}