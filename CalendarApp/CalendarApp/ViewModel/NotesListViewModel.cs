using System;
using CalendarApp.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using CalendarApp.Data;
using CalendarApp.View;
using Xamarin.Forms;

namespace CalendarApp.ViewModel
{
    public class NotesListViewModel:INotifyPropertyChanged
    {
        NotesDatabase _notesDatabase = new NotesDatabase();

        private INavigation _navigation;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<NotesModel> _notesList;

        public ObservableCollection<NotesModel> NotesList
        {
            get { return _notesList; }
            set
            {
                _notesList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NotesList"));
            }
        }

        private NotesModel _noteSelected;

        public NotesModel NoteSelected
        {
            get { return _noteSelected; }
            set
            {
                if (_noteSelected != value)
                {
                    _noteSelected = value;
                    if (_noteSelected != null)
                    {
                        _navigation.PushAsync(new NoteDetailsPage(_noteSelected));
                    }
                }
            }
        }

        public async Task FetchDataAsync()
        {

            var list = await _notesDatabase.GetAllNotesAsync();
            NotesList = new ObservableCollection<NotesModel>(list);
        }

        public NotesListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            FetchDataAsync();
        }
    }
}
