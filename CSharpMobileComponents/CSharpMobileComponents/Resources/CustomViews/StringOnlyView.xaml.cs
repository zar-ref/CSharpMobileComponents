using CSharpMobileComponents.Models.Interfaces;
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
    public partial class StringOnlyView : Label
    {
        IDisplayTextModel TextItem { get; set; } = null;

        public StringOnlyView()
        {
            InitializeComponent();
            var x = BindingContext;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            var x = BindingContext as IDisplayTextModel;
            if (x == null)
                return;
            TextItem = x;
            Text = TextItem.DisplayText;
        }

        public void SetViewBindings()
        {
            this.SetBinding(TextProperty, "DisplayText"  );
        }

 
    }
}