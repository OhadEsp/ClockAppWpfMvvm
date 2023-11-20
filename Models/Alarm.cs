using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Alarm
    {
        public event EventHandler TimeArrived;

        private string _hour;
        private string _minute;

        public string Hour
        {
            get
            {
                return _hour;
            }

            set
            {
                _hour = value;
            }
        }

        public string Minute
        {
            get
            {
                return _minute;
            }
            set
            {
                _minute = value;
            }
        }

        public bool IsAlarmSet { get; set; }

        public Alarm()
        {
            _hour = "06";
            _minute = "00";
            IsAlarmSet = false;
        }

        public Alarm(string hour, string minute)
        {
            _hour = hour;
            _minute = minute;
            IsAlarmSet = false;
        }

        public void SetOn()
        {
            IsAlarmSet = true;
        }

        public void SetOff()
        {
            IsAlarmSet = false;
        }

        public async Task CheckTimeAsync()
        {
            await Task.Run(() =>
            {
                int hourToAlarm = Int32.Parse(Hour);
                int minuteToAlarm = Int32.Parse(Minute);
                while (IsAlarmSet)
                {
                    DateTime currentTime = DateTime.Now;
                    int currentHour = currentTime.Hour;
                    int currentMinute = currentTime.Minute;

                    if (currentHour == hourToAlarm && currentMinute == minuteToAlarm)
                    {
                        IsAlarmSet = false;
                        Debug.WriteLine("Alarmed");
                        OnTimeArrived();
                        break;
                    }
                }
            });
        }

        private void OnTimeArrived()
        {
            TimeArrived?.Invoke(this, EventArgs.Empty);
        }
    }
}
