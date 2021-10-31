using CSharpMobileComponents.Resources.Controls.Interfaces;
using CSharpMobileComponents.Resources.CustomViews.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSharpMobileComponents.Resources.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomGroupKeyStackLayoutListItem : StackLayout, IGroupKeyStackLayoutListItem
    {
        public object GroupKeyItem { get; set; }
        public ICustomView View { get; set; }

        public CustomGroupKeyStackLayoutListItem(IGroupKeyStackLayoutListItem groupKeyItem)
        {
            GroupKeyItem = groupKeyItem.GroupKeyItem;
            View = groupKeyItem.View; 
            InitializeComponent();
            view.Children.Add((View)View);
        }

      
    }
}