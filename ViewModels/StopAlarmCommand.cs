using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Clock.ViewModels
{
    public class StopAlarmCommand : AlarmSharedCommand
    {
        public StopAlarmCommand(AlarmViewModel viewModel) : base(viewModel)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return _alarmViewModel.ClockAlarm.IsAlarmSet && CanExecuteShared(parameter);
        }

        public override void Execute(object parameter)
        {
            _alarmViewModel.ClockAlarm.SetOff();
            ((CommandBase)_alarmViewModel.SetAlarmCommand).RaiseCanExecutedChanged();
            RaiseCanExecutedChanged();
        }
    }
}
