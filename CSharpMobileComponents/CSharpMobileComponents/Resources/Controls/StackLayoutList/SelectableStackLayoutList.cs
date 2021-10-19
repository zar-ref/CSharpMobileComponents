using CSharpMobileComponents.Resources.CustomViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;

namespace CSharpMobileComponents.Resources.Controls.StackLayoutList
{
    public class SelectableStackLayoutList : BaseStackLayoutList
    {

        public override ICustomView ItemView
        {
            get { return (ICustomView)GetValue(ItemViewProperty); }
            set { SetValue(ItemViewProperty, value); }
        }

        public static readonly BindableProperty ItemViewProperty = BindableProperty.Create(
         propertyName: "ItemView",
         returnType: typeof(ICustomView),
         defaultValue: null,
         defaultBindingMode: BindingMode.OneWay,
         declaringType: typeof(SelectableStackLayoutList),
         propertyChanged: HandleItemViewPropertyChanged);

        private static void HandleItemViewPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SelectableStackLayoutList)bindable;
            var newChildView = (ICustomView)newValue;
            var type = newChildView.GetType();
            control.Children.Clear();
            int i = 0;

            foreach (var item in control.Items)
            {
                var selectableItemView = new SelectableRadioView();
                selectableItemView.SetBindingContext(item);
                selectableItemView.SetValue(SelectableRadioView.SelectItemCommandProperty, control.SelectItemItemCommand);

                ICustomView itemView = (ICustomView)Activator.CreateInstance(type);
                itemView.SetBindingContext(item);
                selectableItemView.ChildView = itemView;
                //var view = (View)itemView; 

                StackLayoutListItem stackItem = new StackLayoutListItem() { Item = item, View = selectableItemView };

                control.Children.Add(new CustomStackLayoutListItem(stackItem));
                i++;
            }

        }

        public override void InitStackList(string bindingContextProperty, ICustomView view, ICommand tappedItemCommand, ICommand selectItemCommand)
        {
            this.SetBinding(BindingContextProperty, bindingContextProperty, BindingMode.OneWay);

            if (tappedItemCommand != null)
                TappedItemCommand = tappedItemCommand;
            if (selectItemCommand != null)
                SelectItemItemCommand = selectItemCommand;
            this.SetValue(SelectableStackLayoutList.ItemViewProperty, view);
        }

      

        public SelectableStackLayoutList() : base()
        {

        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
     
            var enumerable = BindingContext as IEnumerable<object>;
            if (enumerable == null)
                return;
            var items = new ObservableCollection<object>(enumerable);

            if (items == null)
                return;
            if (Items == null) //First Appeearence
                Items = items;

            else
            {
                if (Items.Count() < items.Count())//Removed from list
                {
                    var itemsToRemove = items.Except(Items).ToList();
                    foreach (var item in itemsToRemove)
                    {
                        var itemToDelete = this.Children.FirstOrDefault(_stackItem => ((CustomStackLayoutListItem)_stackItem).Item == item);
                        this.Children.Remove(itemToDelete);
                    }

                }
            }
            //try
            //{ 

            //    ((ObservableCollection<object>)BindingContext).CollectionChanged += Xx_CollectionChanged;
            //}
            //catch (Exception ex)
            //{
                 
            //}
        }

        public void Xx_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

        }
    }
}
