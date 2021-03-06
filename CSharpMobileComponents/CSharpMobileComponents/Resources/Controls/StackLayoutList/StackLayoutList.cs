using CSharpMobileComponents.Resources.Controls.Interfaces;
using CSharpMobileComponents.Resources.CustomViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CSharpMobileComponents.Resources.Controls.StackLayoutList
{
    public class StackLayoutList : BaseStackLayoutList
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
         declaringType: typeof(StackLayoutList),
         propertyChanged: HandleItemViewPropertyChanged);

        private static void HandleItemViewPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (StackLayoutList)bindable;
 
            var newItemView = (ICustomView)newValue;
            var type = newItemView.GetType();
            control.Children.Clear();
            int i = 0;
            
            foreach (var item in control.Items)
            {
                ICustomView itemView = (ICustomView)Activator.CreateInstance(type);
                
                itemView.SetBindingContext(item);
                var view = (View)itemView;

                StackLayoutListItem stackItem = new StackLayoutListItem() { Item = item, View = itemView };
                control.Children.Add(new CustomStackLayoutListItem(stackItem));
                i++;
            }

        }

        public StackLayoutList(): base()
        {
          
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            var items = BindingContext as ObservableCollection<object>;
            if (items == null)
                return;
            Items = items;
        }

        public override void InitStackList(string bindingContextProperty, ICustomView view, ICommand tappedItemCommand, ICommand selectItemCommand)
        {
            this.SetBinding(BindingContextProperty, bindingContextProperty);
            this.SetValue(StackLayoutList.ItemViewProperty, view);
        }

        public override void StackLayoutCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
