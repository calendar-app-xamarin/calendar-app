using System;
using System.Collections.Generic;
using CalendarApp.ViewModel;
using Xamarin.Forms;

namespace CalendarApp.View
{
    public partial class Notes : ContentPage
    {
        public Notes()
        {
            InitializeComponent();
            BindingContext = new NotesListViewModel(Navigation);
        }

    }
}
