
var studentlist = document.getElementById('Ilist')
$('#btnstudentlist').click(function () { 
    
    if ($('#Ilist').css('display') == 'none') {
        studentlist.classList.add("show")
    }
    else {
        studentlist.classList.remove("show")
    }
  
    
});
$('#btneventlist').click(function () {
    

});

$('#Load').html("Loading....")
$.get("https://localhost:44372/api/Schedule/GetUserSchedule", null, find);
function find(AppointmentList) {
    var SetData = $('#scheduleList');
    for (var i = 0; i < AppointmentList.length; i++) {
        var Data = "<tr class='row_" + AppointmentList[i].ID + "'>" +
            "<td>" + AppointmentList[i].FirstName + "</td>" +
            "<td>" + AppointmentList[i].Email + "</td>" +
            "<td>" + AppointmentList[i].Name + "</td>" +
            "<td>" + AppointmentList[i].Date + "</td>" +
            "<td>" + AppointmentList[i].Time + "</td>" +
            "<td>" + AppointmentList[i].MODE + "</td>" +
            "</tr>";
        SetData.append(Data);
        $("#Load").html(" ")
    }



}
