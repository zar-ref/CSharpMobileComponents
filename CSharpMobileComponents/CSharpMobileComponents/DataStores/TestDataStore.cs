using CSharpMobileComponents.Models;
using CSharpMobileComponents.Models.Lists;
using CSharpMobileComponents.Resources.Styles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using static CSharpMobileComponents.Resources.Constants;
using System.Linq;
using CSharpMobileComponents.Models.Interfaces;

namespace CSharpMobileComponents.DataStores
{
    public class TestDataStore
    {

        private static TestDataStore instance = null;
        public static TestDataStore Instance
        {
            get { return instance == null ? new TestDataStore() : instance; }
        }

        public TestDataStore()
        {
            ListToGroup.Add(new GroupingTestModel("ossla_0"));
            ListToGroup.Add(new GroupingTestModel("oççla_0"));
            ListToGroup.Add(new GroupingTestModel("olsa_2"));
            ListToGroup.Add(new GroupingTestModel("ssola_1"));
            ListToGroup.Add(new GroupingTestModel("ogfgla_0"));
            ListToGroup.Add(new GroupingTestModel("ogfgfla_2"));
            ListToGroup.Add(new GroupingTestModel("olafgfg_0"));

        }


        public ObservableCollection<GroupingTestModel> ListToGroup { get; set; } = new ObservableCollection<GroupingTestModel>();
        //public ObservableCollection<ObservableGroupCollection<object, GroupingTestModel>> GroupedList
        //{
        //    get
        //    {
        //        return new ObservableCollection<ObservableGroupCollection<object, GroupingTestModel>>(ListToGroup.GroupBy(g => g.Grouping.GroupingKey).Select(items => new ObservableGroupCollection<object, GroupingTestModel>(items)).ToList());


        //    }
        //}
    }
}
