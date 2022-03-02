using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnsarCollage.Models;
using AnsarCollage.Services;
using Refit;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnsarCollage.Views.ItemTemplate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FieldsPartTemplate : ContentView
    {
        public event EventHandler<Field> OnFieldSelected;
        public FieldsPartTemplate()
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

        private void FieldItemButton_OnClicked(object sender, EventArgs e)
        {
            if(sender is Button button && button.BindingContext is Field field)
                OnFieldSelected?.Invoke(this,field);
        }
    }
}