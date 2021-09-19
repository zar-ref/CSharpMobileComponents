using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMobileComponents.Models
{
    public class ModelEventArgs : EventArgs
    {
        public ModelEventArgs(object model)
        {
            ModelHashCode = model.GetHashCode();
            Model = model;
        }

        public object Model { get; set; }
        public int ModelHashCode { get; set; }
    }
}
