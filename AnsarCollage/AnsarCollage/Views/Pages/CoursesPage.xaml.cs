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
    public partial class CoursesPage : ContentPage
    {
        private readonly Grade _grade;

        public CoursesPage(Grade grade)
        {
            _grade = grade;
            InitializeComponent();
            Initialize();
            nameLable.Text = _grade.garde;
        }

        private async void Initialize()
        {
            try
            {
                PopUpService.Instance.PushIndicator();
                var rest = await RestWrapper.Instance.DataRestApi.GetCurses(_grade.id, Basics.Token);
                if (rest.Code == 200)
                {
                    await PopUpService.Instance.PopAsync();
                    mainCollection.ItemsSource = rest.Data.Courses;
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
        private void CourseItemButton_OnClicked(object sender, EventArgs e)
        {
            if (sender is Grid button && button.BindingContext is Cours cours)
                Navigation.PushAsync(new ChaptersPage(cours));
        }


        private async void BackButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}