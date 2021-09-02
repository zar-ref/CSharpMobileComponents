using CSharpMobileComponents.Models;
using CSharpMobileComponents.Models.Interfaces;
using CSharpMobileComponents.Resources.Controls.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents.Resources.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectableListView : ExtendedListView, ISelectableList
    {
        public static readonly BindableProperty SelectableListTypeProperty = BindableProperty.Create(
          propertyName: "SelectableListType",
          returnType: typeof(SelectableListTypes),
          declaringType: typeof(SelectableListView),
          defaultValue: SelectableListTypes.Radio);

        public SelectableListTypes SelectableListType
        {
            get { return (SelectableListTypes)GetValue(SelectableListTypeProperty); }
            set { SetValue(SelectableListTypeProperty, value); }
        }

        public static readonly BindableProperty HasMultipleSelectionsProperty = BindableProperty.Create(
          propertyName: "HasMultipleSelections",
          returnType: typeof(bool),
          declaringType: typeof(SelectableListView),
          defaultValue: false);

        public bool HasMultipleSelections
        {
            get { return (bool)GetValue(HasMultipleSelectionsProperty); }
            set { SetValue(HasMultipleSelectionsProperty, value); }
        }



     
        private void HandleItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectableItem = (SelectableModel)e.Item;
            if (selectableItem == null)
                return;
            var listView = (ExtendedListView)sender;
            if (listView == null)
                return;
            if (!HasMultipleSelections)
            {
                var listItems = (IEnumerable<SelectableModel>)ItemsSource;
                foreach (var listItem in listItems)
                {
                    if (listItem == selectableItem)
                        continue;
                    listItem.IsSelected = false;
                }
            }
            selectableItem.IsSelected = !selectableItem.IsSelected;
            
            if (TappedCommand != null)
            {
                TappedCommand?.Execute(e.Item);
            }
            SelectedItem = null;
        }

        public SelectableListView()
        {
            InitializeComponent();
            ItemTapped += HandleItemTapped; 
        }
    }
}