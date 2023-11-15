using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Clock.ViewModels
{
    public abstract class AlarmSharedCommand : CommandBase
    {
        protected AlarmViewModel _alarmViewModel;

        protected AlarmSharedCommand(AlarmViewModel alarmViewModel)
        {
            _alarmViewModel = alarmViewModel;
            _alarmViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return CanExecuteShared(parameter);
        }

        protected bool CanExecuteShared(object parameter)
        {
            if (_alarmViewModel.ClockAlarm == null) return false;
            Regex _regex = new Regex("[^0-9.-]+");
            return _alarmViewModel.ClockAlarm.Hour.Length == 2 &&
                _alarmViewModel.ClockAlarm.Minute.Length == 2 &&
                !_regex.IsMatch(_alarmViewModel.ClockAlarm.Hour) &&
                !_regex.IsMatch(_alarmViewModel.ClockAlarm.Minute) &&
                Int32.Parse(_alarmViewModel.ClockAlarm.Hour) >= 0 && Int32.Parse(_alarmViewModel.ClockAlarm.Hour) < 24 &&
                Int32.Parse(_alarmViewModel.ClockAlarm.Minute) >= 0 && Int32.Parse(_alarmViewModel.ClockAlarm.Minute) < 60 &&
                base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AlarmViewModel.Hour) || 
                e.PropertyName == nameof(AlarmViewModel.Minute))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
