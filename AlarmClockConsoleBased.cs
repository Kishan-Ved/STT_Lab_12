using System;
using System.Threading;

namespace STT_Lab_12_Alarm_Clock_Console
{
    public delegate void AlarmEvent(); // This is a blueprint for methods

    class AlarmClock
    {
        public event AlarmEvent raiseAlarm; // Event of type delegate (it uses the blueprint of AlarmEvent)

        private TimeSpan alarmTime;

        public void SetAlarm(TimeSpan time)
        {
            alarmTime = time;
            Console.WriteLine("Alarm is set at time: " + alarmTime);
            checkTime();
        }

        private void checkTime()
        {
            while (true)
            {
                TimeSpan curr = DateTime.Now.TimeOfDay;

                if (curr.Hours == alarmTime.Hours &&
                    curr.Minutes == alarmTime.Minutes &&
                    curr.Seconds == alarmTime.Seconds)
                {
                    raiseAlarm?.Invoke();
                    break;
                }

                Thread.Sleep(1000);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AlarmClock clock = new AlarmClock();
            clock.raiseAlarm += Ring_alarm; // Subscribe to Ring_alarm method to raiseAlarm event

            Console.WriteLine("Enter time in HH:MM:SS format:");
            string input = Console.ReadLine();

            if (TimeSpan.TryParse(input, out TimeSpan userTime))
            {
                clock.SetAlarm(userTime);
            }
            else
            {
                Console.WriteLine("Invalid time format.");
            }

            Console.ReadLine();
        }

        static void Ring_alarm()
        {
            Console.WriteLine("Alarm started");
            Console.WriteLine("Ring... Ring... Ring...");
        }
    }
}
