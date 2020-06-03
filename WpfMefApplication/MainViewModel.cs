using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfMefApplication.Annotations;
using WpfMefApplication.ViewModels;

namespace WpfMefApplication
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private PersonViewModel _personViewModel;

        public PersonViewModel PersonViewModel
        {
            get => _personViewModel;
            set
            {
                _personViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            PersonViewModel = new PersonViewModel
            {
                First = "Bob",
                Last = "Smith",
                Email = "bob@email.com"
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
