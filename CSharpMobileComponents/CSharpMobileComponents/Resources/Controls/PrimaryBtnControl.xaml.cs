 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSharpMobileComponents.Resources.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrimaryBtnControl : Frame 
    {

        public static  readonly BindableProperty DisplayTextProperty = BindableProperty.Create(
         propertyName: "DisplayText",
         returnType: typeof(string),
         declaringType: typeof(PrimaryBtnControl), 
         propertyChanged: HandleDisplayTextPropertyChanged);

        private static void HandleDisplayTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PrimaryBtnControl)bindable;
            var newText = (string)newValue;
            control.DisplayText = newText;
            control.button.Text = newText;
        }
        public string DisplayText
        {
            get { return (string)GetValue(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }

        public event EventHandler ButtonClicked;

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        propertyName: "Command",
        returnType: typeof(ICommand),
        declaringType: typeof(PrimaryBtnControl), 
        propertyChanged: HandleCommandPropertyChanged);


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        propertyName: "CommandParameter",
        returnType: typeof(object),
        declaringType: typeof(PrimaryBtnControl), 
        propertyChanged: HandleCommandParameterPropertyChanged);


        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        private static void HandleCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PrimaryBtnControl)bindable;
            var newCommand = (ICommand)newValue;
            control.Command = newCommand;
            control.button.Command = newCommand;
            if (newCommand != null)
                control.button.Clicked -= control.Button_Clicked;
        }

        private static void HandleCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PrimaryBtnControl)bindable;
            var newCommandParam = (object)newValue;
            control.CommandParameter = newCommandParam;
            control.button.CommandParameter = newCommandParam;
            if (newCommandParam != null)
                control.button.Clicked -= control.Button_Clicked;
        }
        public PrimaryBtnControl()
        {
            InitializeComponent();
            button.Text = DisplayText;
            button.Clicked += Button_Clicked;
            button.Command = Command;
            button.CommandParameter = CommandParameter;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(sender, e);
        }


    }
}