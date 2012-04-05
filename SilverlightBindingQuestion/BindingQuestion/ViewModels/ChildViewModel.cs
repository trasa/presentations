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

namespace BindingQuestion.ViewModels
{
    public class ChildViewModel  : INotifyPropertyChanged
    {

        protected void InvokePropertyChanged(string propertyName)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChangedEventHandler h = PropertyChanged;
            if (h != null) h(this, e);
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
