using System;

namespace PhotoGallery.Models
{
    public class EventModel
    {
        private DateTime _startDate;

        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string DetailsUrl { get; set; }
        public string DateString { get { return _startDate.ToShortDateString(); } }
        public string EventTime { get { return _startDate.ToShortTimeString(); } }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

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

    }
}