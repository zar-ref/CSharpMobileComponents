using using CSharpMobileComponents.Resources.CustomViews;
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
       

            foreach (var groupedItems in control.Items)
            {

                var key = groupedItems.Key;
                var keyItemViewType = control.GroupKeyItemView.GetType();
                var keyItemView = (ICustomView)Activator.CreateInstance(keyItemViewType);
                keyItemView.SetBindingContext(key);

                StackLayoutListItem groupStackItem = new StackLayoutListItem() { Item = key, View = keyItemView };
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

        public override void InitGroupedStackList(string bindingContextProperty, ICustomView groupKeyView, ICustomView itemView, ICommand tappedItemCommand, ICommand selectItemCommand)
        {

        }

        public override void StackLayoutGroupedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

        }
    }
}
