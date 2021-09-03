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
    public partial class StringOnlyView : ContentView
    {
        public StringOnlyView()
        {
            InitializeComponent();
        }
    }
}