﻿using CSharpMobileComponents.Models;
using CSharpMobileComponents.Models.Interfaces;
using CSharpMobileComponents.Resources.CustomViews;
using CSharpMobileComponents.Resources.ViewCells.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSharpMobileComponents.Resources.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectableRadioViewCell : StackLayout
    {
        public static readonly BindableProperty ChildViewProperty = BindableProperty.Create(
          propertyName: "ChildView",
          returnType: typeof(View),
          defaultValue: null,
          defaultBindingMode: BindingMode.OneWay,
          declaringType: typeof(SelectableRadioViewCell),
          propertyChanged: HandleChildViewPropertyChanged2);

        public View ChildView
        {
            get { return (View)GetValue(ChildViewProperty); }
            set { SetValue(ChildViewProperty, value); }
        }
        //public View ChildContentView
        //{
        //    get { return this.ChildViewCellContainer.Content; }
        //    set { this.ChildViewCellContainer.Content = value; }
        //}
        public static readonly BindableProperty DisplayTextProperty = BindableProperty.Create(
        propertyName: "DisplayText",
        returnType: typeof(string),
        declaringType: typeof(SelectableRadioViewCell),
        propertyChanged: HandleDisplayTextPropertyChanged);

        private static void HandleDisplayTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SelectableRadioViewCell)bindable;
            var newText = (string)newValue;
            control.DisplayText = newText;
            control.lbl.Text = newText;
        }
        public string DisplayText
        {
            get { return (string)GetValue(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }

        ISelectableModel SelectableItem { get; set; } = null;

        public SelectableRadioViewCell()
        {
            InitializeComponent(); 

        }

       

        static void HandleChildViewPropertyChanged2(BindableObject bindable, object oldValue, object newValue)
        {
          
            var control = (SelectableRadioViewCell)bindable;
            //if (control.ChildView != null)
            //    return;
            var v = (StringOnlyView)newValue;
            //v.SetBinding(StringOnlyView.DisplayTextProperty, "DisplayText");
            //v.SetBinding(Label.TextProperty, "DisplayText");
            v.SetViewBindings();
            control.childView.Children.Add(v);

        }
        protected override void OnBindingContextChanged()
        {
            var x = BindingContext;
            ChildView.SetValue(BindingContextProperty, x);
            //base.OnBindingContextChanged();
            //SelectableItem = (ISelectableModel)BindingContext;
        }

        public void SetViewBindings()
        {
            this.SetBinding(DisplayTextProperty, "DisplayText");
        }

        //protected override void OnBindingContextChanged()
        //{
        //    var x = BindingContext;
        //}
    }
}