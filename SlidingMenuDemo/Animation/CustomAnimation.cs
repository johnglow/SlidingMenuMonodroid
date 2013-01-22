using Android.OS;
using SlidingMenuBinding.Lib;
using SlidingMenuBinding.Lib.App;
using SlidingMenuDemo.Fragments;

namespace SlidingMenuDemo.Animation
{
  public abstract class CustomAnimation : BaseActivity
  {
    private SlidingMenu.ICanvasTransformer transformer;

    protected CustomAnimation(int titleRes, SlidingMenu.ICanvasTransformer transformer) : base(titleRes)
    {
      this.transformer = transformer;
    }

    public override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      
      // set the above view
      SetContentView(Resource.Layout.content_frame);
      SupportFragmentManager.BeginTransaction()
        .Replace(Resource.Id.content_frame, new SampleListFragment())
        .Commit();

      SlidingMenu sm = SlidingMenu;
      SetSlidingActionBarEnabled(true);
      sm.BehindScrollScale = 0.0f;
      //sm.SetBehindCanvasTransformer(this.transformer); // This doesn't work as it is missing from the binding
    }
  }
}