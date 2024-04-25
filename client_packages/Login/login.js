function InvalidUserPass(){
    $("#alertText").text("Usuario o Contraseña invalida")
}

$(document).ready(function(){
    $("#loginButton").click(function(){
        if($("#userText").val()==''){
            $("#alertUser").text("El usuario no puede estar vacio");
        }
        if($("#passwordText").val()==''){
            $("#alertPass").text("La contraseña no puede estar vacia");
        }
        else{
            mp.trigger("LoginInfoClient",$("#userText").val(),$("#passwordText").val());
        }
    })
})