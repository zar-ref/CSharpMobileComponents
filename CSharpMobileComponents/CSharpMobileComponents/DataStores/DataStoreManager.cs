using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpMobileComponents.DataStores
{
     public class DataStoreManager
    {

        private static DataStoreManager instance = null;
        public static DataStoreManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataStoreManager();
                return instance;
            }
        }

        public List<IBaseDataStore> RegisteredDataStores { get; private set; } = new List<IBaseDataStore>();
        public void CleanDataStores()
        {
            foreach (var dataStore in RegisteredDataStores)
            {
                dataStore.CleanDataStore();
            }
            RegisteredDataStores.Clear();
        }

        public void RegistDataStore(IBaseDataStore dataStore)
        {
            if (RegisteredDataStores.Any(rds => rds.Name == dataStore.Name))
                return;
            RegisteredDataStores.Add(dataStore);
        }
    }
}
