using System;
using System.Reflection;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Views;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace AnsarCollage.Droid
{
    [Activity(Label = "AnsarCollage", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Rg.Plugins.Popup.Popup.Init(this);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.DecorView.SystemUiVisibility = StatusBarVisibility.Hidden;
                var statusBarHeightInfo = typeof(FormsAppCompatActivity).GetField("_statusBarHeight", BindingFlags.Instance | BindingFlags.NonPublic);
                statusBarHeightInfo?.SetValue(this, 0);
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}