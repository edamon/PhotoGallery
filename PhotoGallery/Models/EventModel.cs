using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGallery.Models
{
    public class EventModel
    {
        public string Description { get; set; }
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Date to begin displaying on customer site
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// String representation of event image
        /// </summary>
        public Guid? ImageId { get; set; }

        /// <summary>
        /// Page to display event details
        /// </summary>
        public Guid? DetailsPageId { get; set; }

        /// <summary>
        /// Indicates whether the event is featured
        /// </summary>
        public bool IsFeatured { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the dealership id.
        /// </summary>
        /// <value>
        /// The dealership id.
        /// </value>
        public Guid DealershipId { get; set; }

        /// <summary>
        /// Gets or sets the Calendar Item id.
        /// This field is Id from Zimbra or other third party.
        /// </summary>
        /// <value>The id.</value>
        public string CalendarItemId { get; set; }

        /// <summary>
        /// Customer Id
        /// </summary>
        /// <value>The Customer Id.</value>
        public Guid? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the action type code.
        /// </summary>
        /// <value>
        /// The action type code.
        /// </value>
        public string PriorityCode { get; set; }

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public string StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the action type code.
        /// </summary>
        /// <value>
        /// The action type code.
        /// </value>
        public string ActionTypeCode { get; set; }


        /// <summary>
        /// Gets or sets the employee id.(Schedule For.)
        /// </summary>
        /// <value>The employee id.</value>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Emploee name. This field use for viewing only. You don't have to set this field when you use this model to save or update.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the confirmation for event id.
        /// When action type is "call" or "email" and this event is for confirm an appointment. This field will indicate to an appointment event.
        /// </summary>
        /// <value>The confirmation for event id.</value>
        public Guid? ConfirmationForEventId { get; set; }

        /// <summary>
        /// Event Source Code
        /// </summary>
        public string EventSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the opportunity id.
        /// </summary>
        /// <value>The opportunity id.</value>
        public Guid? RegardingId { get; set; }

        /// <summary>
        /// Regarding Detail (for read only)
        /// </summary>
        public string RegardingDetail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is automated process.
        /// </summary>
        /// <value><c>true</c> if this instance is automated process; otherwise, <c>false</c>.</value>
        public bool IsAutomatedProcess { get; set; }

        /// <summary>
        /// Attendee List
        /// </summary>
        private readonly List<KeyValuePair<Guid, string>> _attendeeIdList = new List<KeyValuePair<Guid, string>>();

        /// <summary>
        /// Attendee list
        /// </summary>
        public IList<KeyValuePair<Guid, string>> Attendees
        {
            get { return _attendeeIdList; }
        }
    }
}