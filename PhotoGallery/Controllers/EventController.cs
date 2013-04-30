using PhotoGallery.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace PhotoGallery.Controllers
{
    public class EventController : Controller
    {
        //
        // GET: /Event/

        public JsonResult EventCalendar(string dateTimeMonth)
        {
            if (String.IsNullOrEmpty(dateTimeMonth))
            {
                throw new ArgumentNullException("dateTimeMonth");
            }

            //get the list of events from a repo
            var events = LoadEvents();

            var dtf = CultureInfo.CurrentCulture.DateTimeFormat;
            DateTime currentMonth;
            DateTime.TryParse(dateTimeMonth, out currentMonth);

            
            var cal = new MonthCalendarModel
                {
                    CurrentMonth = currentMonth.Date
                };

            var dayToRender = cal.FirstDayToRender;

            //populate the collection of days and events
            while (dayToRender <= cal.LastDayToRender.AddDays(1))   //need to add 1 to get the last day
            {
                DateTime day = dayToRender;     //prevent access to modified closure
                cal.CalendarDays.Add(
                    new CalendarDayModel
                    {
                        Date = day,
                        DayOfWeek = Enum.GetName(typeof(DayOfWeek), day.DayOfWeek),
                        IsInCurrentMonth = day.Month == currentMonth.Month,         //is it a fillerDay?
                        HasEvents = events.Any(x => day.DayOfYear.Equals(x.StartDate.DayOfYear)),        //does the day have events?
                        Events = events.Where(x => day.DayOfYear.Equals(x.StartDate.DayOfYear))
                    });

                //increment
                dayToRender = dayToRender.AddDays(1);
            }

            return Json(cal, JsonRequestBehavior.AllowGet);
        }

        private List<EventModel> LoadEvents()
        {
            //TODO: call a repo, map (new) poco Event to EventModel
            return new List<EventModel>
                {
                    new EventModel
                        {
                            Title = "Good Times",
                            Description = "Awesome Event",
                            StartDate = new DateTime(2013, 4, 20, 13, 0, 0),
                            Location = "Milwaukee, WI"
                        },
                        new EventModel
                        {
                            Title = "May Day Ride",
                            Description = "Big group ride",
                            StartDate = new DateTime(2013, 5, 1, 18, 0, 0),
                            Location = "Milwaukee, WI"
                        }
                }; 

        }
    }
}
