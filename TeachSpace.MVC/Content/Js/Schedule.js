//Get The Email List

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


//Get the Topic Name List

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


//Post The Schedule

$('#btnsubmitschedule').click(function () {
    var userid = $('#departmentsDropdown').val();
    var topicid = $('#txttopicname').val();
    
    if (parseInt(userid) > 0 && (parseInt(topicid) > 0)) {    //validating user id and topic id
        console.log(userid)
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
                /*alert("Scheduled")*/
                $("#validation-success").html("<div class='k-messagebox k-messagebox-error'>Schedule Successfully</div>");

            },
            error: function () {

            }
        })
    }
    else {
        /*alert("error");*/
        $("#validation-success").html("<div class='k-messagebox k-messagebox-error'>Schedule Failed</div>");

    }


       
})




//To Display The List of Schedule List Assign for User 

var schedulelist = document.getElementById('TSchedule')
var schedule = document.getElementById('schedulecontent')
var auditlist = document.getElementById('TAudit')


$('#btnschedule').click(function () {
    
    auditlist.classList.remove("show")
    schedulelist.classList.remove("show")
    schedule.classList.remove("hide")

})

//To Display The Schedule for a specific User


$('#btnstudentlist').click(function () {
   
    schedule.classList.add("hide")
    auditlist.classList.remove("show")
    schedulelist.classList.add("show")

    $('#scheduleList').empty();

$('#Load').html("Loading....")
$.get("https://localhost:44372/api/Schedule/GetSchedule", null, Bind);
function Bind(ScheduleList) {
    var SetData = $('#scheduleList');
    for (var i = 0; i < ScheduleList.length; i++) {
        var Data = "<tr class='row_" + ScheduleList[i].ID + "'>" +
           /* "<td>" + ScheduleList[i].ID + "</td>" +*/
            "<td>" + ScheduleList[i].FirstName + "</td>" +
            "<td>" + ScheduleList[i].Email + "</td>" +
            "<td>" + ScheduleList[i].Name + "</td>" +
            "<td>" + ScheduleList[i].Date + "</td>" +
            "<td>" + ScheduleList[i].Time + "</td>" +
            "<td>" + ScheduleList[i].MODE + "</td>" +
            "</tr>";
 
        SetData.append(Data);
        console.log($('#scheduleList tr').length)
            $("#Load").html(" ")  
    }
    }
});


$('#btnauditlist').click(function () {

    schedule.classList.add("hide")
    schedulelist.classList.remove("show")
    auditlist.classList.add("show")

    $('#auditList').empty();
   

    $('#Load').html("Loading....")
    $.get("https://localhost:44372/api/Schedule/GetAudit", null, Bind);
    function Bind(AuditList) {
        var SetData = $('#auditList');
        for (var i = 0; i < AuditList.length; i++) {
            var Data = "<tr class='row_" + AuditList[i].ID + "'>" +
                "<td>" + AuditList[i].FirstName + "</td>" +
                "<td>" + AuditList[i].Operation + "</td>" +
                "<td>" + AuditList[i].TopicName + "</td>" +
                "<td>" + AuditList[i].CreatedDateTime + "</td>" +
                "</tr>";
            SetData.append(Data);
            $("#Load").html(" ")
        }
    }
});


