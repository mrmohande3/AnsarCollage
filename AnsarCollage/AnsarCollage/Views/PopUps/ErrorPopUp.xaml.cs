using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using AnsarCollage.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnsarCollage.Views.PopUps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorPopUp : ContentView
    {
        public ErrorPopUp(string message)
        {
            InitializeComponent();
            messageLabel.Text = message;
            Timer timer = new Timer(3000);
            timer.Start();
            timer.Elapsed += ((sender, e) =>
            {
                PopUpService.Instance.PopAsync();
                timer.Close();
            });
        }
    }
}