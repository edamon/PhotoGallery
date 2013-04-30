using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PhotoGallery.Extensions;
using PhotoGallery.Models;

namespace PhotoGallery.Controllers
{
    public class EventController : Controller
    {
        //
        // GET: /Event/

        public JsonResult EventCalendar(string dateTimeMonth)
        {
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
                        HasEvents = events.Any(x => day.Equals(x.StartDate)),        //does the day have events?
                        Events = events.Where(x => day.Equals(x.StartDate))
                    });

                //increment
                dayToRender = dayToRender.AddDays(1);
            }

            return Json(cal);
        }

        private List<EventModel> LoadEvents()
        {
            return new List<EventModel>(); //TODO: call a repo, map (new) poco Event to EventModel

        }
    }
}
