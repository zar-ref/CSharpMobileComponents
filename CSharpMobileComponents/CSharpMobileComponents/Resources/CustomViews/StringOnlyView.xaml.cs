﻿using CSharpMobileComponents.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSharpMobileComponents.Resources.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StringOnlyView : Label, ICustomView
    {
        IDisplayTextModel TextItem { get; set; } = null;
        public static readonly BindableProperty DisplayTextProperty = BindableProperty.Create(
         propertyName: "DisplayText",
         returnType: typeof(string),
         declaringType: typeof(StringOnlyView),
         propertyChanged: HandleDisplayTextPropertyChanged);

        private static void HandleDisplayTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (StringOnlyView)bindable;
            var newText = (string)newValue;
            control.DisplayText = newText;
            control.Text = newText;
        }
        public string DisplayText
        {
            get { return (string)GetValue(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }

        public StringOnlyView()
        {
            InitializeComponent(); 
        }

        protected override void OnBindingContextChanged()
        {

            base.OnBindingContextChanged();
            var bindingContext = BindingContext as IDisplayTextModel;
            if (bindingContext == null)
                return;
            if (TextItem == null)
            {
                TextItem = bindingContext;
                SetViewBindings();
            }

            if (TextItem.DisplayText != bindingContext.DisplayText)
            {
                TextItem = bindingContext;
                SetViewBindings();
            } 
        }

        public void SetViewBindings()
        {
            this.SetBinding(DisplayTextProperty, "DisplayText");
        }


    }
}