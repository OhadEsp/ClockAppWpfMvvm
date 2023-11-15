using Models;
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                MessageBox.Show("Alert", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

            };
            SetAlarmCommand = new SetAlarmCommand(this);
            StopAlarmCommand = new StopAlarmCommand(this);
        }
        
        /// <summary>
        /// Saves changes made to the Alarm instance.
        /// </summary>
        public void SaveChanges()
        {
            Debug.Assert(false, $"Time was updated.");
        }
    }
}
