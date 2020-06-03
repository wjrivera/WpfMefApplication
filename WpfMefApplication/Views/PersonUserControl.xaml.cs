using System.ComponentModel.Composition;
using System.Windows.Controls;
using Mapster;
using WpfCoreLibrary;
using WpfMefApplication.ViewModels;

namespace WpfMefApplication.Views
{
    /// <summary>
    /// Interaction logic for PersonUserControl.xaml
    /// </summary>
    [Export(typeof(IPluginApplication))]
    public partial class PersonUserControl : UserControl, IPluginApplication
    {
        public bool Load(PersonModel person)
        {
            Dispatcher.Invoke(() =>
            {
                DataContext = person.Adapt<PersonViewModel>();
                InitializeComponent();
            });
            return true;
        }
    }
}
