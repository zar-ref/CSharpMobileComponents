using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMobileComponents.DataStores
{
    public class LanguagesDataStore : BaseDataStore
    {
        public override string Name { get; set; } = "LANGUAGES_DATA_STORE";

        public override void CleanDataStore()
        {
            return;
        }

        private static LanguagesDataStore instance = null;
        public static LanguagesDataStore Instance
        {
            get
            {
                if (instance == null)
                    instance = new LanguagesDataStore();
                return instance;
            }
        }

        public LanguagesDataStore()
        {
            RegistDataStore();
        }
    }
}
