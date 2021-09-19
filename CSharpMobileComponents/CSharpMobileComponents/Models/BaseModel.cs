using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;


namespace CSharpMobileComponents.Models
{

    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public event EventHandler<ModelEventArgs> RaiseModelPropertyChangedEvent = delegate { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler changed = PropertyChanged;            
            changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
             
 
        }
    }

}
