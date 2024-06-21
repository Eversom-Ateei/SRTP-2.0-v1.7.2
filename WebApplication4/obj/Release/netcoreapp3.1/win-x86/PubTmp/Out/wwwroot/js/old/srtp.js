

////Login








function getHostSite() {
    //identificar inicio do path
    //usada nas chamadas Ajax / jSON
    var Path = location.host;
    var VirtualDirectory;
    if (Path.indexOf("localhost") >= 0 && Path.indexOf(":") >= 0) {
        VirtualDirectory = "";
    }
    else {
        var pathname = window.location.pathname;
        var VirtualDir = pathname.split('/');
        VirtualDirectory = VirtualDir[1];
        VirtualDirectory = '/' + VirtualDirectory;
    }
    return location.protocol + "//" + location.host + VirtualDirectory + "/"
}

function Logout() {

    if (confirm("Desconectar-se?") == true) {
        $.ajax({
            url: getHostSite() + "Login/Logout",
            type: "post",
            data: {

            }, success: function (dados) {

                document.location.reload(true);

            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    }
}

function Login() {
    var id = $('#id').val();
    $.ajax({
        url: getHostSite() +"Login/Login",
        type: "post",
        data: {
            id: id,

        }, success: function (dados) {

            document.location.reload(true);

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}

function StartChat(user) {

    if (confirm("Iniciar?") == true) {
        $.ajax({
            url: getHostSite() + "Login/ChatView",
            type: "post",
            data: {
                user : user,
            }, success: function (dados) {
                window.location.href = "../home/chat?to=" + user + "&from=" + dados;

                

            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    }
}


////validação 
function ValidateFieldDouble(id) {

    var vl = $("#" + id).val();
    vl = vl.replace(",", ".");
    if (isNaN(vl)) {
        $("#" + id).val(0);
    }
}




function ChangeStatusByBlockQty(id, key, maxRange) {

    var vl = $("#" + id).val();
    vl = vl.replace(",", ".");
    if (isNaN(vl)) {
        $("#" + id).val(0);
    } else {
        if ($("#" + id).val() >= maxRange) {

            $("#" + key).val("B").change();

        }
        if ($("#" + id).val() < maxRange) {

            $("#" + key).val("Y").change();
        }

    }
       
}

///////ordens
function OpenTimeRegister(usercode, docEntry, resource, sequence, posId) {

    if (window.confirm("Abrir Registro de Tempo?")) {

        $.ajax({
            url: "../Orders/OpenTimeRegister",
            type: "get",
            data: {
                usercode: usercode,
                docEntry: docEntry,
                resource: resource,
                sequence: sequence,
                posId: posId,
            }, success: function (dados) {

                alert(dados);
                window.location.href = "../Orders/OrdersOn";

            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    }
}


function TimeRegisters(docEntry, sequence, posId)
{
    $.ajax({
        url: "../Orders/TimeRegisters",
        type: "post",
        data: {
            docEntry: docEntry,
            sequence: sequence,
            posId: posId,
        }, success: function (dados) {

            
            $("#timeReg").html(dados);
            $("#linkTimeReg").click();
            


        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}



function VerifyCloseTimeRegister(timeRegisterID) {

    quantity = $("#quantity_" + timeRegisterID).val();
  
    $.ajax({
        url: "../Orders/CloseTimeRegisterCondiction",
        type: "post",
        data: {
            timeRegisterID: timeRegisterID,
            quantity: quantity,

        }, success: function (dados) {
                     
            if (dados == "true") {

                CloseTimeRegister(timeRegisterID, quantity);

            } else {


                window.location.href = dados;
                
            }

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });

}

function CloseTimeRegister(timeRegisterID, quantity) {

    if (window.confirm("Fechar o Registro de Tempo ?")) {

        $.ajax({
            url: "../Orders/CloseTimeRegister",
            type: "get",
            data: {
                timeRegisterID: timeRegisterID,
                quantity: quantity,

            }, success: function (dados) {

                alert(dados);
                document.location.reload(true);

            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    }
}


function OnlineInspectLines(id) {
    $.ajax({
        url: "../QualityControl/OnlineInspectLines",
        type: "get",
        data: {
            id: id,

        }, success: function (dados) {


            window.location.href = "../QualityControl/OnlineInspectLines?id=" + id;
        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}


function ProductionSetup(docEntry, resource, sequence) {

    $.ajax({
        data: {
            docEntry: docEntry,
            resource: resource,
            sequence: sequence,

        }, success: function (dados) {


            window.location.href = "../ProductionSetup/ProductionSetup?docEntry=" + docEntry + "&resource=" + resource + "&sequence=" + sequence;

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}

function ProductionSetupLine(id) {
    $.ajax({
        data: {

        }, success: function (dados) {


            window.location.href = "../ProductionSetup/ProductionSetupLine?id=" + id;

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}

function AssemblyWorkOrder(serialNumberId) {

    $.ajax({
        data: {

        }, success: function (dados) {


            window.location.href = "../ProductionSetup/AssemblyWorkOrder?serialNumberId=" + serialNumberId;

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}



function AssemblyWorkOrderParameters(id) {

    $.ajax({
        url: "../ProductionSetup/AssemblyWorkOrderParameters",
        type: "get",
        data: {
            id: id,

        }, success: function (dados) {
            
            $("#" + id).html(dados);
            /// window.location.href = "../ProductionSetup/AssemblyWorkOrderParameters?id=" + id;

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}


function ProductInspectLines(timeRegisterID) {

    $.ajax({
        data: {

        }, success: function (dados) {


            window.location.href = "../QualityControl/ProductInspectLines?timeRegisterID=" + timeRegisterID;
        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}

function ProductInspectByTimeRegister(timeRegisterID) {
    $.ajax({
        data: {

        }, success: function (dados) {


            window.location.href = "../QualityControl/ProductInspectByTimeRegister?timeRegisterID=" + timeRegisterID;
        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });

}


function StatusButton(id, value) {

    // document.getElementById(id).innerText = value;

    $("#save").prop("disabled", false);

    $("#table").css("background-color", "#E3E3E3");

}

/////product inspect

function SaveTableProductInspectLines() {

    var i = 0;
    var count = $("#count").val();
    var query = "";
    var productInspectId;
    while (i < count)
    {
        var quantity = $("#quantity_" + i).val();
        var measurement = $("#measurement_" + i).val();
        var comments = $("#comments_" + i).val();
        var blockQty = $("#blockQty_" + i).val();
        var status = $("#status_" + i).val();
        var statusOld = $("#statusOld_" + i).val();
        var reason = $("#reason_" + i).val();
        var productInspectLinesId = $("#productInspectLinesId_" + i).val();
        productInspectId = $("#productInspectId_" + i).val();

        if (status == "Y" || status == "B") {

            query = query + "  " + "UPDATE ATEEI_SRTP_PLACAS_INSPECIONADAS_PARAMETRO SET MOTIVO_STATUS = '" + reason + "' , OBS='" + comments + "', measurement = '" + measurement + "', QUANTIDADE_BLOQUEADA =" + blockQty.replace(",", ".") + " , APROVADO = '" + status + "', USUARIO={USER}, DATA=GETDATE()  WHERE ID = " + productInspectLinesId + "";

        }
        else {

            query = query + "  " + "UPDATE ATEEI_SRTP_PLACAS_INSPECIONADAS_PARAMETRO SET MOTIVO_STATUS = '" + reason + "' , OBS='" + comments + "', measurement = '" + measurement + "', QUANTIDADE_BLOQUEADA =" + blockQty.replace(",", ".") + " , APROVADO = '" + status + "'  WHERE ID = " + productInspectLinesId + "";
        }

        i++;
    }


    $.ajax({

        url: "../QualityControl/SaveTableProductInspectLines",
        type: "post",
        data:
        {
            query: query,
            productInspectId: productInspectId,
        }, success: function (dados)
        {
            $("#save").text("Salvo");
            document.location.reload(true);

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });


}


function ChangeforStatusProductInspectLines(i) {

    var quantity = $("#quantity_" + i).val();
    var measurement = $("#measurement_" + i).val();
    var comments = $("#comments_" + i).val();
    var blockQty = $("#blockQty_" + i).val();
    var status = $("#status_" + i).val();


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

function AddSerialSetup() {

    var urlAtual = window.location.href;
    var urlClass = new URL(urlAtual);
    var idSetup = urlClass.searchParams.get("id");
    var serial = $("#serial").val();

    if (serial != "") {

        $.ajax({
            url: "../ProductionSetup/AddSerialSetup",
            type: "post",
            data: {
                idSetup: idSetup,
                serial: serial,

            }, success: function (dados) {

                alert(dados);

            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    }
}

function DeleteSerialSetup(id) {
    alert();
    $.ajax({
        url: "../ProductionSetup/DeleteSerialSetup",
        type: "post",
        data: {
            id: id,

        }, success: function (dados) {

            alert(dados);

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}


function DeleteSerialRout(id) {
    if(confirm("Excluir o serial da Rota?")){
        $.ajax({
            url: "../Orders/DeleteSerialRout",
            type: "post",
            data: {
                id: id,

            }, success: function (dados) {

                alert(dados);

            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    }
}

function SaveAWOMeasurementParameters(id){

    var measurement = $("#measurement" + id).val();

    $.ajax({
        url: "../ProductionSetup/SaveAWOMeasurementParameters",
        type: "post",
        data: {
            id: id,
            measurement: measurement,

        }, success: function (dados) {


        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}

function SaveAWOStatusParameters(id) {
    var status = "";
    if ($("#status" + id).prop("checked")) {
        status = "Y";

    } else {

        status = "N";

    }
    $.ajax({
        url: "../ProductionSetup/SaveAWOStatusParameters",
        type: "post",
        data: {
            id: id,
            status: status,

        }, success: function (dados) {


        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });

}

function RoutersView() {

    $.ajax({
        url: "../Orders/RoutersView",
        type: "post",
        data: {

        }, success: function (dados) {
         


            $("table tBody").html(dados);

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });


}

function ScannerSerialOnRout(docEntry,sequence,posId,idRgSetup,timeRegisterId, resource) {
  
    $.ajax({
        data: {

        }, success: function (dados) {
            window.location.href = "../Orders/ScannerSerialOnRout?docEntry=" + docEntry + "&sequence=" + sequence + "&posId=" + posId + "&idRgSetup=" + idRgSetup + "&timeRegisterId=" + timeRegisterId + "&resource=" + resource;


        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });

}

function AddSerialRout(docEntry, sequence, posId, idRgSetup, timeRegisterId, resource) {

    var serial = $("#serial").val();
    var quantity = $("#quantity").val();
    


   /// $('#serial').prop("disabled", true);
    if (serial != "") {

        $.ajax({
            url: "../Orders/AddSerialRout",
            type: "post",
            data: {
                docEntry: docEntry,
                resource: resource,
                sequence: sequence,
                timeRegisterId: timeRegisterId,
                posId: posId,
                idRgSetup: idRgSetup,
                serial: serial,
                quantity: quantity,

            }, success: function (dados) {
                alert(dados);
                if (dados == 1)
                {

                     alert("Não Pertence a ordem!")

                }
                else
                {
                    if (dados == 2)
                    {
                        alert("Não Registrado no Ultimo setor")

                    } else
                    {

                        if (dados == 3) {

                            alert("Já Registrado na Ordem!")

                        }
                        else
                        {
                            $('#data').empty();
                            $('#data').append(dados);

                            var s = $('table tbody tr').length;

                            $('#tbCount').html('Total: ' + s);

                            $('#serial').val("");

                        }
                    }
                }                
                      
             
                $('#serial').val("");
                $('#serial').focus();                          
           
               
              
            }, beforeSend: function () {
            }
        }).done(function (msg) {

        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    }
}

function ApproveAll(timeRegisterId, status)
{
    if (confirm("Realizar todas as Inspeção do Registro de Tempo ?") == true) {

        $.ajax({
            url: "../QualityControl/ApproveAll",
            type: "post",
            data: {
                timeRegisterId: timeRegisterId,
                status: status,
            }, success: function (dados) {
                if (dados = true) {

                    alert("Os itens Foram Aprovados!");

                    document.location.reload(true);
                }
            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    }
 }

function SaveTableProductInspectLines() {

    var i = 0;
    var count = $("#count").val();
    var query = "";
    var productInspectId;
    
  
    while (i < count) {
        var comments = $("#comments_" + i).val();
        var blockQty = $("#blockQty_" + i).val();
        
        var status = $("#status_" + i).val();

        var reason = $("#reason_" + i).val();
        var productInspectLineId = $("#productInspectLinesId_" + i).val();
        productInspectId = $("#productInspectId_" + i).val();
        
        if (status == "Y" || status == "B") {

            query = query + "  " + "UPDATE ATEEI_SRTP_PLACAS_INSPECIONADAS_PARAMETRO SET MOTIVO_STATUS = '" + reason + "' , OBS='" + comments + "', QUANTIDADE_BLOQUEADA =" + blockQty.replace(",", ".") + " , APROVADO = '" + status + "', USUARIO=30, DATA=GETDATE()  WHERE ID = " + productInspectLineId + "";

        } else {

            query = query + "  " + "UPDATE ATEEI_SRTP_PLACAS_INSPECIONADAS_PARAMETRO SET MOTIVO_STATUS = '" + reason + "' , OBS='" + comments + "', QUANTIDADE_BLOQUEADA =" + blockQty.replace(",", ".") + " , APROVADO = '" + status + "'  WHERE ID = " + productInspectLineId + "";
        }
        i++;
    }

    $.ajax({
        url: "../QualityControl/SaveTableProductInspectLines",
        type: "post",
        data: {
            query: query,
            productInspectId: productInspectId,
        }, success: function (dados) {
            alert(dados);
            $("#save").text("Salvo");
            document.location.reload(true);

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });

}
function ProductTrace(serial, sequence,docEntry) {

   
    $.ajax({
        data: {

        }, success: function (dados) {
            window.location.href = "../ProductTrace/ProductTrace?serialNumber=" + serial + "&rout=" + sequence + "&docEntry=" + docEntry;


        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });


}
function ProductionFlaw(serial, resource,docEntry, posId) {
    $.ajax({
        data: {

        }, success: function (dados) {

            window.location.href = "../ProductionFlaw/ProductionFlaw?serialNumber=" + serial + "&resource=" + resource + "&docEntry=" + docEntry + "&posId=" + posId + "";

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });


}