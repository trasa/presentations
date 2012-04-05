using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SLExtensions.Input;

namespace BindingQuestion.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Commands.ToggleChild.Executed += ToggleChild_Executed;
        }


        private bool isVisible;

        public Visibility IsChildVisible
        {
            get { return isVisible ? Visibility.Visible : Visibility.Collapsed; }
        }

        public bool IsVisible
        {
            get { return isVisible;}
            set
            {
                isVisible = value;
                InvokePropertyChanged("IsChildVisible");
            }
        }


        private void ToggleChild_Executed(object sender, ExecutedEventArgs e)
        {
            IsVisible = !IsVisible;
        }



        protected void InvokePropertyChanged(string propertyName)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChangedEventHandler h = PropertyChanged;
            if (h != null) h(this, e);
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
