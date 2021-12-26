using CSharpMobileComponents.Resources.Controls.Interfaces;
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
    public partial class CustomStackLayoutListItem : StackLayout, IStackLayoutListItem
    {
        public object Item { get; set; }
        public ICustomView View { get; set; }
        public object GroupKey { get; set; } 
        public ICommand OnItemTappedCommand { get; set; }
        public object ItemTappedCommandParameter { get; set; }
        public bool IsGroupingHeader { get; set; } = false;
        public CustomStackLayoutListItem(IStackLayoutListItem listItem)
        {
            Item = listItem.Item;
            View = listItem.View;
            GroupKey = listItem?.GroupKey ?? null; 
            OnItemTappedCommand = listItem?.OnItemTappedCommand ?? null;
            ItemTappedCommandParameter = listItem?.ItemTappedCommandParameter ?? null;
            IsGroupingHeader = listItem.IsGroupingHeader;
            InitializeComponent(); 
            view.Children.Add((View)View);
            if (OnItemTappedCommand != null)
            {
                itemTappedButton.Command = OnItemTappedCommand;
                if (ItemTappedCommandParameter != null)
                    itemTappedButton.CommandParameter = ItemTappedCommandParameter;
            }
            //For debug only
            else
            {
                itemTappedButton.Clicked += SelectItemButton_Clicked;
            }

        }

        private void SelectItemButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}