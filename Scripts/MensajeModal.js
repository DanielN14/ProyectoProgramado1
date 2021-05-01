function mostrarMensaje(msj) {
    const divModal = document.querySelector('#divModal');

    var modal = "<div class='modal fade' id='myModal' tabindex='-1' aria-labelledby='exampleModalLabel' aria-hidden='true'>" +
        "<div class='modal-dialog modal-dialog-centered modal-sm'>" +
        "<div class='modal-content'>" +
        "<div class='modal-header text-white' style='background-color:#5cb85c;'>" +
        "<h6 class='modal-title' id='exampleModalLabel'>Mensaje del sistema</h6>" +
        "<button type='button' class='close' data-dismiss='modal' aria-label='Close'>" +
        "<span aria-hidden='true'>&times;</span>" +
        "</button>" +
        "</div>" +
        "<div class='modal-body'>" +
        "" + msj + "" +
        "</div>" +
        "<div class='modal-footer'>   " +
        "<button type='button' class='btn btn-success' data-dismiss='modal' style='border-radius: 25px;'>Ok</button>" +
        "</div>" +
        "</div>" +
        "</div>" +
        "</div>";

    divModal.innerHTML = modal;

    $("#myModal").modal('show');
}
function mostrarMensajeConfirmacion(msj) {
    const divModal = document.querySelector('#divModal');

    var modal = "<div class='modal fade' id='myModal' tabindex='-1' aria-labelledby='exampleModalLabel' aria-hidden='true'>" +
        "<div class='modal-dialog modal-dialog-centered modal-sm'>" +
        "<div class='modal-content'>" +
        "<div class='modal-header text-white' style='background-color:#5cb85c;'>" +
        "<h6 class='modal-title' id='exampleModalLabel'>Mensaje del sistema</h6>" +
        "<button type='button' class='close' data-dismiss='modal' aria-label='Close'>" +
        "<span aria-hidden='true'>&times;</span>" +
        "</button>" +
        "</div>" +
        "<div class='modal-body'>" +
        "" + msj + "" +
        "</div>" +
        "<div class='modal-footer'>   " +
        "<button type='button' class='btn btn-success' data-dismiss='modal' style='border-radius: 25px;' onClick=''>Ok</button>" +
        "</div>" +
        "</div>" +
        "</div>" +
        "</div>";

    divModal.innerHTML = modal;

    $("#myModal").modal('show');

    $('#myModal').on('hidden.bs.modal', function () {
        window.location.href = "Libros.aspx";
    })
}