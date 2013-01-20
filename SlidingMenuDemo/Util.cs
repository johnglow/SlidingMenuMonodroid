using Android.Content;
using Android.Net;

namespace SlidingMenuDemo
{
  public class Util
  {
    public static void GoToGithub(Context context)
    {
      Uri uriUrl = Uri.Parse("http://github.com/jfeinstein10/slidingmenu");
      Intent launchBrowser = new Intent(Intent.ActionView, uriUrl);
      context.StartActivity(launchBrowser);
    }
  }
}