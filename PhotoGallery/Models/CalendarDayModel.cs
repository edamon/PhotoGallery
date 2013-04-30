using System;
using System.Collections.Generic;

namespace PhotoGallery.Models
{
    public class CalendarDayModel
    {
        private DateTime _date;

        public DateTime Date { set { _date = value; } }
        public string DateString { get { return _date.ToShortDateString(); } }
        public string MonthAbbreviation { get { return _date.ToString("MMMM").Substring(0, 3); } }
        public int DayOfMonth { get { return _date.Day; } }
        public string DayOfWeek { get; set; }
        public bool IsInCurrentMonth { get; set; }
        public bool HasEvents { get; set; }

        public IEnumerable<EventModel> Events { get; set; }
    }
}