using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnsarCollage.Models;
using AnsarCollage.Views.ItemTemplate;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnsarCollage.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            var phonePart = new LoginPhonePartTemplate();
            var loginVerifyPart = new LoginVerificatePartTemplate();
            var signUpPart = new SignUpPartTemplate();
            mainContent.Content = phonePart;
            phonePart.Completed += async (sender, args) =>
            {
                if (args.Data)
                    mainContent.Content = loginVerifyPart;
                else
                    mainContent.Content = signUpPart;
            };

            loginVerifyPart.Completed += async (sender, args) =>
            {
                Preferences.Set("UserToken",Basics.Token);
                Preferences.Set("ServerToken", Basics.ServerCode);
                await Navigation.PushAsync(new MainPage());
                
            };
            signUpPart.Completed += async (sender, args) =>
            {
                Preferences.Set("UserToken", Basics.Token);
                Preferences.Set("ServerToken", Basics.ServerCode);
                await Navigation.PushAsync(new MainPage());
            };
        }
    }
}