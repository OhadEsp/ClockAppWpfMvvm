using Clock.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clock.Views
{
    /// <summary>
    /// Interaction logic for AlarmUserControl.xaml
    /// </summary>
    public partial class AlarmTabContentView : UserControl
    {
        public AlarmTabContentView()
        {
            InitializeComponent();

            // First option, setting the DataContext and use the binding in the XAML file.
            //DataContext = new AlarmViewModel();

            // Second option, without bindings in the XAML, and using the following code.
            //Binding hourBinding = new Binding("MyAlarm.Hour");
            //hourBinding.Source = new AlarmViewModel();
            //hourTxtBox.SetBinding(TextBox.TextProperty, hourBinding); InitializeComponent();
            //Binding minutesBinding = new Binding("MyAlarm.Minute");
            //minutesBinding.Source = new AlarmViewModel();
            //minutesTxtBox.SetBinding(TextBox.TextProperty, minutesBinding);
        }

        // Using the click event will cause coupling.
        // Not only that we'll have code behind, also we'll need to access the VM from here.
        //private void btnSetAlarm_Click(object sender, RoutedEventArgs e)
        //{
        //    // When using the UpdateSourceTrigger=Explicit
        //    //BindingExpression hourBinding = hourTxtBox.GetBindingExpression(TextBox.TextProperty);
        //    //hourBinding.UpdateSource();
        //    //BindingExpression minutesBinding = minutesTxtBox.GetBindingExpression(TextBox.TextProperty);
        //    //minutesBinding.UpdateSource();
        //}
    }
}
