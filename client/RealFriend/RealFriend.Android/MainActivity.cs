using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using System.Drawing;
using Xamarin.Forms.Platform.Android;
using Android.Support.V7.Widget;

namespace RealFriend.Droid
{
    [Activity(Label = "RealFriend", Icon = "@drawable/icon", Theme = "@style/Theme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            // base.Window.RequestFeature(WindowFeatures.ActionBar);
            System.Threading.Thread.Sleep(2000);
            base.SetTheme(Resource.Style.MainTheme);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            /*
            Toolbar toolbar = (Toolbar)FindViewById(Resource.Id.toolbar);
            if(toolbar == null)
            {
                Window.AddFlags(WindowManagerFlags.TranslucentStatus);
            }
            else
            {
                SetSupportActionBar(toolbar);
                toolbar.SetPadding(0, getStatusBarHeight(), 0, 0);

            }
            */

            // Window.AddFlags(WindowManagerFlags.Fullscreen);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        int getStatusBarHeight()
        {
            int result = 0;
            int resourceId = Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                result = Resources.GetDimensionPixelSize(resourceId);
            }
            return result;
        }
    }
}

