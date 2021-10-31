using CSharpMobileComponents.Models;
using CSharpMobileComponents.Models.Interfaces;
using CSharpMobileComponents.Resources.Controls.Interfaces;
using CSharpMobileComponents.Resources.CustomViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents.Resources.Controls.StackLayoutList
{
    public abstract class BaseGroupedStackLayoutList : StackLayout, ICustomControl
    {
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
            propertyName: "Items",
            returnType: typeof(ObservableCollection<ObservableGroupCollection<IGroupingModel, object>>),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay,
            declaringType: typeof(BaseGroupedStackLayoutList),
            propertyChanged: HandleItemsPropertyChanged);

        public ObservableCollection<ObservableGroupCollection<IGroupingModel, object>> Items
        {
            get { return (ObservableCollection<ObservableGroupCollection<IGroupingModel, object>>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public abstract ICustomView ItemView { get; set; }
        public abstract ICustomView GroupKeyItemView { get; set; }

        public int ControlHashCode { get; set; }
        public int PageHashCode { get; set; }

        public static readonly BindableProperty PageHashCodeProperty = BindableProperty.Create(
           propertyName: "PageHashCode",
           returnType: typeof(int),
           declaringType: typeof(BaseGroupedStackLayoutList),
           defaultValue: 0,
           propertyChanged: HandlePageHashCodePropertyChanged);

        protected ICommand TappedItemCommand { get; set; } = null;
        protected ICommand SelectItemItemCommand { get; set; } = null;

      

 
        public virtual void RegisterControl()
        {
            MessagingCenter.Send<ICustomControl, int>(this, CustomControlsMessagesNames.Register.ToString(), PageHashCode);
        }

        public virtual void UnsubscribeOnDisappearing()
        {

        }

        public BaseGroupedStackLayoutList()
        {
            ControlHashCode = this.GetHashCode();
        }
        private static void HandlePageHashCodePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BaseGroupedStackLayoutList)bindable;
            var pageHashCode = (int)newValue;
            control.PageHashCode = pageHashCode;
            control.RegisterControl();
        }


        private static void HandleItemsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BaseGroupedStackLayoutList)bindable;
            var items = newValue as ObservableCollection<ObservableGroupCollection<IGroupingModel, object>>;
            control.Items = items;
        }


        public abstract void InitGroupedStackList(string bindingContextProperty, ICustomView groupKeyView, ICustomView itemView, ICommand tappedItemCommand, ICommand selectItemCommand);

        public abstract void StackLayoutGroupedCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e);

    }
}
