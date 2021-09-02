using CSharpMobileComponents.Models;
using CSharpMobileComponents.Models.Interfaces;
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
    public partial class SelectableRadioViewCell : ViewCell, ISelectableViewCell
    {

        public View ChildContentView
        {
            get { return this.ChildViewCellContainer.Content; }
            set { this.ChildViewCellContainer.Content = value; }
        }

        SelectableModel SelectableItem { get; set; } = null;

        public SelectableRadioViewCell()
        {
            InitializeComponent();
            SelectableItem = (SelectableModel)BindingContext;
        }
    }
}