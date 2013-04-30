using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoGallery.Extensions;

namespace PhotoGallery.Models
{
    public class MonthCalendarModel
    {
        public DateTime CurrentMonth { get; set; }
        
        public DateTime PreviousMonth
        {
            get
            {
                return CurrentMonth.Date.AddMonths(-1);
            }
        }

        public DateTime NextMonth
        {
            get
            {
                return CurrentMonth.Date.AddMonths(1);
            }
        }

        public DateTime FirstDayToRender
        {
            get
            {
                return CurrentMonth.FirstDayOfMonth().AddDays(-(int)CurrentMonth.FirstWeekDayOfMonth());
            }
        }
        
        public DateTime LastDayToRender
        {
            get
            {
                return CurrentMonth.LastDayOfMonth().AddDays(5 - (int)CurrentMonth.LastWeekDayOfMonth());
            }
        }

        private List<CalendarDayModel> _calendarDays = new List<CalendarDayModel>();
        public List<CalendarDayModel> CalendarDays
        {
            get { return _calendarDays; }
            set { _calendarDays = value; }
        }
    }
}