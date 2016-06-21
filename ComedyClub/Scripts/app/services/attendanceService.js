var AttendanceService = function () {
    var createAttendance = function (showId, done, fail) {
        $.post("/api/attendances", { showId: showId })
            .done(done)
            .fail(fail);
    };

    var deleteAttendance = function (showId, done, fail) {
        $.ajax({
            url: "/api/attendances/" + showId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    };

    return {
        createAttendance: createAttendance,
        deleteAttendance: deleteAttendance
    }
}();
