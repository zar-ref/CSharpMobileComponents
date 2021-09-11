using CSharpMobileComponents.Models;
using CSharpMobileComponents.Models.Interfaces;
using CSharpMobileComponents.Resources.Controls.Interfaces;
using CSharpMobileComponents.Resources.CustomViews;
using CSharpMobileComponents.Resources.ViewCells;
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


        //Default Behaviour is selecting the item when pressing the view cell
        public static readonly BindableProperty ChildViewProperty = BindableProperty.Create(
           propertyName: "ChildView",
           returnType: typeof(View),
           declaringType: typeof(SelectableListView),
           propertyChanged: HandleChildViewPropertyChanged);

        public View ChildView
        {
            get { return (View)GetValue(ChildViewProperty); }
            set { SetValue(ChildViewProperty, value); }
        }

        public static readonly BindableProperty HasDefaultBehaviourProperty = BindableProperty.Create(
         propertyName: "HasDefaultBehaviour",
         returnType: typeof(bool),
         declaringType: typeof(SelectableListView),
         defaultValue: true);

        public bool HasDefaultBehaviour
        {
            get { return (bool)GetValue(HasDefaultBehaviourProperty); }
            set { SetValue(HasDefaultBehaviourProperty, value); }
        }




        public void HandleItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectableItem = (ISelectableModel)e.Item;
            if (selectableItem == null)
                return;
            var listView = (ExtendedListView)sender;
            if (listView == null)
                return;
            if (!HasMultipleSelections)
            {
                var listItems = (IEnumerable<ISelectableModel>)ItemsSource;
                foreach (var listItem in listItems)
                {
                    if (listItem == selectableItem)
                        continue;
                    listItem.IsSelected = false;
                }
            }
            selectableItem.IsSelected = !selectableItem.IsSelected;
            SelectedItem = selectableItem;
            if (TappedCommand != null)
            {
                TappedCommand?.Execute(e.Item);
            }
        }

        public SelectableListView()
        {
            InitializeComponent(); 
        }

        private static void HandleChildViewPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                var control = (SelectableListView)bindable;

                var newChildView = (ICustomView)newValue;
                var type = newChildView.GetType();
                var dataTemplate = new DataTemplate(() =>
                {
                    ICustomView childView = (ICustomView)Activator.CreateInstance(type);
                    childView.SetViewBindings();
                    var selectableCell = new SelectableRadioViewCell();
                    selectableCell.SetViewBindings();
                    selectableCell.SetValue(SelectableRadioViewCell.ChildViewProperty, childView);
                    //selectableCell.ToggleSelectionButtonClicked += SelectableCell_ToggleSelectionButtonClicked;
                    return selectableCell;
                });
                control.ItemTemplate = dataTemplate;
            }
            catch (Exception ex)
            {
                   
                return;
            }

        }

        //public static  void SelectableCell_ToggleSelectionButtonClicked(object sender, object e)
        //{
        //    var selectableItem = (ISelectableModel)e;
        //    if (!HasMultipleSelections)
        //    {
        //        var listItems = (IEnumerable<ISelectableModel>)ItemsSource;
        //        foreach (var listItem in listItems)
        //        {
        //            if (listItem == selectableItem)
        //                continue;
        //            listItem.IsSelected = false;
        //        }
        //    }
        //    selectableItem.IsSelected = !selectableItem.IsSelected;
        //}
    }
}