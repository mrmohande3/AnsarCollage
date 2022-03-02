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
    public partial class GradesPage : ContentPage
    {
        private readonly Field _field;

        public GradesPage(Field field)
        {
            _field = field;
            InitializeComponent();
            Initialize();
            nameLable.Text = _field.field;
        }

        private async void Initialize()
        {
            try
            {
                PopUpService.Instance.PushIndicator();
                var rest = await RestWrapper.Instance.DataRestApi.GetGrades(_field.id,Basics.Token);
                if (rest.Code == 200)
                {
                    await PopUpService.Instance.PopAsync();
                    mainCollection.ItemsSource = rest.Data.Grades;
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
        private void GradeItemButton_OnClicked(object sender, EventArgs e)
        {
            if (sender is Grid button && button.BindingContext is Grade grade)
                Navigation.PushAsync(new CoursesPage(grade));
        }


        private async void BackButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}