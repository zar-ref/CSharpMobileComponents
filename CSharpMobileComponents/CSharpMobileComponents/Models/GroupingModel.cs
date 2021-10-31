using CSharpMobileComponents.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMobileComponents.Models
{
    public class GroupingModel : IGroupingModel
    {
        public object GroupingKey { get; set; }

        public string GroupingKeyDisplayText { get; set; }
    }
}
