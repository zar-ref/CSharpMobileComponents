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
    public partial class GroupKeyStringOnlyView : Label, ICustomView
    {
        IGroupingModel TextItem { get; set; } = null;
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

        public GroupKeyStringOnlyView()
        {
            InitializeComponent();
        }
        protected override void OnBindingContextChanged()
        {

            base.OnBindingContextChanged();

            var bindingContext = BindingContext as IGroupingModel;
            if (bindingContext == null)
                return;
            if (TextItem == null)
            {
                TextItem = bindingContext;
                SetViewBindings();
            }

            if (TextItem.GroupingKeyDisplayText != bindingContext.GroupingKeyDisplayText)
            {
                TextItem = bindingContext;
                SetViewBindings();
            }


        }

        public ICustomView ChildView { get; set; }

        public void SetBindingContext(object bindingContext)
        {
            var baseModel = bindingContext as BaseModel;
            baseModel.PropertyChanged += Model_PropertyChanged;
            this.BindingContext = bindingContext;
        }

        public void SetViewBindings()
        {
            this.SetBinding(DisplayTextProperty, "GroupingDisplayText");
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