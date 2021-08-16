using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMobileComponents.DataStores
{
    public interface IBaseDataStore
    {
        string Name { get; set; }
        void RegistDataStore();
        void CleanDataStore();
    }
}
