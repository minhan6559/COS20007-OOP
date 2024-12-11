using System;

namespace ClockProgram
{
    public class Clock
    {
        private Counter _seconds;
        private Counter _minutes;
        private Counter _hours;

        public Clock()
        {
            _seconds = new Counter("Seconds");
            _minutes = new Counter("Minutes");
            _hours = new Counter("Hours");
        }

        public void Tick()
        {
            _seconds.Increment();
            if (_seconds.Ticks != 60) return;

            _seconds.Reset();
            _minutes.Increment();
            if (_minutes.Ticks != 60) return;

            _minutes.Reset();
            _hours.Increment();
            if (_hours.Ticks != 12) return;

            _hours.Reset();
        }

        public void Reset()
        {
            _seconds.Reset();
            _minutes.Reset();
            _hours.Reset();
        }

        public string Time
        {
            get
            {
                return $"{_hours.Ticks:D2}:{_minutes.Ticks:D2}:{_seconds.Ticks:D2}";
            }
        }
    }
}