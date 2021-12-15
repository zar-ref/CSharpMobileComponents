using CSharpMobileComponents.Models;
using CSharpMobileComponents.Models.Interfaces;
using CSharpMobileComponents.Models.Lists;
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
    public partial class GroupKeyStringOnlyView : Label, ICustomView
    {
        string TextItem { get; set; } = null;
        public static readonly BindableProperty DisplayTextProperty = BindableProperty.Create(
         propertyName: "DisplayText",
         returnType: typeof(string),
         declaringType: typeof(GroupKeyStringOnlyView),
         propertyChanged: HandleDisplayTextPropertyChanged);

        private static void HandleDisplayTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (GroupKeyStringOnlyView)bindable;
            var newText = (string)newValue;
            control.TextItem = newText;
            control.Text = newText;
        }

        public GroupKeyStringOnlyView()
        {
            InitializeComponent();
        }
        protected override void OnBindingContextChanged()
        {

            base.OnBindingContextChanged();

            var bindingContext = BindingContext as string;
            if (bindingContext == null)
                return;
            if (TextItem == null)
            {
                TextItem = bindingContext;
                SetViewBindings();
            }

            if (TextItem != bindingContext)
            {
                TextItem = bindingContext;
                SetViewBindings();
            }


        }

        public ICustomView ChildView { get; set; }

        public void SetBindingContext(object bindingContext)
        {
            //var baseModel = bindingContext as BaseModel;
            //baseModel.PropertyChanged += Model_PropertyChanged;
            this.BindingContext = bindingContext;
        }

        public void SetViewBindings()
        {
            this.SetValue(DisplayTextProperty, TextItem);
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.BindingContext = sender;
            var bindingContext = BindingContext as GroupingTestModel;
            if (bindingContext == null)
                return;
            SetViewBindings();
        }
    }
}