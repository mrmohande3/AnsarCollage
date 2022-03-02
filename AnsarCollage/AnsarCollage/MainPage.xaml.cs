using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnsarCollage.Models;
using AnsarCollage.Services;
using AnsarCollage.Views.ItemTemplate;
using AnsarCollage.Views.Pages;
using Refit;
using Xamarin.Forms;

namespace AnsarCollage
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Initialize();
        }

        private async void Initialize()
        {
            try
            {
                PopUpService.Instance.PushIndicator();
                var rest = await RestWrapper.Instance.DataRestApi.GetFields(Basics.Token);
                if (rest.Code == 200)
                {
                    await PopUpService.Instance.PopAsync();
                    mainCollection.ItemsSource = rest.Data.Fields;
                }
                else
                    throw new Exception(rest.Message);
            }
            catch (ApiException)
            {
                PopUpService.Instance.PushError("مشکلی رخ داده است");
            }
            catch (Exception exception)
            {
                PopUpService.Instance.PushError(exception.Message);
            }
        }
        private async void Fields_OnFieldSelected(object sender, Field e)
        {
            await Navigation.PushAsync(new GradesPage(e));
        }

        private async void FieldItemButton_OnClicked(object sender, EventArgs e)
        {
            if(sender is Button button && button.BindingContext is Field field)
                await Navigation.PushAsync(new GradesPage(field));
        }
    }
}
