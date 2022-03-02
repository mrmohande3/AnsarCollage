using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnsarCollage.Models;
using AnsarCollage.Services;
using Refit;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace AnsarCollage.Views.ItemTemplate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPartTemplate : ContentView
    {
        public event EventHandler<EventArgs> Completed;
        public SignUpPartTemplate()
        {
            InitializeComponent();
        }

        private async void SubmitButton_OnClicked(object sender, EventArgs e)
        {
            try
            {
                PopUpService.Instance.PushIndicator();
                if (string.IsNullOrEmpty(nameEntry.Text))
                    throw new Exception("نام و نام خانوادگی را وارد کنید");
                if (string.IsNullOrEmpty(verifyEntry.Text))
                    throw new Exception("کدتاییدیه را وارد کنید");
                var rest = await RestWrapper.Instance.AuthorizeRestApi.SignUp(new VerifyCodeRequest() { phone = Basics.PhoneNumber, code = verifyEntry.Text, serverCode = Basics.ServerCode, name = nameEntry.Text });
                if (rest.Code == 200)
                {
                    Basics.Token = rest.Data.Token.Data.Token;
                    await PopUpService.Instance.PopAsync();
                    Completed?.Invoke(this, EventArgs.Empty);
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
    }
}