using System;
using ActionbarSherlock.App;
using ActionbarSherlock.View;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Text;
using Android.Util;
using Android.Widget;
using Java.Net;

namespace SlidingMenuDemo
{
  [Activity(MainLauncher = true)]
  public class ExampleListActivity : SherlockPreferenceActivity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetTitle(Resource.String.ApplicationName);
      AddPreferencesFromResource(Resource.Xml.main);
    }

    public override bool OnPreferenceTreeClick(PreferenceScreen preferenceScreen, Preference preference)
    {
      Type type = null;
      var title = preference.Title;

      type = typeof(FragmentChangeActivity); // todo implement the rest of the examples!
      
      if (title.Equals(GetString(Resource.String.properties)))
      {
        Log.Info("ExampleListActivity", "Properties example is not implemented yet");
      }
      else if (title.Equals(GetString(Resource.String.attach)))
      {
        Log.Info("ExampleListActivity", "Attach example is not implemented yet");
      }
      else if (title.Equals(GetString(Resource.String.changing_fragments)))
      {
        type = typeof (FragmentChangeActivity);
      }
      else if (title.Equals(GetString(Resource.String.left_and_right)))
      {
        Log.Info("ExampleListActivity", "Left & Right example is not implemented yet");
      }
      else if (title.Equals(GetString(Resource.String.responsive_ui)))
      {
        Log.Info("ExampleListActivity", "Responsive UI example is not implemented yet");
      }
      else if (title.Equals(GetString(Resource.String.viewpager)))
      {
        Log.Info("ExampleListActivity", "View pager example is not implemented yet");
      }
      else if (title.Equals(GetString(Resource.String.title_bar_slide)))
      {
        Log.Info("ExampleListActivity", "Sliding title bar example is not implemented yet");
      }
      else if (title.Equals(GetString(Resource.String.title_bar_content)))
      {
        Log.Info("ExampleListActivity", "Sliding content example is not implemented yet");
      }
      else if (title.Equals(GetString(Resource.String.anim_zoom)))
      {
        Log.Info("ExampleListActivity", "Custom zoom animation example is not implemented yet");
      }
      else if (title.Equals(GetString(Resource.String.anim_scale)))
      {
        Log.Info("ExampleListActivity", "Custom scale animation example is not implemented yet");
      }
      else if (title.Equals(GetString(Resource.String.anim_slide)))
      {
        Log.Info("ExampleListActivity", "Custom slide animation example is not implemented yet");
      }

      var intent = new Intent(this, type);
      StartActivity(intent);
      return true;
    }

    public override bool OnOptionsItemSelected(IMenuItem item)
    {
      switch (item.ItemId)
      {
        case Resource.Id.github:
          Util.GoToGithub(this);
          return true;
        case Resource.Id.about:
          new AlertDialog.Builder(this)
            .SetTitle(Resource.String.about)
            .SetMessage(Html.FromHtml(GetString(Resource.String.about_msg)))
            .Show();
          break;
        case Resource.Id.licenses:
          new AlertDialog.Builder(this)
            .SetTitle(Resource.String.licenses)
            .SetMessage(Html.FromHtml(GetString(Resource.String.apache_license)))
            .Show();
          break;
        case Resource.Id.contact:
          var email = new Intent(Intent.ActionSendto);
          var uriText = string.Format("mailto:jfeinstein10@gmail.com?subject={0}", 
            URLEncoder.Encode("SlidingMenu Demos Feedback"));
          email.SetData(Android.Net.Uri.Parse(uriText));
          try
          {
            StartActivity(email);
          }
          catch (Exception)
          {
            Toast.MakeText(this, Resource.String.no_email, ToastLength.Short).Show();
          }
          break;
      }

      return base.OnOptionsItemSelected(item);
    }

    public override bool OnCreateOptionsMenu(IMenu menu)
    {
      SupportMenuInflater.Inflate(Resource.Menu.example_list, menu);
      return true;
    }
  }
}