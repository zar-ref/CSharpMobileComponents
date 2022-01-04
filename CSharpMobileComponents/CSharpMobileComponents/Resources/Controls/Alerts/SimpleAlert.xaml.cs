using CSharpMobileComponents.Models;
using CSharpMobileComponents.ViewModels;
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



        private Dictionary<string, Action<AlertModel>> AlertActionDictionary = new Dictionary<string, Action<AlertModel>>();

        private static int[] ErrorAlertModals = new int[] { (int)Constants.AlertTypes.Error };
        private static int[] InfoAlertModals = new int[] { (int)Constants.AlertTypes.Info };

        public SimpleAlert(AlertModel alertModel)
        {
            InitializeComponent();
            AlertActionDictionary.Add(Constants.AlertGenerationTypes.Simple.ToString(), new Action<AlertModel>(SetSimpleAlertAction));
            AlertActionDictionary.Add(Constants.AlertGenerationTypes.SimpleWithCommand.ToString(), new Action<AlertModel>(SetSimpleAlertWithCommandAction));
            AlertActionDictionary.Add(Constants.AlertGenerationTypes.YesOrNoChoice.ToString(), new Action<AlertModel>(SetSimpleYesOrNoChoiceAlertAction));

            AlertActionDictionary[alertModel.AlertGenerationType.ToString()].Invoke(alertModel);

        }

        private void SetSimpleAlertAction(AlertModel alertModel)
        {
            if (ErrorAlertModals.Contains((int)alertModel.AlertType))
            {
                if (!string.IsNullOrEmpty(alertModel.AlertTitle))
                    simpleAlertErrorTitleLabel.Text = alertModel.AlertTitle;
                else
                    simpleAlertErrorTitleLabel.SetBinding(Label.TextProperty, BaseViewModel.GetTranslationBindingFromResource("label-error"));

                simpleAlertErrorTitleLabel.IsVisible = true;
                simpleAlertTextLabel.Text = alertModel.AlertMessage;
                simpleAlertActionButton.IsVisible = true;
                simpleAlertActionButton.Clicked += SimpleAlertActionButton_Clicked;


            }
            else if (InfoAlertModals.Contains((int)alertModel.AlertType))
            {
                if (!string.IsNullOrEmpty(alertModel.AlertTitle))
                    simpleAlertTitleLabel.Text = alertModel.AlertTitle;
                else
                    simpleAlertErrorTitleLabel.SetBinding(Label.TextProperty, BaseViewModel.GetTranslationBindingFromResource("label-alert"));
                simpleAlertTitleLabel.IsVisible = true;
                simpleAlertTextLabel.Text = alertModel.AlertMessage;
                simpleAlertActionButton.IsVisible = true;
                simpleAlertActionButton.Clicked += SimpleAlertActionButton_Clicked;
             
            }
        }

        private void SimpleAlertActionButton_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<object>(this, Constants.CustomControlsMessagesNames.CloseAlertModal.ToString());
        }

        private static void SetSimpleAlertWithCommandAction(AlertModel alertModel)
        {

        }

        private static void SetSimpleYesOrNoChoiceAlertAction(AlertModel alertModel)
        {

        }
    }
}