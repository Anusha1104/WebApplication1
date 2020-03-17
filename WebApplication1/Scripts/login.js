function Validate() {
    var username = document.getElementById("txtuserid").value;
    var pwd = document.getElementById("txtpwd").value;
    if (username.length == 0 || pwd.length == 0) {
        alert("Enter username/password");
        //document.getElementById("lblmessage").innerHTML = "Enter username/password";
        return false;
    }
    esle
    return true;

}