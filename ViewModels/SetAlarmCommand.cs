using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utilities;

namespace Clock.ViewModels
{
    public class SetAlarmCommand : AlarmSharedCommand, IAsyncCommand
    {

        /// <summary>
        /// Initializes a new instance of the AlarmUpdateCommand class.
        /// </summary>
        /// <param name="viewModel"></param>
        public SetAlarmCommand(AlarmViewModel viewModel) : base(viewModel)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return !_alarmViewModel.ClockAlarm.IsAlarmSet && CanExecuteShared(parameter);
         }

        public override void Execute(object parameter)
        {
            ExecuteAsync(parameter).FireAndForgetSafeAsync();
        }

        public async Task ExecuteAsync(object parameter)
        {
            _alarmViewModel.ClockAlarm.SetOn();
            var checkTimeTask = _alarmViewModel.ClockAlarm.CheckTimeAsync();
            ((CommandBase)_alarmViewModel.StopAlarmCommand).RaiseCanExecutedChanged();
            RaiseCanExecutedChanged();
            await checkTimeTask;
        }
    }
}