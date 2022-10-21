$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: 'https://localhost:44372/api/Schedule/GetUsersEmail',
        data: "{}",
        success: function (data) {
            let s = '<option value="-1">Please Select an Email</option>';
            for (let i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].UserID + '">' + data[i].UserEmail + '</option>';
            }
            $("#departmentsDropdown").html(s);
        }
    });
});

$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: 'https://localhost:44372/api/Schedule/GetTopicName',
        data: "{}",
        success: function (data) {
            let t = '<option value="-1">Please Select a Topic</option>';
            for (let i = 0; i < data.length; i++) {
                t += '<option value="' + data[i].TopicID + '">' + data[i].TopicName + '</option>';
            }
            $("#txttopicname").html(t);
        }
    });
});

$('#btnschedule').click(function () {
    $.ajax({
        url: 'https://localhost:44372/api/Schedule/AddSchedule',
        method: "POST",
        data: {
            UserID: $('#departmentsDropdown').val(),
            TopicID: $('#txttopicname').val(),
            Date: $('#txtdate').val(),
            Time: $('#txttime').val(),
            Mode: $('#txtmode').val()

        },
        success: function () {
            alert("Scheduled")

        },
        error: function () {
        }
    })
})



$('#btnstudentlist').click(function () {

    $('#Load').html("Loading....")
    $.get("https://localhost:44372/api/Schedule/GetSchedule", null, Bind);
    function Bind(AppointmentList) {
        var SetData = $('#scheduleList');
        for (var i = 0; i < AppointmentList.length; i++) {
            var Data = "<tr class='row_" + AppointmentList[i].ID + "'>" +
                "<td>" + AppointmentList[i].ID + "</td>" +
                "<td>" + AppointmentList[i].FirstName + "</td>" +
                "<td>" + AppointmentList[i].Email + "</td>" +
                "<td>" + AppointmentList[i].Name + "</td>" +
                "<td>" + AppointmentList[i].Date + "</td>" +
                "<td>" + AppointmentList[i].Time + "</td>" +
                "<td>" + AppointmentList[i].MODE + "</td>" +
                
                //"<td>" + "<a href='#' class='btn btn-warning' onclick='EditStyleList(" + StyleList[i].ID + ")'><span class='glyphicon glyphicon-edit'></span></a>" + "</td>" +
                //"<td>" + "<a href='#'' class='btn btn-danger' onclick='DeleteStyleList(" + StyleList[i].ID + ")'><span class='glyphicon glyphicon-trash'></span></a>" + "</td>"
                "</tr>";



            SetData.append(Data);
            $("#Load").html(" ")
        }



    }
});

//$('#btnplaceorder').click(function () {
//    $.ajax({
//        url: 'https://localhost:44372/api/Schedule/CheckEmail',
//        method: "POST",
//        data: {
//            ID: $('#departmentsDropdown').val()
            
            
//        },
//        success: function () {
//            alert("booked")

//        },
//        error: function () {
//        }
//    })
//})
//$('#btnplaceorder').click(function () {
//    $.ajax({
//        url: 'https://localhost:44372/api/Schedule/CheckEmail',
//        method: "POST",
//        data: {
//            ID: $('#departmentsDropdown').val()


//        },
//        success: function () {
//            alert("booked")

//        },
//        error: function () {
//        }
//    })
//})