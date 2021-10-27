using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace CSharpMobileComponents.Resources.Util
{
    public static class Extensions
    {
        public static void SortAscending<TSource, TKey>(this ObservableCollection<TSource> source, Func<TSource, TKey> keySelector)
        {
            List<TSource> sortedList = source.OrderBy(keySelector).ToList();
            //source.Clear();
            for (int i = 0; i < sortedList.Count(); i++)
                source.Move(source.IndexOf(sortedList[i]), i);
           
        }

        public static void SortDescending<TSource, TKey>(this ObservableCollection<TSource> source, Func<TSource, TKey> keySelector)
        {
            List<TSource> sortedList = source.OrderByDescending(keySelector).ToList();
            //source.Clear();
            for (int i = 0; i < sortedList.Count(); i++)
                source.Move(source.IndexOf(sortedList[i]), i);

        }

       
    }
  
}
