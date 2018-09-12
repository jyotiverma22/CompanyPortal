function helo() {
    Console.log("hello");
}
var c = 0;
function navbarHeight() {
    if (c == 0) {

        document.getElementById("header").style.height = '300px';
        c = 1;
    }
    
    else {
        document.getElementById("header").style.height = '80px';

        c = 0;
        }

   
   
}