var username ="admin";
var password="admin";
var massage = document.getElementById("error"); 

function check()
{ 
    var getUsername = document.getElementById("username").value;
    var getPassword = document.getElementById("password").value;


    if(getUsername == username && getPassword == password){
        window.location.href="Homepage.html";
        return false;
    }
    else{
        massage.textContent ="Invalid Username Or Password";
        return false;
    }

}