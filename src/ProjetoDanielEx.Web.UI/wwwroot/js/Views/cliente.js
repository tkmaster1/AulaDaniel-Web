/* Arquivo .js que contém todas funções necessárias para a página de Categoria */

$(document).ready(function myfunction() {
    $('#dtCliente').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Portuguese-Brasil.json",
            "infoEmpty": "No entries to show"
        }
    });

    $('#btnCreateCliente').on('click', function () {
        $("#modalCliente").load("/Cliente/Create", function () {
            $("#modalCliente").modal('show');
        });
    });

    $('#btnRefreshCliente').on('click', function (e) {
        e.preventDefault();
        loadData();
    });
});

function loadData() {
    //Ajax Function to send a get request
    $.ajax({
        type: "Get",
        url: "/Cliente/Index",
        crossDomain: true,
        cache: false,
        success: function () {
            window.location = window.location;
        },
        error: function (er) {
            bootbox.alert(er);
        }
    });
}