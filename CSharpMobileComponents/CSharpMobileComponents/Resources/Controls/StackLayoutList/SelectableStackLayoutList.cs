using CSharpMobileComponents.Resources.CustomViews;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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
                ICustomView childView = (ICustomView)Activator.CreateInstance(type);
                //childView.ListIndex = i;
                childView.SetBindingContext(item);
                var view = (View)childView;

                //view.SetValue(BindingContextProperty, item);
                control.Children.Add(view);
                i++;
            }

        }

        public override void InitStackList(string bindingContextProperty, ICustomView view,  params ICustomView[] sequentialChildViews)
        {
            this.SetBinding(BindingContextProperty, bindingContextProperty);
            this.SetValue(StackLayoutList.ItemViewProperty, view);
        }

        public SelectableStackLayoutList() : base()
        {

        }
    }
}
