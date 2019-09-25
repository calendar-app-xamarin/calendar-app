using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace CalendarApp.View
{
    public partial class MainView : Xamarin.Forms.TabbedPage
    {
        public MainView()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
