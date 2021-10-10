using CSharpMobileComponents.Resources.Controls.Interfaces;
using CSharpMobileComponents.Resources.CustomViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents.Resources.Controls.StackLayoutList
{
    public abstract class BaseStackLayoutList : StackLayout, ICustomControl
    {
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
        propertyName: "Items",
        returnType: typeof(IEnumerable<object>),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay,
        declaringType: typeof(BaseStackLayoutList));

        public IEnumerable<object> Items
        {
            get { return (IEnumerable<object>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public abstract ICustomView ItemView { get; set; }

        public int ControlHashCode { get; set; }

        public int PageHashCode { get; set; }

        public static readonly BindableProperty PageHashCodeProperty = BindableProperty.Create(
           propertyName: "PageHashCode",
           returnType: typeof(int),
           declaringType: typeof(BaseStackLayoutList),
           defaultValue: 0,
           propertyChanged: HandlePageHashCodePropertyChanged);

        protected ICommand TappedItemCommand { get; set; } = null;
        protected ICommand SelectItemItemCommand { get; set; } = null;

        private static void HandlePageHashCodePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BaseStackLayoutList)bindable;
            var pageHashCode = (int)newValue;
            control.PageHashCode = pageHashCode;
            control.RegisterControl();
        }

        public BaseStackLayoutList()
        {
            ControlHashCode = this.GetHashCode();
        }

        public virtual void RegisterControl()
        {
            MessagingCenter.Send<ICustomControl, int>(this, CustomControlsMessagesNames.Register.ToString(), PageHashCode);
        }

        public virtual void UnsubscribeOnDisappearing()
        {

        }

        public abstract void InitStackList(string bindingContextProperty, ICustomView view,   ICommand tappedItemCommand , ICommand selectItemCommand  );

     
    }
}
