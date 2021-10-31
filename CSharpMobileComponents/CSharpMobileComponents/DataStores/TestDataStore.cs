﻿using CSharpMobileComponents.Models;
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
            ListToGroup.Add(new GroupingTestModel("ola_0"));
            ListToGroup.Add(new GroupingTestModel("ola_0"));
            ListToGroup.Add(new GroupingTestModel("ola_2"));
            ListToGroup.Add(new GroupingTestModel("ola_1"));
            ListToGroup.Add(new GroupingTestModel("ola_0"));
            ListToGroup.Add(new GroupingTestModel("ola_2"));
            ListToGroup.Add(new GroupingTestModel("ola_0"));

        }


        public ObservableCollection<GroupingTestModel> ListToGroup { get; set; } = new ObservableCollection<GroupingTestModel>();
        public ObservableCollection<ObservableGroupCollection<GroupingModel, GroupingTestModel>> GroupedList
        {
            get
            {
                return new ObservableCollection<ObservableGroupCollection<GroupingModel, GroupingTestModel>>(ListToGroup.GroupBy(g => g.Grouping).Select(items => new ObservableGroupCollection<GroupingModel, GroupingTestModel>(items)));


            }
        }
    }
}