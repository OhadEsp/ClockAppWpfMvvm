using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock.ViewModels
{
    public abstract class TabItemViewModel : ViewModelBase
    {
        public string TabName { get; }

        public TabItemViewModel(string tabName)
        {
            TabName = tabName;
        }
    }
}
