using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using static CSharpMobileComponents.Resources.Constants;

namespace CSharpMobileComponents.Models
{
    public class AlertModel
    {
        public ICommand Command { get; set; }
        public object CommandParameter { get; set; }
        public AlertGenerationTypes AlertGenerationType { get; set; }
        public AlertTypes AlertType { get; set; }
        public string AlertTitle { get; set; }
        public string AlertMessage { get; set; }
        public string AlertActionButtonText { get; set; }

        public ICommand ButtonYesCommand { get; set; }
        public string AlertActionButtonYesText { get; set; }
        public AlertYesOrNoChoiceCommandParameterModel ActionButtonYesCommandParameter { get; set; }

        public ICommand ButtonNoCommand { get; set; }
        public string AlertActionButtonNoText { get; set; }
        public AlertYesOrNoChoiceCommandParameterModel ActionButtonNoCommandParameter { get; set; }


        /// <summary>
        /// Simple Alert
        /// </summary>
        /// <param name="alertType"></param>
        /// <param name="alertTitle"></param>
        /// <param name="alertMessage"></param>
        public AlertModel(AlertTypes alertType, string alertTitle, string alertMessage)
        {
            AlertGenerationType = AlertGenerationTypes.Simple;
            AlertType = alertType; 
            AlertTitle = alertTitle;
            AlertMessage = alertMessage;
        }




        /// <summary>
        ///  Simple Alert with Command
        /// </summary>
        /// <param name="alertType"></param>
        /// <param name="alertTitle"></param>
        /// <param name="alertMessage"></param>
        /// <param name="alertActionButtonText"></param>
        /// <param name="command"></param>
        /// <param name="commandParameter"></param>
        public AlertModel(AlertTypes alertType, string alertTitle, string alertMessage, string alertActionButtonText, ICommand command, object commandParameter = null)
        {
            AlertGenerationType = AlertGenerationTypes.SimpleWithCommand;
            AlertType = alertType;
            AlertTitle = alertTitle;
            AlertMessage = alertMessage;
            AlertActionButtonText = alertActionButtonText;

            Command = command;
            if (commandParameter != null)
                CommandParameter = commandParameter;
        }

        /// <summary>
        /// Alert with yes or no choice
        /// </summary>
        /// <param name="alertTitle"></param>
        /// <param name="alertMessage"></param>
        /// <param name="buttonYesCommand"></param>
        /// <param name="alertActionButtonYesText"></param>
        /// <param name="buttonNoCommand"></param>
        /// <param name="buttonYesCommandParameter"></param>
        /// <param name="alertActionButtonNoText"></param>
        /// <param name="buttonNoCommandParameter"></param>
        public AlertModel
            (
            string alertTitle,
            string alertMessage,
            ICommand buttonYesCommand,
            string alertActionButtonYesText,
            ICommand buttonNoCommand,
            AlertYesOrNoChoiceCommandParameterModel buttonYesCommandParameter,
            string alertActionButtonNoText,
            AlertYesOrNoChoiceCommandParameterModel buttonNoCommandParameter
            )
        {
            AlertGenerationType = AlertGenerationTypes.YesOrNoChoice;
            AlertType = AlertTypes.Choice;
            AlertTitle = alertTitle;
            AlertMessage = alertMessage;

            ButtonYesCommand = buttonYesCommand;
            if (buttonYesCommandParameter != null)
                ActionButtonYesCommandParameter = buttonYesCommandParameter;
            if (!string.IsNullOrEmpty(alertActionButtonYesText))
                AlertActionButtonYesText = alertActionButtonYesText;

            ButtonNoCommand = buttonNoCommand;
            if (buttonNoCommandParameter != null)
                ActionButtonNoCommandParameter = buttonNoCommandParameter;
            if (!string.IsNullOrEmpty(alertActionButtonNoText))
                AlertActionButtonNoText = alertActionButtonNoText;

        }
    }


}
