using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfMefApplication.Annotations;
using WpfMefApplication.Models;

namespace WpfMefApplication.ViewModels
{
    public class PersonViewModel : PersonModel, INotifyPropertyChanged
    {
        public string FullName => First + " " + Last;

        public bool ValidEmail => !string.IsNullOrEmpty(Email);
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
