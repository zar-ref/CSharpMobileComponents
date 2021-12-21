using CSharpMobileComponents.Resources.CustomViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using CSharpMobileComponents.Models;
using CSharpMobileComponents.Models.Lists;

namespace CSharpMobileComponents.Resources.Controls.StackLayoutList
{
    public class SelectableGroupedStackLayoutList : BaseGroupedStackLayoutList
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
         declaringType: typeof(SelectableGroupedStackLayoutList),
         propertyChanged: HandleItemViewPropertyChanged);

        private static void HandleItemViewPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SelectableGroupedStackLayoutList)bindable;
            var newChildView = (ICustomView)newValue;
            var type = newChildView.GetType();
            control.Children.Clear();

            control.ItemView = newChildView;


            foreach (var groupedItems in control.GroupedItems)
            {

                var key = groupedItems.Key;
                var keyItemViewType = control.GroupKeyItemView.GetType();
                var keyItemView = (ICustomView)Activator.CreateInstance(keyItemViewType);
                keyItemView.SetBindingContext(key);

                StackLayoutListItem groupStackItem = new StackLayoutListItem() { Item = key, View = keyItemView, GroupKey = key };

                control.Children.Add(new CustomStackLayoutListItem(groupStackItem));
                foreach (var item in groupedItems)
                {
                    var selectableItemView = new SelectableRadioView();
                    selectableItemView.SetBindingContext(item);
                    selectableItemView.SetValue(SelectableRadioView.SelectItemCommandProperty, control.SelectItemItemCommand);

                    ICustomView itemView = (ICustomView)Activator.CreateInstance(type);
                    itemView.SetBindingContext(item);
                    selectableItemView.ChildView = itemView;

                    StackLayoutListItem stackItem = new StackLayoutListItem() { Item = item, View = selectableItemView };
                    control.Children.Add(new CustomStackLayoutListItem(stackItem));
                }



            }

        }

        public override ICustomView GroupKeyItemView { get; set; }

        public static readonly BindableProperty GroupKeyItemViewProperty = BindableProperty.Create(
         propertyName: "GroupKeyItemView",
         returnType: typeof(ICustomView),
         defaultValue: null,
         defaultBindingMode: BindingMode.OneWay,
         declaringType: typeof(SelectableGroupedStackLayoutList),
         propertyChanged: HandleGroupKeyItemViewProperty);

        private static void HandleGroupKeyItemViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SelectableGroupedStackLayoutList)bindable;
            var newGroupKeyItemView = (ICustomView)newValue;
            control.GroupKeyItemView = newGroupKeyItemView;
        }

        public override void InitGroupedStackList(string bindingContextProperty, string groupingPropertyName, ICustomView groupKeyView, ICustomView itemView, ICommand tappedItemCommand, ICommand selectItemCommand)
        {
            GroupedPropertyName = groupingPropertyName;
            this.SetBinding(BindingContextProperty, bindingContextProperty, BindingMode.TwoWay);
            if (tappedItemCommand != null)
                TappedItemCommand = tappedItemCommand;
            if (selectItemCommand != null)
                SelectItemItemCommand = selectItemCommand;
            this.SetValue(SelectableGroupedStackLayoutList.GroupKeyItemViewProperty, groupKeyView);
            this.SetValue(SelectableGroupedStackLayoutList.ItemViewProperty, itemView);

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
            if (items.Any(_item => _item.GetType().GetProperty(GroupedPropertyName) == null))
                return;
            if (items.Any(_item => _item.GetType().GetProperty(GroupedPropertyName).GetValue(_item) == null))
                return;
            Items = items;
            GroupedItems = new ObservableCollection<ObservableGroupCollection<object, object>>(Items.GroupBy(_item => _item.GetType().GetProperty(GroupedPropertyName).GetValue(_item)).Select(_items => new ObservableGroupCollection<object, object>(_items)).ToList());

        }


        public override void StackLayoutGroupedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    //Get item key
                    var itemKeyToDelete = Items.FirstOrDefault(_item => _item.GetType().GetProperty(GroupedPropertyName).GetValue(_item) != null);
                    var itemKeyList = this.Children.FirstOrDefault(_stackList => ((CustomStackLayoutListItem)_stackList).Item == item) as CustomStackLayoutListItem;
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

