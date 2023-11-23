using Clock.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Clock.ViewModels
{
    public class AlarmViewModel : TabItemViewModel
    {
        private Alarm _clockAlarm;

        /// <summary>
        /// Gets the Alarm instance.
        /// </summary>
        public Alarm ClockAlarm => _clockAlarm;

        public string Hour
        {
            get
            {
                return _clockAlarm.Hour;
            }
            set
            {
                _clockAlarm.Hour = value;
                RaisePropertyChanged();
            }
        }

        public string Minute
        {
            get
            {
                return _clockAlarm.Minute;
            }
            set 
            { 
                _clockAlarm.Minute = value;
                RaisePropertyChanged();
            }
        }

        private string _timeLeftMsg;
        public string TimeLeftMsg
        {
            get
            {
                return _timeLeftMsg;
            }
            set
            {
                _timeLeftMsg = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets the SetAlarmCommand for the ViewModel.
        /// </summary>
        public ICommand SetAlarmCommand { get; }

        public ICommand StopAlarmCommand { get; }

        /// <summary>
        /// Initializes new instance of AlarmViewModel
        /// </summary>
        public AlarmViewModel() : base("Alarm")
        {
            _clockAlarm = new Alarm("06", "00");
            _clockAlarm.TimeArrived += (sender, e) =>
            {
                MessageBox.Show("Good morning", "Alarm", MessageBoxButton.OK, MessageBoxImage.Information);

            };
            SetAlarmCommand = new SetAlarmCommand(this);
            StopAlarmCommand = new StopAlarmCommand(this);
        }

        public async Task UpdateTimeLeftMsg()
        {
            await Task.Run(() =>
            {
                while (_clockAlarm.IsAlarmSet)
                {
                    var now = DateTime.Now;
                    var targetTime = new DateTime(now.Year, now.Month, now.Day, Int32.Parse(Hour), Int32.Parse(Minute), 0);
                    var timeDifference = targetTime - now;
                    var diff = $"Alarm will occur in {timeDifference.Hours} hours and {timeDifference.Minutes} minutes.";
                    if (diff != TimeLeftMsg) TimeLeftMsg = diff;
                }
                TimeLeftMsg = string.Empty;
            });
        }
    }
}
