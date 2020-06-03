using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using WpfCoreLibrary;
using WpfHostApplication.Annotations;

namespace WpfHostApplication
{
    public class MainViewModel: INotifyPropertyChanged
    {

        [Import(typeof(IPluginApplication))] public IPluginApplication PluginApplication;

        private IPluginApplication _loadedApplication;

        public IPluginApplication LoadedApplication
        {
            get => _loadedApplication;
            set
            {
                _loadedApplication = value;
                OnPropertyChanged();
            }
        }

        private string _loaded;

        public string Loaded
        {
            get => _loaded;
            set
            {
                _loaded = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (path == null) return;
            var catalogTypeOf = new DirectoryCatalog(path, "*.dll");
            var container = new CompositionContainer(catalogTypeOf);
            container.ComposeParts(this);

            if (PluginApplication != null)
            {
                Console.WriteLine("Found");
                Loaded = PluginApplication.Load(new PersonModel
                {
                    First = "Bob",
                    Last = "Smith",
                    Email = "bob@email.com"
                }).ToString();
                LoadedApplication = PluginApplication;
            }
            else
            {
                Console.WriteLine("not found");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
