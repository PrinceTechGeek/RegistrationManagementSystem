$(document).ready(function () {
    $("form").validate({
        rules: {
            EventName: "required",
            ParticipantName: "required",
            EmailAddress: {
                required: true,
                email: true
            },
            NumberOfTickets: {
                required: true,
                digits: true,
                min: 1
            }
        },
        messages: {
            EventName: "Please enter event name",
            ParticipantName: "Please enter participant name",
            EmailAddress: "Please enter a valid email address",
            NumberOfTickets: "Please enter a valid number of tickets"
        }
    });
});
