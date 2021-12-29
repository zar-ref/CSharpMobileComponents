using CSharpMobileComponents.Resources.CustomViews;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
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
            var groupedItemKeys = control.Items.GroupBy(_item => _item.GetType().GetProperty(control.GroupedPropertyName).GetValue(_item)).Select(_group => _group.Key);

            foreach (var groupKey in groupedItemKeys)
            {

                var keyItemViewType = control.GroupKeyItemView.GetType();
                var keyItemView = (ICustomView)Activator.CreateInstance(keyItemViewType);
                keyItemView.SetBindingContext(groupKey);

                StackLayoutListItem groupStackItem = new StackLayoutListItem() { Item = null, View = keyItemView, GroupKey = groupKey, IsGroupingHeader = true };

                control.Children.Add(new CustomStackLayoutListItem(groupStackItem));

                //group by is only selecting for the first element of each grouped list and the rest are ignored. Workaround below
                var itemsWithKey = control.Items.Where(_item => Comparer.Default.Compare(  _item.GetType().GetProperty(control.GroupedPropertyName).GetValue(_item),groupKey) == 0).ToList();

                foreach (var item in itemsWithKey)
                {

                    var selectableItemView = new SelectableRadioView();
                    selectableItemView.SetBindingContext(item);
                    selectableItemView.SetValue(SelectableRadioView.SelectItemCommandProperty, control.SelectItemItemCommand);

                    ICustomView itemView = (ICustomView)Activator.CreateInstance(type);
                    itemView.SetBindingContext(item);
                    selectableItemView.ChildView = itemView;

                    StackLayoutListItem stackItem = new StackLayoutListItem() { Item = item, View = selectableItemView, GroupKey = groupKey };
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

        }


        public override void StackLayoutGroupedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    //Get item 
                    //var itemToDelete = this.Children.FirstOrDefault(_stackItem => 
                    //    ((CustomStackLayoutListItem)_stackItem).Item != null &&
                    //    Comparer.DefaultInvariant.Compare(((CustomStackLayoutListItem)_stackItem).Item, item) == 0) as CustomStackLayoutListItem;

                    var itemToDelete = this.Children.FirstOrDefault(_stackItem =>
                       ((CustomStackLayoutListItem)_stackItem).Item != null &&
                        ((CustomStackLayoutListItem)_stackItem).Item == item) as CustomStackLayoutListItem;

                    if (itemToDelete == null)
                        continue;
                    this.Children.Remove(itemToDelete);
                    //bool hasMoreItemsWithKey = this.Children.Any(_stackItem =>
                    //    ((CustomStackLayoutListItem)_stackItem).Item != null &&
                    //    Comparer.DefaultInvariant.Compare(((CustomStackLayoutListItem)_stackItem).GroupKey, itemToDelete.GroupKey) == 0 &&
                    //    !((CustomStackLayoutListItem)_stackItem).IsGroupingHeader);
                    bool hasMoreItemsWithKey = this.Children.Any(_stackItem =>
                        ((CustomStackLayoutListItem)_stackItem).Item != null &&
                        ((CustomStackLayoutListItem)_stackItem).GroupKey == itemToDelete.GroupKey &&
                        !((CustomStackLayoutListItem)_stackItem).IsGroupingHeader);
                    if (!hasMoreItemsWithKey)
                        this.Children.Remove(this.Children.FirstOrDefault(_stackItem => Comparer.Default.Compare(((CustomStackLayoutListItem)_stackItem).GroupKey, itemToDelete.GroupKey) == 0));
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

