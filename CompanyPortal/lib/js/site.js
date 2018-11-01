
function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
    
}

function isName(user) {
    
    var regex = /^[A-Za-z ]+$/;
    return regex.test(user);
}


function isPassword(pass) {
    var regex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*])[0-9a-zA-Z!@#$%^&*]{8,}$/;
    return regex.test(pass);
}

function capitalizeFirstLetter(name) {
   
    return name.charAt(0).toUpperCase() + name.slice(1).toLowerCase();
}

function InitializeAddTeamConfirmDialog(formdata) {
    var dialog = $('<div id="msg_dialog" title="Add Team Members"> Do you want to add Team Members? </div>');
    dialog.dialog({
        modal: true,
        autoOpen: true,
        resizable: false,
        open: function () {
            debugger
        /*    $(this).closest(".ui-dialog")
                .find(".ui-dialog-titlebar-close")
                .removeClass("ui-dialog-titlebar-close")
                .html("<span class='ui-button-icon-primary ui-icon ui-icon-closethick'></span>");
       */ },
        buttons: [
            {
                text: 'Later',
                click: function () {
                    debugger
                    //  $('#res').empty().append('<h1>Open<h1>');
                    $('#msg_dialog').remove();
                //    $('#msg_dialog').dialog('close');
                    SaveDataProjectIntoDatabase(formdata);
                }
            },
            {
                text: 'Yes',
                click: function () {
                    debugger
                    // 4 $('#res').empty().append('<h1>Close<h1>');
                 //   $('#msg_dialog').dialog('close');
                    $('#msg_dialog').remove();
                    openAddTeamDialog(formdata);
                    res = false;
                }
            }
        ]
    });


    dialog.dialog("open");
    return false;
}


function openAddTeamDialog(formdata)
{
    var Pid;
    var addteam = $("#addteamDialog");
    if (isNaN(formdata)) {
        Pid = formdata.PId;
    }
    else {
        Pid=formdata
    }
    addteam.dialog({
        modal: true,
        autoOpen: true,
        title: "Add team",
        width: "600px",
        top: "150px",
        open: function () {
            debugger
            $(this).load("/LoggedIn/AddTeam?PId=" + Pid, formdata);

        }
    });

    addteam.show();
    addteam.dialog('open');

}