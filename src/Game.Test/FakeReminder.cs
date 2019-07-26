using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Test
{
    public class FakeReminder : IGrainReminder
    {
        public FakeReminder(string reminderName, TimeSpan dueTime, TimeSpan period)
        {
            ReminderName = reminderName;
            DueTime = dueTime;
            Period = period;
        }

        public string ReminderName { get; }
        public TimeSpan DueTime { get; }
        public TimeSpan Period { get; }
    }
}
