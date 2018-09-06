
function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
    
}

function isName(user) {
    debugger
    var regex = /^[A-Za-z ]+$/;
    return regex.test(user);
}


function isPassword(pass) {
    var regex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*])[0-9a-zA-Z!@#$%^&*]{8,}$/;
    return regex.test(pass);
}

function capitalizeFirstLetter(name) {
    debugger
    return name.charAt(0).toUpperCase() + name.slice(1);
}