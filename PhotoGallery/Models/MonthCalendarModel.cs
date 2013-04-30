using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGallery.Models
{
    public class MonthCalendarModel
    {
        public DateTime CurrentMonth { get; set; }
        public DateTime PreviousMonth { get; set; }
        public DateTime NextMonth { get; set; }

        public IEnumerable<CalendarDayModel> CalendarDays { get; set; }
    }
}