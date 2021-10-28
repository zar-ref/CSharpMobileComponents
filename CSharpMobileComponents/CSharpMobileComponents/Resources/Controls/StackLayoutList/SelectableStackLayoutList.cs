using CSharpMobileComponents.Resources.CustomViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

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

            control.ItemView = newChildView;
            int i = 0;

            foreach (var item in control.Items)
            {
                var selectableItemView = new SelectableRadioView();
                selectableItemView.SetBindingContext(item);
                selectableItemView.SetValue(SelectableRadioView.SelectItemCommandProperty, control.SelectItemItemCommand);

                ICustomView itemView = (ICustomView)Activator.CreateInstance(type);
                itemView.SetBindingContext(item);
                selectableItemView.ChildView = itemView; 

                StackLayoutListItem stackItem = new StackLayoutListItem() { Item = item, View = selectableItemView };
                control.Children.Add(new CustomStackLayoutListItem(stackItem));
                i++;
            }

        }

        public override void InitStackList(string bindingContextProperty, ICustomView view, ICommand tappedItemCommand, ICommand selectItemCommand)
        {
            this.SetBinding(BindingContextProperty, bindingContextProperty, BindingMode.TwoWay);

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
            Items = items;
        }

        public override void StackLayoutCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
        
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    //Removed items
                    var itemToDelete = this.Children.FirstOrDefault(_stackItem => ((CustomStackLayoutListItem)_stackItem).Item == item);
                    this.Children.Remove(itemToDelete);
                }
            }

            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    //Add items
                    var selectableItemView = new SelectableRadioView();
                    selectableItemView.SetBindingContext(item);
                    selectableItemView.SetValue(SelectableRadioView.SelectItemCommandProperty, this.SelectItemItemCommand);
                    var type = this.ItemView.GetType();
                    ICustomView itemView = (ICustomView)Activator.CreateInstance(type);
                    itemView.SetBindingContext(item);
                    selectableItemView.ChildView = itemView;

                    StackLayoutListItem stackItem = new StackLayoutListItem() { Item = item, View = selectableItemView };
                    this.Children.Add(new CustomStackLayoutListItem(stackItem));

                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Move)
            {
                foreach (var item in e.NewItems)
                {
                    var selectableItemView = new SelectableRadioView();
                    selectableItemView.SetBindingContext(item);
                    selectableItemView.SetValue(SelectableRadioView.SelectItemCommandProperty, this.SelectItemItemCommand);
                    var type = this.ItemView.GetType();
                    ICustomView itemView = (ICustomView)Activator.CreateInstance(type);
                    itemView.SetBindingContext(item);
                    selectableItemView.ChildView = itemView;

                    StackLayoutListItem stackItem = new StackLayoutListItem() { Item = item, View = selectableItemView };
                    this.Children[e.NewStartingIndex] = new CustomStackLayoutListItem(stackItem);
                }
            }
        }
    }
}
