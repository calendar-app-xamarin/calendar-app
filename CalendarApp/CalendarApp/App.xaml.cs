using System;
using Syncfusion.Licensing;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalendarApp
{
    public partial class App : Application
    {
        public App()
        {
            SyncfusionLicenseProvider.RegisterLicense("MTQ2MTgzQDMxMzcyZTMyMmUzMGRlbENxbGNVQWp5ZUdhMnlQUStGNVhvU1JzSEg0RUdncEVHYVduYUhvTGM9");
            InitializeComponent();
            MainPage = new NavigationPage(new CalendarApp.View.MainView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
