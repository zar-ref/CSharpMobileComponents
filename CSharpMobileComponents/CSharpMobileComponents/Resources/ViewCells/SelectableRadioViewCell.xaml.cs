using CSharpMobileComponents.Models;
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
    public partial class SelectableRadioViewCell : ViewCell, ISelectableViewCell, ICustomView
    {
        public static readonly BindableProperty ChildViewProperty = BindableProperty.Create(
          propertyName: "ChildView",
          returnType: typeof(View),
          defaultValue: null,
          defaultBindingMode: BindingMode.OneWay,
          declaringType: typeof(SelectableRadioViewCell),
          propertyChanged: HandleChildViewPropertyChanged);

        public View ChildView
        {
            get { return (View)GetValue(ChildViewProperty); }
            set { SetValue(ChildViewProperty, value); }
        }  
        ISelectableModel SelectableItem { get; set; } = null;
        public   event EventHandler<object> ToggleSelectionButtonClicked;
    
        public SelectableRadioViewCell()
        {
            InitializeComponent();
            toggleSelectionButton.Clicked += ToggleSelectionButton_Clicked;

        }

        private void ToggleSelectionButton_Clicked(object sender, EventArgs e)
        {
            ToggleSelectionButtonClicked?.Invoke(sender, BindingContext);
        }

        static void HandleChildViewPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

            var control = (SelectableRadioViewCell)bindable; 
            var v = (StringOnlyView)newValue; 
            v.SetViewBindings();
            control.childView.Children.Add(v);

        }

        
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            var bindingContext = BindingContext;
            if (bindingContext == null)
                return;
            ChildView.SetValue(BindingContextProperty, bindingContext);
            var selectableItemReceived = BindingContext as ISelectableModel;
            if (SelectableItem == null)
                SelectableItem = selectableItemReceived;
            //TODO
            //if(SelectableItem.IsSelected != selectableItemReceived.IsSelected )
             
        }

        public void SetViewBindings()
        {
            //this.SetBinding(DisplayTextProperty, "DisplayText");
        }

      
    }
}