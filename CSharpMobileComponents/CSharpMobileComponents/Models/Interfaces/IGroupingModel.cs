using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMobileComponents.Models.Interfaces
{
    public interface IGroupingModel
    {
        object GroupingKey { get; set; }
        string GroupingKeyDisplayText { get; set; }
    }
}
