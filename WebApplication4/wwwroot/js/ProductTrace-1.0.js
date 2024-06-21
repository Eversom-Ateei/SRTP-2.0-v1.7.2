function ProductTraceSerialBatch(ProductTraceId, docEntry, itemCode, posId,baseQty)
{
    $.ajax({
        data: {

        }, success: function (dados) {
            window.location.href = "../ProductTrace/ProductTraceSerialBatch?ProductTraceId=" + ProductTraceId + "&docEntry=" + docEntry + "&itemCode=" + itemCode + "&posId=" + posId + "&baseQty=" + baseQty;
        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}

function SaveTableProductTraceSerialBatch() {
    try
    {
        var i = 0;
        var count = $("table tbody tr").length;        
        var productTraceId = $("#ProductTraceId").val();
        var itemCode = $("#ItemCode").val();
        var query = "";
        var batchNum = "";
        var baseQty = $("#baseQty").val();
        var quantity = 0;
        var prodTraceSerBatchId = "";
        var user = $("#user").val();
        var pos = $("#pos").val();


        var sumQty = 0;
        while (count > i) {

            batchNum = $("#BatchNum_" + i).val();
            if ($("#Quantity_" + i).val() == "")
            {
                quantity = "0";

            }else
            {
                quantity = $("#Quantity_" + i).val();
            }

            prodTraceSerBatchId = $("#prodTraceSerBatchId_" + i).val();
           
            if (prodTraceSerBatchId == "0")
            {
                if (batchNum != "")
                {
                    query = " INSERT INTO ATEEI_SRTP_PRODUCT_TRACE_BATCH (ID_PRODUCT_TRACE_WO,ItemCode,BatchNum,Quantity,DateAssembly,UserAssembly) VALUES(" + productTraceId + ",'" + itemCode + "','" + batchNum + "'," + quantity.replace(",", ".") + ", getdate(),"+user+") ";
                }
            }
            else
            {


                query = query + " UPDATE ATEEI_SRTP_PRODUCT_TRACE_BATCH SET BatchNum='" + batchNum + "',Quantity = " + quantity.replace(",", ".") + ", DateAssembly=getdate(), UserAssembly=" + user + " WHERE ID =  " + prodTraceSerBatchId + " ";
            }           

            sumQty = parseFloat(sumQty) + parseFloat(quantity);
            
            if (baseQty < sumQty)
            {
                alert("Excedeu a quantidade por Produto!");
                break;
            }
            i++;
        }

        query = query + (" UPDATE ATEEI_SRTP_PRODUCT_TRACE_WO set ItemCode = '" + itemCode + "', UserAssembly = " + user + ", AssemblyRout = " + pos + ", DateAssembly = getdate() where  id = " + productTraceId);


        if (!(baseQty < sumQty)) {
            $.ajax({
                url: "../ProductTrace/SaveTableProductTraceSerialBatch?query=" + query + "",
                type: "post",
                data: {
                    query: query,
                }, success: function (dados) {

                    $("#save").text("Salvo");
                    document.location.reload(true);

                }, beforeSend: function () {
                }
            }).done(function (msg) {
            }).fail(function (jqXHR, textStatus, msg) {
                alert("Error: " + msg);
            });

        } else {

            alert("Ajustar a quantidade dos lotes ou series pra soma ser igual quantidade base do produto!");

        }
    }
    catch (error)
    {
     alert(error);
    }
}
function ChangeItemProdTrace(id,objId) {
    try {

        var itemCode = $("#" + objId).val();



        $.ajax({
            url: "../ProductTrace/ChgItemProdTrace",
            type: "post",
            data: {
                id: id,
                itemCode: itemCode,
            }, success: function (dados) {
               
                if (dados == "true") {
                    document.location.reload(true);
                } else {
                    alert(dados);
                }

            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    } catch (error) {


        alert(error);
    }

}
function LoadDetail(docEntry, serial) {
    try {

        var code = $("#code").val();
       

        $.ajax({
            url: "../ProductTrace/LoadDetail",
            type: "post",
            data: {
                serial: serial,
                docEntry: docEntry,
                code: code,
                
            }, success: function (dados) {


                let text = dados;
                const myArray = text.split("<1;>");

                
                    
                $("#itemCode").val(myArray[0]);
                $("#batchNum").val(myArray[1]);
                $("#quantity").val(myArray[3]);
                $("#position").val(parseInt(myArray[4]).toString());

                

            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    } catch (error) {


        alert(error);
    }



}

function ScanTraceWO(docEntry,serial)
{
    try {

        var itemCode = $("#itemCode").val();
        var batchNum = $("#batchNum").val();
        var quantity = $("#quantity").val();
        var posId = $("#position").val();

        $.ajax({
            url: "../ProductTrace/ScanTraceWO",
            type: "post",
            data: {
                serial : serial,
                docEntry : docEntry,
                itemCode : itemCode,
                batchNum : batchNum,
                quantity: quantity,
                posId: posId,

            }, success: function (dados) {

                if (dados == "true") {
                    document.location.reload(true);
                } else {
                    alert(dados);
                }

            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    } catch (error) {


        alert(error);
    }



}

function AutoTraceBySerial(docEntry, serial) {

    try {
        
        $.ajax({
            url: "../ProductTrace/AutoTraceBySerial",
            type: "post",
            data: {
                serial: serial,
                docEntry: docEntry,              

            }, success: function (dados) {

                    alert(dados);
                

            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    } catch (error) {

        alert(error);
    }

}