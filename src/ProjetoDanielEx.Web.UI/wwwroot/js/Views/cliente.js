/* Arquivo .js que contém todas funções necessárias para a página de Cliente */

$(document).ready(function myfunction() {

    // $('#TipoPessoa').select2();

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

    $(document).on('click', '.btnEditarCliente', function (e) {
        e.preventDefault();
        id = $(this).data('id');

        $("#modalCliente").load("/Cliente/Edit?id=" + id, function () {
            $("#modalCliente").modal('show');
        });
    });

    //$("input[id*='Documento']").inputmask({
    //    mask: ['999.999.999-99', '99.999.999/9999-99'],
    //    keepStatic: true
    //});

    $(document).on('click', '.btnDeleteCliente', function (e) {
        e.preventDefault();
        id = $(this).data('id');
        var nome = $(this).data('nome');

        var msg = "<p class=\"success-message\">Deseja excluir realmente este Cliente: <b>" + nome + "</b>?</p>";
        var codHidden = "<input type=\"hidden\" id=\"hdCodigoCliente\" value=\"" + id + "\"/>";

        $("#dvCodigo").html(codHidden);
        $("#modal-body-Cliente").html(msg);
        $("#modalDeleteCliente").modal('show');

        //$('#modalDeleteCliente').on('click', '.delete-confirm', function (e) {
        //    //Ajax Function to send a get request
        //    $.ajax({
        //        type: "POST",
        //        url: '/Cliente/DeleteConfirmed',
        //        dataType: 'json',
        //        data: JSON.stringify({ objExcluirCliente: id }),
        //        processData: false,
        //        contentType: "application/json; charset=utf-8",
        //        cache: false,
        //        async: false,
        //        success: function () {
        //            debugger;
        //            $("#modalDeleteCliente").modal('hide');
        //            bootbox.alert("Cliente excluídO com sucesso!");
        //        },
        //        error: function (er) {
        //            bootbox.alert(er);
        //        }
        //    });
        //});

    });

});

function fnExcluirCliente() {

    debugger;

    var codigo = $("#hdCodigoCliente").val();
    var objExcluirCliente = {
        "Codigo": codigo
    }

    var formData = new FormData();
    formData.append('objExcluirCliente', JSON.stringify(objExcluirCliente));

   // console.log(formData);
    var url = "/Cliente/DeleteConfirmed";

    $.ajax({
        type: 'POST',
        url: url,
        data: { country: "2", amount: "4.02" },
        dataType: "json",
        contentType: "application/json",
        traditional: true,
        success: function (data) {
            alert("hiiii" + data);
        }
    });

    //$.ajax({
    //    type: "POST",
    //    url: url,
    //    dataType: 'json',
    //    data: formData,
    //    processData: false,
    //    contentType: false,
    //    success: function () {
    //        debugger;
    //        $("#modalDeleteCliente").modal('hide');
    //        bootbox.alert("Cliente excluído com sucesso!");
    //    },
    //    error: function (er) {
    //        debugger;
    //        console.log(er);
    //        bootbox.alert(er);
    //    }
    //});
}

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