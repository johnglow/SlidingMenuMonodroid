using ActionbarSherlock.App;
using Android.Support.V4.App;

namespace SlidingMenu.Demo.Fragments
{
  public class TabListener<T> : Java.Lang.Object, ActionBar.ITabListener where T : Fragment, new()
  {
    private readonly T fragment;
    private readonly int contentResourceId;

    public TabListener(int contentResourceId)
    {
      this.contentResourceId = contentResourceId;
      fragment = new T();
    }

    protected TabListener(T fragment)
    {
      this.fragment = fragment;
    }

    public void OnTabReselected(ActionBar.Tab tab, FragmentTransaction ft)
    {
    }

    public void OnTabSelected(ActionBar.Tab tab, FragmentTransaction ft)
    {
      ft.Add(contentResourceId, fragment, typeof(T).FullName);
    }

    public void OnTabUnselected(ActionBar.Tab tab, FragmentTransaction ft)
    {
      ft.Remove(fragment);
    }
  }
}