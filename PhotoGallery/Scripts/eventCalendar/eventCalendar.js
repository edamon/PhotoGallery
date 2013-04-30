
var EventCalendar = EventCalendar || {};

(function ($, backbone, handlebars, moment) {
    var getDateObjectJsonDate = function (jsonDate) {
        var dateString = jsonDate.replace("/Date(", ""),
            dateUtcTime = dateString.replace(")/", ""),
            dateObject = new Date(parseInt(dateUtcTime, 10));

        return dateObject;
    };

    EventCalendar.MonthCalendarModel = backbone.Model.extend({
        urlRoot: '/Event/EventCalendar'
    });

    EventCalendar.CalendarView = backbone.View.extend({
        events: {
            'click a': 'changeMonth'
        },
        initialize: function () {
            var self = this,
                date = new Date();

            self.template = handlebars.compile($('#eventCalendar').html());
            self.model = new EventCalendar.MonthCalendarModel();
            self.getCalendar(date.getMonth(), date.getFullYear());

            return self;
        },
        render: function () {
            var self = this;

            self.$el.empty().html(self.template(self.model.toJSON()));
            
            $(".day").equalHeights();

            return self;
        },
        changeMonth: function (e) {
            var self = this,
                direction = $(e.srcElement).attr('direction'),
                date;
            
            if (direction === 'previous') {
                date = getDateObjectJsonDate(self.model.get('PreviousMonth'));
            } else {
                date = getDateObjectJsonDate(self.model.get('NextMonth'));
            }

            self.getCalendar(date.getMonth(), date.getFullYear());

            return self;
        },
        getCalendar: function (month, year) {
            var self = this,
                currentDate,
                nextMonthDate,
                previousMonthDate;

            self.model.id = new Date(year, month, 1).toDateString();

            self.model.fetch({
                success: function (model) {
                    currentDate = new moment(getDateObjectJsonDate(model.get('CurrentMonth')));
                    nextMonthDate = new moment(getDateObjectJsonDate(model.get('NextMonth')));
                    previousMonthDate = new moment(getDateObjectJsonDate(model.get('PreviousMonth')));

                    model.set({
                        PreviousMonthString: previousMonthDate.format('MMMM'),
                        NextMonthString: nextMonthDate.format('MMMM'),
                        CurrentMonthString: currentDate.format('MMMM'),
                        CurrentYearString: currentDate.format('YYYY')
                    });
                    
                    self.render();
                }
            });            

            return self;
        }
    });

    $.fn.calendarInit = function () {        
        var self = this,
            calendarView = new EventCalendar.CalendarView({
               el: $(self)
            });

        return self;
    };
}(jQuery, Backbone, Handlebars, moment));