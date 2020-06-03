using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WpfCoreLibrary
{
    public interface IPluginApplication
    {
        bool Load(PersonModel person);
    }
}
