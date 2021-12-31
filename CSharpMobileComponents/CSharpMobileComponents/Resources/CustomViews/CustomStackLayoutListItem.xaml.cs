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
     
        public double? MaxHeight { get; set; } = null;
        public CustomStackLayoutListItem(IStackLayoutListItem listItem)
        {
            Item = listItem.Item;
            View = listItem.View;
            GroupKey = listItem?.GroupKey ?? null;
            OnItemTappedCommand = listItem?.OnItemTappedCommand ?? null;
            ItemTappedCommandParameter = listItem?.ItemTappedCommandParameter ?? null;
             
            InitializeComponent();
            if (listItem.MaxHeight != null)
                this.MaxHeight = this.HeightRequest = listItem.MaxHeight.Value;

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

        public double GetStackHeight()
        {
            return this.Height;
        }

        public void SetStackHeight(double height)
        {
            this.HeightRequest = height;
        }

        private void SelectItemButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}