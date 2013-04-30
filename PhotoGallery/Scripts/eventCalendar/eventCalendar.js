
EventCalendar = EventCalendar || {};

(function ($, backbone, handlebars) {
    EventCalendar.MonthCalendarModel = backbone.Model.extend({
        url: '/Event/EventCalendar'        
    });

    EventCalendar.CalendarView = backbone.View.extend({
        events: {
            
        },
        initialize: function () {
            var self = this;

            self.template = handlebars.compile('../eventCalendar.html');

            self.model = new EventCalendar.MonthCalendarModel();
            self.model.bind('change', self.render);
            self.model.idAttribute = new Date().toDateString();
            self.model.fetch();

            return self;
        },
        render: function () {
            var self = this;

            self.$el.empty().html(self.template.render(self.model.toJSON()));

            return self;
        }
    });
}(jQuery, Backbone, Handlebars));