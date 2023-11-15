using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Clock.ViewModels
{
    public class SetAlarmCommand : AlarmSharedCommand
    {

        /// <summary>
        /// Initializes a new instance of the AlarmUpdateCommand class.
        /// </summary>
        /// <param name="viewModel"></param>
        public SetAlarmCommand(AlarmViewModel viewModel) : base(viewModel)
        {
        }

        public override void Execute(object parameter)
        {
            _alarmViewModel.ClockAlarm.SetOn();
            Task.Run(() => _alarmViewModel.ClockAlarm.CheckTime());
            OnCanExecutedChanged();
        }
    }
}