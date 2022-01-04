using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMobileComponents.Models
{
    public class AlertYesOrNoChoiceCommandParameterModel
    {
        /// <summary>
        /// Choice should be yes for true or no for false
        /// </summary>
        public bool Choice { get; set; }
        public object CommandParameter { get; set; }
    }
}
