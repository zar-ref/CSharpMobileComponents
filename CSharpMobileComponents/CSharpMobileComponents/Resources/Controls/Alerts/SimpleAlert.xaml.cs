using CSharpMobileComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSharpMobileComponents.Resources.Controls.Alerts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleAlert : StackLayout
    {

        private Dictionary<string, Action<AlertModel>> AlertActionDictionary = new Dictionary<string, Action<AlertModel>>()
        {
            {Constants.AlertGenerationTypes.Simple.ToString(), new Action<AlertModel>(SetSimpleAlertAction ) },
            {Constants.AlertGenerationTypes.SimpleWithCommand.ToString(), new Action<AlertModel>(SetSimpleAlertWithCommandAction ) },
            {Constants.AlertGenerationTypes.YesOrNoChoice.ToString(), new Action<AlertModel>(SetSimpleYesOrNoChoiceAlertAction ) },
        };

        public SimpleAlert(AlertModel alertModel)
        {
            InitializeComponent();
            AlertActionDictionary[alertModel.AlertGenerationType.ToString()].Invoke(alertModel);

        }

        private static void SetSimpleAlertAction(AlertModel alertModel)
        {

        }

        private static void SetSimpleAlertWithCommandAction(AlertModel alertModel)
        {

        }

        private static void SetSimpleYesOrNoChoiceAlertAction(AlertModel alertModel)
        {

        }
    }
}