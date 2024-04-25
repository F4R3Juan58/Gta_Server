function UpdateVida(percentage) {
  console.log("Recibido evento 'UpdateVida' con porcentaje:", percentage);
  $("#health-bar").css("background-image", "linear-gradient(to top, rgba(255, 0, 0, 1) " + percentage + "%, transparent 0%)");
  $("#health-bar").text(percentage);
}

function UpdateArmadura(percentage) {
  console.log("Recibido evento 'UpdateArmadura' con porcentaje:", percentage);
  $("#armor-bar").css("background-image", "linear-gradient(to top, #00f " + percentage + "%, transparent 0%)");
  $("#armor-bar").text(percentage);
}

function UpdateComida(percentage) {
  console.log("Recibido evento 'UpdateComida' con porcentaje:", percentage);
  $("#food-bar").css("background-image", "linear-gradient(to top, #0f0 " + percentage + "%, transparent 0%)");
  $("#food-bar").text(percentage);
}

function UpdateBebida(percentage) {
  console.log("Recibido evento 'UpdateBebida' con porcentaje:", percentage);
  $("#drink-bar").css("background-image", "linear-gradient(to top, #ff0 " + percentage + "%, transparent 0%)");
  $("#drink-bar").text(percentage);
}

$(document).ready(function(){
  mp.trigger("ProgressBar",$("#health-bar").val(),$("#armor-bar").val(),$("#drink-bar").val(),$("#food-bar").val());
})

