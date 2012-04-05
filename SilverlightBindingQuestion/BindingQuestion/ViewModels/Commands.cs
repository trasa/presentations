using System;
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
    public static class Commands
    {
        static Commands()
        {
            ToggleChild = new Command("ToggleChild");
        }

        public static Command ToggleChild { get; private set; }
    }
}
