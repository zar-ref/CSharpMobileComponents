using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSharpMobileComponents.Resources.Controls.Interfaces
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseSelectableList : ViewCell
    {
        public BaseSelectableList()
        {
            InitializeComponent();
        }
    }
}