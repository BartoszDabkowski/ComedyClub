
var ShowsController = function (attendanceService) {
    var button;

    var init = function (container) {
        $(container).on("click", ".js-toggle-attendance", toggleAttendance);
    };

    var toggleAttendance = function (e) {
        button = $(e.target);

        var showId = button.attr("data-newShow-id");

        if (button.hasClass("btn-default"))
            attendanceService.createAttendance(showId, done, fail);
        else
            attendanceService.deleteAttendance(showId, done, fail);
    };

    var done = function () {
        var text = (button.text() === "Going") ? "Going ?" : "Going";

        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    var fail = function () {
        alert("Something Failed!");
    };

    return {
        init: init
    }
}(AttendanceService);

