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
        public ICommand OnSelectItemCommand { get; set; }
        public object SelectItemCommandParameter { get; set; }

        public CustomStackLayoutListItem(IStackLayoutListItem listItem)
        {
            Item = listItem.Item;
            View = listItem.View;
            GroupKey = listItem?.GroupKey ?? null;
            OnSelectItemCommand = listItem?.OnSelectItemCommand ?? null;
            SelectItemCommandParameter = listItem?.SelectItemCommandParameter ?? null;
            InitializeComponent();
            view.Children.Add((View)View);
            if (OnSelectItemCommand != null)
            {
                selectItemButton.Command = OnSelectItemCommand;
                if (SelectItemCommandParameter != null)
                    selectItemButton.CommandParameter = SelectItemCommandParameter;
            }
            //For debug only
            else
            {
                selectItemButton.Clicked += SelectItemButton_Clicked;
            }

        }

        private void SelectItemButton_Clicked(object sender, EventArgs e)
        {
 
        }
    }
}