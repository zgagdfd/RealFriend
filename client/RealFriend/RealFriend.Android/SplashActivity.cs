﻿
using Android.App;
using Android.OS;
using Android.Views;

namespace RealFriend.Droid
{
    [Activity(Label = "RealFriend", MainLauncher = false, NoHistory = false, Theme = "@style/Theme.Splash")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //base.OnCreate(savedInstanceState);
            //System.Threading.Thread.Sleep(2000);
            //StartActivity(typeof(MainActivity));
        }

        
    }

}