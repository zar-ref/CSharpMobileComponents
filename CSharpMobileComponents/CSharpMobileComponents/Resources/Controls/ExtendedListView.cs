using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CSharpMobileComponents.Resources.Controls
{
    public class ExtendedListView : ListView
    {
        public ExtendedListView() : this(ListViewCachingStrategy.RecycleElement)
        {
        }
        public ExtendedListView(ListViewCachingStrategy cachingStrategy) : base(cachingStrategy)
        {
        }


        public static readonly BindableProperty TappedCommandProperty =
            BindableProperty.Create(nameof(TappedCommand), typeof(ICommand), typeof(ExtendedListView), default(ICommand));

        public ICommand TappedCommand
        {
            get { return (ICommand)GetValue(TappedCommandProperty); }
            set { SetValue(TappedCommandProperty, value); }
        }

        public static readonly BindableProperty ItemAppearingCommandProperty =
            BindableProperty.Create(nameof(ItemAppearingCommand), typeof(ICommand), typeof(ExtendedListView), default(ICommand));

        public ICommand ItemAppearingCommand
        {
            get { return (ICommand)GetValue(ItemAppearingCommandProperty); }
            set { SetValue(ItemAppearingCommandProperty, value); }
        }

        public static readonly BindableProperty ItemDisappearingCommandProperty =
         BindableProperty.Create(nameof(ItemDisappearingCommand), typeof(ICommand), typeof(ExtendedListView), default(ICommand));


        public ICommand ItemDisappearingCommand
        {
            get { return (ICommand)GetValue(ItemDisappearingCommandProperty); }
            set { SetValue(ItemDisappearingCommandProperty, value); }
        }
    }
}
