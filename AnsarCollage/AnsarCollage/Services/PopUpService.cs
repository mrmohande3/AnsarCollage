using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AnsarCollage.Views.PopUps;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace AnsarCollage.Services
{
    public class PopUpService
    {
        private static PopUpService _instance;
        public static PopUpService Instance
        {
            get
            {
                if(_instance== null )
                    _instance = new PopUpService();
                return _instance;
            }
        }

        public async Task PopAsync()
        {
            if (PopupNavigation.Instance.PopupStack.Count > 0)
                await PopupNavigation.Instance.PopAllAsync();
        }

        public async Task PushAsync(View content, bool closeWithClickBack = true)
        {
            await PopAsync();
            await PopupNavigation.Instance.PushAsync(new PopupPage
            {
                Content = content,
                CloseWhenBackgroundIsClicked = closeWithClickBack
            });
        }
        public async void PushIndicator()
        {
            await PopAsync();
            var indicator = new Frame
            {
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                CornerRadius = 100,
                Content = new ActivityIndicator
                {
                    Color = (Color)Application.Current.Resources["PrimaryColor"],
                    WidthRequest = 70,
                    HeightRequest = 70,
                    IsRunning = true,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                }
            };
            await PushAsync(indicator, false);
        }
        public async void PushSuccess(string message = null)
        {
            await PopAsync();
            if (message == null)
                await PushAsync(new SuccessPopUp());
            else
                await PushAsync(new SuccessPopUp(message));
        }
        public async void PushError(string message)
        {
            await PopAsync();
            await PushAsync(new ErrorPopUp(message));
        }
    }
}
