using Clock.ViewModels;
using Clock.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Clock.Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //var mainViewModel = new MainViewModel();
            //mainViewModel.TabItems.Add(new AlarmViewModel());
            //mainViewModel.TabItems.Add(new StopWatchViewModel());
            //MainWindow = new MainView()
            //{
            //    DataContext = new MainViewModel()
            //};

            var bootstrapper = new Bootstrapper();
            bootstrapper.Start();
            
            //MainWindow.Show();
            //base.OnStartup(e);
        }
    }
}
