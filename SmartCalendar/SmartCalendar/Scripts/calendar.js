$('#calendar').fullCalendar({
    header:{
        left: 'prev,next,today',
        center: 'title',
        right: 'month, agendaWeek, agendaDay'
    },
    editable: true,
    allDaySlot: false,
    selectable: true,
    events: function (start, end, callback) {
        $.ajax({
            url: '/api/event/',
            dataType: 'json',
            data: {
                start: start.getTime()/1000,
                end: end.getTime() / 1000
            },
            success: function (doc) {
                var events = [];
                $(doc).each(function () {
                    events.push({
                        id: $(this).attr('Id'),
                        title: $(this).attr('Title'),
                        start: $(this).attr('DateStart'),
                        end: $(this).attr('DateEnd'),
                        description: $(this).attr('Description'),
                        location: $(this).attr('Location'),
                        category: $(this).attr('Category'),
                        allDay: false
                        
                    });                    
                });
                callback(events);
            }            
        });
    },
    eventClick: function (calEvent, jsEvent, view) {
        alert('Event: ' + calEvent.title);
    }
});