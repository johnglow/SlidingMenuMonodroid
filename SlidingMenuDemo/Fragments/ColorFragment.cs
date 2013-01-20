using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace SlidingMenuDemo.Fragments
{
  public class ColorFragment : Fragment
  {
    private int mColorRes = -1;

    public ColorFragment()
    {
    }

    public ColorFragment(int mColorRes)
    {
      this.mColorRes = mColorRes;
      RetainInstance = true;
    }

    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      if (savedInstanceState != null)
      {
        mColorRes = savedInstanceState.GetInt("mColorRes");
      }
      Color color = Resources.GetColor(mColorRes);
      // construct the RelativeLayout
      RelativeLayout view = new RelativeLayout(Activity);
      view.SetBackgroundColor(color);
      return view;
    }

    public override void OnSaveInstanceState(Bundle outState)
    {
      base.OnSaveInstanceState(outState);
      outState.PutInt("mColorRes", mColorRes);
    }
  }
}