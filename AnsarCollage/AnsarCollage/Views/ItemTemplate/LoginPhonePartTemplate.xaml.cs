using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AnsarCollage.Models;
using AnsarCollage.Services;
using Newtonsoft.Json;
using Refit;
using RestSharp;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using ParameterType = RestSharp.ParameterType;

namespace AnsarCollage.Views.ItemTemplate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPhonePartTemplate : ContentView
    {
        public event EventHandler<EventArg<bool>> Completed;
        public LoginPhonePartTemplate()
        {
            InitializeComponent();
        }

        private async void SubmitButton_OnClicked(object sender, EventArgs e)
        {
            try
            {
                PopUpService.Instance.PushIndicator();
                if (string.IsNullOrEmpty(phoneEntry.Text))
                    throw new Exception("شماره تلفن را وارد کنید");
                var rest = await RestWrapper.Instance.AuthorizeRestApi.SendVeryCode(new VerifyCodeRequest{phone = phoneEntry.Text});
                if (rest.Code == 200)
                {
                    Basics.ServerCode = rest.Data.ServerCode;
                    Basics.PhoneNumber = phoneEntry.Text;
                    await PopUpService.Instance.PopAsync();
                    Completed?.Invoke(this, new EventArg<bool>(rest.Data.Exist));
                }
                else
                    throw new Exception(rest.Message);
            }
            catch (ApiException apie)
            {
                PopUpService.Instance.PushError("مشکلی رخ داده است");
            }
            catch (Exception exception)
            {
                PopUpService.Instance.PushError(exception.Message);
            }
        }
    }
}