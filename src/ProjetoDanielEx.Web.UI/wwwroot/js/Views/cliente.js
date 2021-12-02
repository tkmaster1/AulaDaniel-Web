/* Arquivo .js que contém todas funções necessárias para a página de Cliente */

$(document).ready(function () {

    $('#dtCliente').DataTable({
               columnDefs: [{ orderable: false, targets: 4 }],        
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Portuguese-Brasil.json",
            "infoEmpty": "No entries to show",
            "sInfo": "Mostrando de _START_ ate _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sPaginationType": "full_numbers",
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

    $(document).on('click', '.btnEditarCliente', function (e) {
        e.preventDefault();
        id = $(this).data('id');

        $("#modalCliente").load("/Cliente/Edit?id=" + id, function () {
            $("#modalCliente").modal('show');
        });
    });
   
    $(document).on('click', '.btnDeleteCliente', function (e) {
        e.preventDefault();
        id = $(this).data('id');
        var nome = $(this).data('nome');

        var msg = "<p class=\"success-message\">Deseja excluir realmente este Cliente: <b>" + nome + "</b>?</p>";
        var codHidden = "<input type=\"hidden\" id=\"hdCodigoCliente\" value=\"" + id + "\"/>";

        $("#dvCodigo").html(codHidden);
        $("#modal-body-Cliente").html(msg);
        $("#modalDeleteCliente").modal('show');

        $('#modalDeleteCliente').on('click', '.delete-confirm', function (e) {
            e.preventDefault();

            $.ajax({
                type: "GET",
                url: '/Cliente/Delete',
                data: { codigo: id },
                success: function (result) {
                    if (result.success) {
                        $("#modalDeleteCliente").modal("hide");
                        bootbox.alert(result.mensagem);
                    } else {
                        $('#modalDeleteCliente').html(result.mensagem);
                    }
                },
                error: function (er) {
                    bootbox.alert(er);
                }
            });
        });
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