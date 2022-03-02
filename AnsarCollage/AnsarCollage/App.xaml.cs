using System;
using AnsarCollage.Models;
using AnsarCollage.Views.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnsarCollage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var token = Preferences.Get("UserToken", string.Empty);
            var serverToken = Preferences.Get("ServerToken", string.Empty);
            Basics.Token = token;
            Basics.ServerCode = serverToken;
            if(string.IsNullOrEmpty(Basics.Token) || string.IsNullOrEmpty(Basics.ServerCode))
                MainPage = new NavigationPage(new LoginPage());
            else
                MainPage = new NavigationPage(new MainPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
