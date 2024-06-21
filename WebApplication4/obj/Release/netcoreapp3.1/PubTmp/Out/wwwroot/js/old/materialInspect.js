//const { ajax } = require("jquery");



///MAaterial Inspect
function MaterialInspect(docEntry) {

    $.ajax({
        data: {

        }, success: function (dados) {

            window.location.href = "../QualityControl/MaterialInspect?docEntry=" + docEntry;

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}
///open parameters of materials inspect
function MaterialInspectLines(materialInspectId) {
    $.ajax({
        data: {

        }, success: function (dados) {

            window.location.href = "../QualityControl/MaterialInspectLines?materialInspectId=" + materialInspectId;

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}
function UpdateSampleMaterialInspect(Id) {
   
    var ni = $("#NI_" + Id).val();
    var pas = $("#PAS_" + Id).val();
    var justify = $("#justify_" + Id).val();
    var quantity = $("#quantity_" + Id).val();
    $.ajax(
        {
            url: "../QualityControl/UpdateSampleMaterialInspect",
            type: "get",
            data: {
                ni: ni,
                pas: pas,
                justify: justify,
                materialInspectId: Id,
                quantity: quantity,

            }, success: function (dados) {
                alert(dados);
                document.location.reload(true);
              //  document.location.reload(true);

            }, beforeSend: function () {

            }
        }).done(function (msg) {


        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });

}
function UpdateCommentsMaterialInspect(materialInspectId) {

    var comments = $("#comments_" + materialInspectId).val();

    $.ajax(
        {
            url: "../QualityControl/UpdateCommentsMaterialInspect",
            type: "get",
            data: {
                materialInspectId: materialInspectId,
                comments: comments,


            }, success: function (dados) {
                
                document.location.reload(true);

            }, beforeSend: function () {

            }
        }).done(function (msg) {


        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });

}
function UpdateDueDateMaterialInspect(itemCode, BatchNum, materialInspectId) {
  
    var dueDate = $("#dueDate_" + materialInspectId).val();
   
    $.ajax(
        {
            url: "../QualityControl/UpdateDueDateMaterialInspect",
            type: "get",
            data: {
                materialInspectId : materialInspectId,
                dueDate : dueDate,
                itemCode : itemCode,
                BatchNum : BatchNum,

            }, success: function (dados) {
                alert(dados);

            }, beforeSend: function () {

            }
        }).done(function (msg) {


        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });

}
///update comments by table id
function UpdateCommentsMaterialInspectLines(materialInspectLineId) {

    var comments = $("#comments_" + materialInspectLineId).val();
    $.ajax(
        {
            url: "../QualityControl/UpdateCommentsMaterialInspectLines",
            type: "get",
            data: {
                materialInspectLineId: materialInspectLineId,
                comments: comments,


            }, success: function (dados) {
                document.location.reload(true);

            }, beforeSend: function () {

            }
        }).done(function (msg) {


        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });

}


function UpdateBlockQtyMaterialInspectLines(materialInspectLineId, quantity) {

    var blockQty = $("#blockQty_" + materialInspectLineId).val();
    var status = $("#status_" + materialInspectLineId).val();

    if (blockQty < quantity) {

        status = "Y";

    }
    else {
        if (blockQty == quantity) {

            status = "B"
        }
    }

    $.ajax({
        url: "../QualityControl/UpdateBlockQtyMaterialInspectLines",
        type: "post",
        data: {
            materialInspectLineId: materialInspectLineId,
            blockQty: blockQty,
            status: status,

        }, success: function (dados) {
            document.location.reload(true);

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });

}



function UpdateStatusMaterialInspectLines(materialInspectLineId, quantity) {

    var status = $("#status_" + materialInspectLineId).val();

    var urlAtual = window.location.href;
    var urlClass = new URL(urlAtual);
    var materialInspectId = urlClass.searchParams.get("materialInspectId");

    $.ajax({
        url: "../QualityControl/UpdateStatusMaterialInspectLines",
        type: "post",
        data: {
            materialInspectLineId: materialInspectLineId,
            status: status,
            materialInspectId: materialInspectId,
            quantity: quantity,

        }, success: function (dados) {

            document.location.reload(true);
        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });

}

function UpdateReasonMaterialInspectLines(materialInspectLineId) {

    var reason = $("#reason_" + materialInspectLineId).val();

    $.ajax({
        url: "../QualityControl/UpdateReasonMaterialInspectLines",
        type: "post",
        data: {
            materialInspectLineId: materialInspectLineId,
            reason: reason,

        }, success: function (dados) {

            document.location.reload(true);
        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });

}

function UpdateMeasurementMaterialInspectLines(materialInspectLineId) {

    var measurement = $("#measurement_" + materialInspectLineId).val();

    $.ajax({
        url: "../QualityControl/UpdateMeasurementMaterialInspectLines",
        type: "post",
        data: {
            materialInspectLineId: materialInspectLineId,
            measurement: measurement,

        }, success: function (dados) {

            document.location.reload(true);
        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });

}


function SaveTableMaterialInspectLines() {

    var i = 0;
    var count = $("#count").val();
    var query = "";
    var materialInspectId;
    while (i < count) {
        var minimun = $("#minimun_" + i).val();
        var maximun = $("#maximun_" + i).val();
        var mark = $("#mark_" + i).val();
        var quantity = $("#quantity_" + i).val();
        var measurement = $("#measurement_" + i).val();
        var comments = $("#comments_" + i).val();
        var blockQty = $("#blockQty_" + i).val();
        var status = $("#status_" + i).val();
        var tool = $("#toolCod_" + i).val();
        var reason = $("#reason_" + i).val();
        var materialInspectLineId = $("#materialInspectLinesId_" + i).val();
        materialInspectId = $("#materialInspectId_" + i).val();
        var statusOld = $("#statusOld_" + i).val();

        if (status == "Y" || status == "B") {

            if ((status == "Y" && statusOld == "B") || (status == "B" && statusOld == "Y"))
            {

                query = query + "  " + "UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO SET MOTIVO_STATUS = '" + reason + "' , OBS='" + comments + "', measurement = '" + measurement + "', QUANTIDADE_BLOQUEADA =" + blockQty.replace(",", ".") + " , APROVADO = '" + status + "', USUARIO={USER}, DATA=GETDATE() , ToolCod = '" + tool + "', Minimun = '" + minimun + "', Maximun = '" + maximun + "' ,Mark = '" + mark + "' WHERE ID = " + materialInspectLineId + "" ;

            }
            else
            {           
                if (statusOld == "N")
                {

                    query = query + "  " + "UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO SET MOTIVO_STATUS = '" + reason + "' , OBS='" + comments + "', measurement = '" + measurement + "', QUANTIDADE_BLOQUEADA =" + blockQty.replace(",", ".") + " , APROVADO = '" + status + "', USUARIO={USER}, DATA=GETDATE(), ToolCod = '" + tool + "', Minimun = '" + minimun + "', Maximun = '" + maximun + "' ,Mark = '" + mark + "' WHERE ID = " + materialInspectLineId + "";
                                       
                }
                else
                {
                    query = query + "  " + "UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO SET MOTIVO_STATUS = '" + reason + "' , OBS='" + comments + "', measurement = '" + measurement + "', QUANTIDADE_BLOQUEADA =" + blockQty.replace(",", ".") + " , APROVADO = '" + status + "', ToolCod = '" + tool + "', Minimun = '" + minimun + "', Maximun = '" + maximun + "' ,Mark = '" + mark + "' WHERE ID = " + materialInspectLineId + "";

                }
            }
        }
        else
        {

                query = query + "  " + "UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO SET MOTIVO_STATUS = '" + reason + "' , OBS='" + comments + "', measurement = '" + measurement + "', QUANTIDADE_BLOQUEADA =" + blockQty.replace(",", ".") + " , APROVADO = '" + status + "' , ToolCod = '" + tool + "', Minimun = '" + minimun + "', Maximun = '" + maximun + "' ,Mark = '" + mark + "' WHERE ID = " + materialInspectLineId + "" ;

        }
        i++;
    }

    $.ajax({
        url: "../QualityControl/SaveTableMaterialInspectLines",
        type: "post",
        data: {
            query: query,
            materialInspectId: materialInspectId,
        }, success: function (dados) {
            
            $("#save").text("Salvo");
            document.location.reload(true);

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });




}

function ChangeforStatusMaterialInspectLines(i)
{

    var quantity = $("#quantity_" + i).val();
    var measurement = $("#measurement_" + i).val();
    var comments = $("#comments_" + i).val();
    var blockQty = $("#blockQty_" + i).val();
    var status = $("#status_" + i).val();
    var statusOld = $("#statusOld_" + i).val();

    
    $.ajax({
        url: "../QualityControl/VerifyUserFunction",
        type: "post",
        data: {

        }, success: function (dados) {
           
            if (status == "Y" && statusOld == "B" && dados == "M")
            {
                alert("É necessario a liberação de um Lider da Qualidade!")
                $("#status_" + i).val(statusOld);
            }
            else {
                if (status == "Y") {

                    $("#blockQty_" + i).val(0);

                } else {
                    if (status == "B") {
                        $("#blockQty_" + i).val(quantity.replace(",", "."));

                    } else {
                        if (status == "N") {
                            $("#blockQty_" + i).val(0);
                            $("#measurement_" + i).val("");
                            $("#comments_" + i).val("");
                        }
                    }
                }
            }



        }, beforeSend: function () {

        }
    }).done(function (msg) {



    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
   


}


function ValidateFieldMaxRange(id, maxRange, sampleRange) {

    var vl = $("#" + id).val();
  
    vl = vl.replace(",", ".");
    if (isNaN(vl)) {
        $("#" + id).val(0);
    } else {

        if ($("#" + id).val() > maxRange) {

            alert("O Range máximo é " + maxRange)

            $("#" + id).val(0);


        }

        else {
            if ($("#" + id).val() >= sampleRange) {

                alert("O numero de bloqueio é maior ou igual que o numero de amostra! O lote pode estar comprometido! " )

            }

        }
    }
}