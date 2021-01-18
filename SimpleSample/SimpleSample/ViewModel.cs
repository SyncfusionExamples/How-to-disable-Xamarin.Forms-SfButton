using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace SimpleSample
{
    public class ViewModel : INotifyPropertyChanged
    {
        private bool isButtonEnabled = false;
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


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
