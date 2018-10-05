
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

function InitializeAddTeamDialog(formdata) {
    var dialog = $('<div id="msg_dialog"> </div>').dialog();
    dialog.dialog({
        modal: true,
        autoOpen: true,
        title: 'Add Team?',
        open: function () {
            var markup = 'Do you want to add Add Project Team Now?';
            dialog.appnedTo('body').html(markup);
        },
        buttons: [
            {
                text: 'Later',
                click: function () {
                    debugger
                    //  $('#res').empty().append('<h1>Open<h1>');
                    $('#msg_dialog').remove();
                    SaveDataProjectIntoDatabase(formdata);
                }
            },
            {
                text: 'Yes',
                click: function () {
                    debugger
                    //                          $('#res').empty().append('<h1>Close<h1>');
                    $('#msg_dialog').remove();

                    res = false;
                }
            }
        ]
    });


    dialog.dialog("open");

}


