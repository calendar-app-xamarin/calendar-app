using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CalendarApp.Model;
namespace CalendarApp.ViewModel
{
    public class NoteDetailsViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private NotesModel _note;
        public NotesModel Note
        {
            set { SetProperty(ref _note, value); }
            get { return _note; }
        }

        public void SetData(NotesModel finalNote)
        {
            Note = finalNote;
        }
        public NoteDetailsViewModel()
        {

        }
    }
}
