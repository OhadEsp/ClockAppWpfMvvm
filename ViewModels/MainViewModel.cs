using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Clock.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ObservableCollection<TabItemViewModel> _tabItems;
        public ObservableCollection<TabItemViewModel> TabItems => _tabItems;

        private int _selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
            }
        }

        public MainViewModel()
        {
            _tabItems = new ObservableCollection<TabItemViewModel>
            {
                new AlarmViewModel(),
                new StopWatchViewModel()
            };
            _selectedIndex = 0;
        }
    }
}
