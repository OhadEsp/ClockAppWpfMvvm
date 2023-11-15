using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock.ViewModels
{
    public class StopAlarmCommand : AlarmSharedCommand
    {
        public StopAlarmCommand(AlarmViewModel alarmViewModel) : base(alarmViewModel)
        {
        }

        public override void Execute(object parameter)
        {
            _alarmViewModel.ClockAlarm.SetOff();
        }
    }
}
