using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMobileComponents.DataStores
{
    public abstract class BaseDataStore : IBaseDataStore
    {
        public abstract string Name { get; set; }

        public abstract void CleanDataStore();

        public void RegistDataStore()
        {
            DataStoreManager.Instance.RegistDataStore(this);
        }
    }
}
