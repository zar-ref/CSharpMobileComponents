using CSharpMobileComponents.Models;
using CSharpMobileComponents.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public ICustomView ChildView { get; set; }

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

        public void SetBindingContext(object bindingContext)
        {
            var baseModel = bindingContext as BaseModel;
            baseModel.PropertyChanged += Model_PropertyChanged;
            this.BindingContext = bindingContext;
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.BindingContext = sender;
            var bindingContext = BindingContext as IDisplayTextModel;
            if (bindingContext == null)
                return;
            SetViewBindings();
        }


    }
}