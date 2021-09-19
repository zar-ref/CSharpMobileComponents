using CSharpMobileComponents.Resources.Controls.Interfaces;
using CSharpMobileComponents.Resources.CustomViews;
using CSharpMobileComponents.Resources.ViewCells;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents.Resources.Controls
{
    public class StackLayoutList : StackLayout, ICustomControl
    {
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
           propertyName: "Items",
           returnType: typeof(IEnumerable<object>),
           defaultValue: null,
           defaultBindingMode: BindingMode.OneWay,
           declaringType: typeof(StackLayoutList));
           // ,
           //propertyChanged: HandleItemsPropertyChanged);


        public IEnumerable<object> Items
        {
            get { return (IEnumerable<object>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly BindableProperty ChildViewProperty = BindableProperty.Create(
          propertyName: "ChildView",
          returnType: typeof(View),
          defaultValue: null,
          defaultBindingMode: BindingMode.OneWay,
          declaringType: typeof(StackLayoutList),
          propertyChanged: HandleChildViewPropertyChanged);

        private static void HandleChildViewPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (StackLayoutList)bindable;
            var newChildView = (ICustomView)newValue;
            var type = newChildView.GetType();
            control.Children.Clear();
            int i = 0;
            
            foreach (var item in control.Items)
            {
                ICustomView childView = (ICustomView)Activator.CreateInstance(type);
                //childView.ListIndex = i;
                childView.SetBindingContext(item);
                var view = (View)childView;

                //view.SetValue(BindingContextProperty, item);
                control.Children.Add(view);
                i++;
            }
             
        }

        public View ChildView
        {
            get { return (View)GetValue(ChildViewProperty); }
            set { SetValue(ChildViewProperty, value); }
        }
        public int ControlHashCode { get; set; }
        public static readonly BindableProperty PageHashCodeProperty = BindableProperty.Create(
        propertyName: "PageHashCode",
        returnType: typeof(int),
        declaringType: typeof(StackLayoutList),
        defaultValue: 0,
        propertyChanged: HandlePageHashCodePropertyChanged);

        private static void HandlePageHashCodePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (StackLayoutList)bindable;
            var pageHashCode = (int)newValue;
            control.PageHashCode = pageHashCode;
            control.RegisterControl();
        }

        public int PageHashCode
        {
            get { return (int)GetValue(PageHashCodeProperty); }
            set { SetValue(PageHashCodeProperty, value); }
        }


        public StackLayoutList()
        {
        
            ControlHashCode = this.GetHashCode();
        }
        private static void HandleItemsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (StackLayoutList)bindable;
            var items = (IEnumerable<object>)newValue;
            control.Items = items;
            control.SetValue(StackLayoutList.BindingContextProperty, control.Items);
            //BindableLayout.SetItemsSource(control, control.Items);
        }

        public void RegisterControl()
        {
            MessagingCenter.Send<ICustomControl, int>(this, CustomControlsMessagesNames.Register.ToString(), PageHashCode);
        }
        public void UnsubscribeOnDisappearing()
        {

        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            var items = BindingContext as IEnumerable<object>;
            if (items == null)
                return;
            Items = items; 
        }

    }
}
