# How to Disable/Enable SfButton with ICommand usage

This example demonstrates how to to find a way to disable / enable the SfButton when using ICommand. As per the [MSDN](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/data-binding/commanding#the-icommand-interface)suggestion.

> Do not use the IsEnabled property of Button, if you are using the command interface.   

Please refer KB links for more details,

[How to disable the Xamarin Button[SfButton]](https://www.syncfusion.com/kb/11036/how-to-disable-the-xamarin-buttonsfbutton)

Let us have a demo sample with Switch control, and we have changed the enable option of Button based on its IsToggled of Switch.

**[XAML]**

 ```

..  

<Switch HorizontalOptions="Center"  VerticalOptions="Center" IsToggled="{Binding IsButtonEnabled}"  />
<buttons:SfButton 
            ..
            Text="Button" 
            FontSize="18" 
            Command="{Binding ButtonCommand}" >
</buttons:SfButton>

..

 ```

Invoke the CanExecute method of button&#39;s command while changing the model property of IsButtonEnabled (IsToggled&#39;s model property) and, based on the return value of CanExecuteClickCommand, we can enable or disable the Button.

**[C#]**

 ```

        …

        public Command ButtonCommand { get; set; }

        public bool IsButtonEnabled
        {
            get { return isButtonEnabled; }
            set
            {
                isButtonEnabled = value;
                ButtonCommand.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        bool CanExecuteClickCommand(object arg)
        {
            return isButtonEnabled;
        }

        public ViewModel()
        {
            ButtonCommand = new Command(ExecuteClickCommand, CanExecuteClickCommand);
        }
        
       
        void ExecuteClickCommand(object obj)
        {
            //Execute Xamarin.Forms SfButton Command action.
        }

 ```

**See Also** :

[What are the visual states available in Xamarin.Forms Button?](https://help.syncfusion.com/xamarin/button/visualstates)

[How to customize the Xamarin.Forms Button?](https://help.syncfusion.com/xamarin/button/customization)

Also refer our [feature tour](https://www.syncfusion.com/xamarin-ui-controls/xamarin-button) page to know more features available in our button.

## <a name="troubleshooting"></a>Troubleshooting ##
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
