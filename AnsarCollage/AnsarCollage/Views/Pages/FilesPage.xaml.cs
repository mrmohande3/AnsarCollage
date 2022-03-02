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

namespace AnsarCollage.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilesPage : ContentPage
    {
        private readonly Chapter _chapter;

        public FilesPage(Chapter chapter)
        {
            _chapter = chapter;
            InitializeComponent();
            Initialize();
            nameLable.Text = _chapter.chapter;
        }


        private async void Initialize()
        {
            try
            {
                PopUpService.Instance.PushIndicator();
                var rest = await RestWrapper.Instance.DataRestApi.GetFiles(_chapter.id, Basics.Token);
                if (rest.Code == 200)
                {
                    await PopUpService.Instance.PopAsync();
                    mainCollection.ItemsSource = rest.Data.Files;
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

        private void FileItemButton_OnClicked(object sender, EventArgs e)
        {
            if (sender is Grid grid && grid.BindingContext is File file)
                Xamarin.Essentials.Browser.OpenAsync($"http://ansarbook.hashsharp.ir/media/{file.file}");
        }

        private async void BackButton_OnClicked(object sender, EventArgs e)
        {
             await Navigation.PopAsync();
        }
    }
}