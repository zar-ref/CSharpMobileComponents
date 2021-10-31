using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CSharpMobileComponents.Models
{
    public class ObservableGroupCollection<S, T> : ObservableCollection<T>
    {
        private readonly S _key; 
        public ObservableGroupCollection(IGrouping<S, T> group)
            : base(group)
        {
            _key = group.Key;
        }
        public S Key
        {
            get { return _key; }
        }        




    }
    //public class Grouping<K, T> : ObservableCollection<T>
    //{
    //    // NB: This is the GroupDisplayBinding above for displaying the header
    //    public K Key { get; private set; }

    //    public Grouping(K key, IEnumerable<T> items)
    //    {
    //        Key = key;
    //        foreach (var item in items)
    //            this.Items.Add(item);
    //    }
    //}


}
