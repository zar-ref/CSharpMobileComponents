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
            SetAlertTitleLabel(alertModel);
            simpleAlertTextLabel.Text = alertModel.AlertMessage;
            SetSimpleAlertActionButtonText(alertModel);
            simpleAlertActionButton.IsVisible = true;
            simpleAlertActionButton.Clicked += SimpleAlertActionButton_Clicked;

        }

        private void SimpleAlertActionButton_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<object>(this, Constants.CustomControlsMessagesNames.CloseAlertModal.ToString());
        }

        private void SetSimpleAlertActionButtonText(AlertModel alertModel)
        {
            if (!string.IsNullOrEmpty(alertModel.AlertActionButtonText))
                simpleAlertActionButton.Text = alertModel.AlertActionButtonText;
            else
                simpleAlertErrorTitleLabel.SetBinding(Label.TextProperty, BaseViewModel.GetTranslationBindingFromResource("label-ok"));
        }

        private void SetAlertTitleLabel(AlertModel alertModel)
        {
            if (ErrorAlertModals.Contains((int)alertModel.AlertType))
            {
                if (!string.IsNullOrEmpty(alertModel.AlertTitle))
                    simpleAlertErrorTitleLabel.Text = alertModel.AlertTitle;
                else
                    simpleAlertErrorTitleLabel.SetBinding(Label.TextProperty, BaseViewModel.GetTranslationBindingFromResource("label-error"));
            }
            else if (InfoAlertModals.Contains((int)alertModel.AlertType))
            {
                if (!string.IsNullOrEmpty(alertModel.AlertTitle))
                    simpleAlertTitleLabel.Text = alertModel.AlertTitle;
                else
                    simpleAlertTitleLabel.SetBinding(Label.TextProperty, BaseViewModel.GetTranslationBindingFromResource("label-alert"));
            }
        }

        private void SetSimpleAlertWithCommandAction(AlertModel alertModel)
        {
            SetAlertTitleLabel(alertModel);
            simpleAlertTextLabel.Text = alertModel.AlertMessage;
            SetSimpleAlertActionButtonText(alertModel);
            simpleAlertActionButton.IsVisible = true;
            simpleAlertActionButton.Command = alertModel.Command;
            if (alertModel.CommandParameter != null)
                simpleAlertActionButton.CommandParameter = alertModel.CommandParameter;
            simpleAlertActionButton.IsVisible = true;

        }

        private   void SetSimpleYesOrNoChoiceAlertAction(AlertModel alertModel)
        {
            SetAlertTitleLabel(alertModel);
            simpleAlertTextLabel.Text = alertModel.AlertMessage;
            choiceAlertActionsStack.IsVisible = true;
            if (!string.IsNullOrEmpty(alertModel.AlertActionButtonYesText))
                yesOptionButton.Text = alertModel.AlertActionButtonYesText;
            else
                yesOptionButton.SetBinding(Button.TextProperty, BaseViewModel.GetTranslationBindingFromResource("label-yes"));
            yesOptionButton.Command = alertModel.ButtonYesCommand;
            yesOptionButton.CommandParameter = alertModel.ActionButtonYesCommandParameter;

            if (!string.IsNullOrEmpty(alertModel.AlertActionButtonNoText))
                noOptionButton.Text = alertModel.AlertActionButtonNoText;
            else
                noOptionButton.SetBinding(Button.TextProperty, BaseViewModel.GetTranslationBindingFromResource("label-no"));
            noOptionButton.Command = alertModel.ButtonNoCommand;
            noOptionButton.CommandParameter = alertModel.ActionButtonNoCommandParameter;
            //choiceAlertActionsStack.IsVisible = true;

        }
    }
}