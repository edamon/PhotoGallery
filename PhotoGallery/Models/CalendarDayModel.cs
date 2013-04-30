using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGallery.Models
{
    public class CalendarDayModel
    {
        public DateTime Date { get; set; }
        public string DayOfWeek { get; set; }
        public bool IsInCurrentMonth { get; set; }
        public bool HasEvents { get; set; }

        public IEnumerable<EventModel> Events { get; set; }
    }
}