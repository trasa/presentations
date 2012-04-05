using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using BindingQuestion.ViewModels;

namespace BindingQuestion.Views
{
    public partial class ChildView : UserControl
    {
        public ChildView()
        {
            InitializeComponent();
        }

        private void btnGoAway_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
