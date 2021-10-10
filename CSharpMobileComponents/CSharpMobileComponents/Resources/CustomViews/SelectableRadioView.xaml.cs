using CSharpMobileComponents.Models;
using CSharpMobileComponents.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSharpMobileComponents.Resources.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectableRadioView : StackLayout, ICustomView
    {
        ISelectableModel SelectableItem { get; set; } = null;
        public ICustomView ChildView { get; set; }

        public static readonly BindableProperty SelectItemCommandProperty = BindableProperty.Create(
       propertyName: "SelectItemCommand",
       returnType: typeof(ICommand),
       declaringType: typeof(SelectableRadioView),
       propertyChanged: HandleSelectItemCommandPropertyChanged);


        public ICommand SelectItemCommand
        {
            get { return (ICommand)GetValue(SelectItemCommandProperty); }
            set { SetValue(SelectItemCommandProperty, value); }
        }

        private static void HandleSelectItemCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SelectableRadioView)bindable;
            var newCommand = (ICommand)newValue;
            control.SelectItemCommand = newCommand;
            //control.toggleSelectionButton.Command = newCommand;
            //control.toggleSelectionButton.CommandParameter = control.SelectableItem;
        }

        public SelectableRadioView()
        {
            InitializeComponent();
            toggleSelectionButton.Clicked += ToggleSelectionButton_Clicked;
            
        }

        private void ToggleSelectionButton_Clicked(object sender, EventArgs e)
        {
          
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            var bindingContext = BindingContext;
            if (bindingContext == null)
                return;
            var selectableItemReceived = BindingContext as ISelectableModel;
            if (SelectableItem == null)
                SelectableItem = selectableItemReceived;
        }

        public void SetViewBindings()
        {
            //this.SetBinding
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
            var bindingContext = BindingContext as ISelectableModel;
            if (bindingContext == null)
                return;
            //SetViewBindings();
        }
    }
}