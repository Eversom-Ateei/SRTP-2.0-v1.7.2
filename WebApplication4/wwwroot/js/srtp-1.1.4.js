

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

   // return location.protocol + "//" + location.host + VirtualDirectory + "/"
    return location.protocol + "//" + location.host + VirtualDirectory + "/"
}


function Logout() {  
    if (confirm("Desconectar-se?") == true)
    {
        try {
            $.ajax({
                url: getHostSite() + "/Login/Logout",
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
        } catch {

            $.ajax({
                url: "/Login/Logout",
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
}


function Login() {


    var id = $('#id').val();
    try {
        $.ajax({
            url: getHostSite() + "/Login/Login",
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
    } catch {

        $.ajax({
            url:  "/Login/Login",
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
}


function CloseSetup(id) {


    if (confirm("Fechar Setup de Produção?") == true) {

        $.ajax({
            url: "/ProductionSetup/CloseSetup",
            type: "post",
            data: {                
                id: id,
            }, success: function (dados) {

                alert(dados)

            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });


    }


}


function StartChat(user) {

    if (confirm("Iniciar?") == true)
    {
        $.ajax({
            url: getHostSite() + "Login/ChatView",
            type: "post",
            data: {
                user : user,
            }, success: function (dados){

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


function SetItems(idRgSetup,docEntry) {
   
    $.ajax({
        url: "../Orders/SetItems",
        type: "post",
        data: {
            idRgSetup: idRgSetup,
            docEntry: docEntry,
        }, success: function (dados) {


            $("#setItems").html(dados);
            $("#linkmodal").click();



        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}

function ListTraceBatch(batchNum) {

    $.ajax({
        url: "../Orders/ListTraceBatch",
        type: "post",
        data: {
            batchNum: batchNum,  
        }, success: function (dados) {


            $("#listTraceBatch").html(dados);
            $("#linkModalList").click();



        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}



function DeleteSetItems(id, idRgSetup) {

    if (confirm("Excluir a linha do Set?")) {
        $.ajax({
            url: "../Orders/DeleteSetItems",
            type: "post",
            data: {
                id: id,
                idRgSetup, idRgSetup,

            }, success: function (dados) {


                $("#setItems").html(dados);



            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    }

}

function AddSetItems(idRgSetup, docEntry) {

    let text = $("#code").val();
    const myArray = text.split("<1;>");

    var itemCode = myArray[0];
    var batchNum = myArray[1];  
    var quantity = myArray[2];

    var posId = parseInt(myArray[4]).toString();

    $.ajax({
        url: "../Orders/AddSetItems",
        type: "post",
        data: {
            docEntry: docEntry,
            itemCode: itemCode,
            batchNum: batchNum,
            idRgSetup: idRgSetup,
            quantity: quantity,
            posId : posId,
        }, success: function (dados) {

            if (dados == "ERROR1")
            {
                alert("Posição já Preenchida!");
            }
            else 
            {
                if (dados == "ERROR2")
                {
                    alert("Sem Quantidade!");
                }
                else
                {
                    if (dados == "ERROR3")
                    {
                        alert("Quantidade superior a utilizada por Placa!");

                       
                        
                    }
                    else
                    {
                        if (dados == "ERROR4") {
                            alert("Numero se serie ja apontado na Ordem!");
                        }
                        else
                        {
                            $("#setItems").html(dados);
                            $("#code").val("");
                        }
                        
                    }
                    
                }
            }
            $("#code").prop("disabled", false);
            $('#code').val("");
            $('#code').focus();
        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}
function ReopenTimeRegister(id) {
    try {
        if (confirm("Reabrir o Registro de Tempo?")) {
            $.ajax({
                url: "../Orders/ReopenTimeRegister",
                type: "post",
                data: {
                    id: id,
                }, success: function (dados) {

                    if (dados !== 'true') {
                        alert(dados);
                    } else {
                        alert("Registro de tempo reaberto!");
                    }
                }, beforeSend: function () {
                }
            }).done(function (msg) {
            }).fail(function (jqXHR, textStatus, msg) {
                alert("Error: " + msg);
            });
        }
        } catch (e) {

            alert(e);

        }
    
} 
function DelProdInspByTReg(TimeRegisterId) {
    if (confirm("Deletar planos criado pelo Registro de tempo " + TimeRegisterId+"?")) {
        $.ajax({
            url: "../Orders/DelProdInspByTReg",
            type: "post",
            data: {
                TimeRegisterId: TimeRegisterId,
            }, success: function (dados) {

                if (dados == "true") {

                    alert("Excluído com sucesso!");

                } else {

                    alert(dados);
                }

            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    }

}
function SerialBySeq(docEntry, sequence, posId) {    
    $("#timeReg").html("Carregando...");
    $("#ModalTimeReg").modal();  
        $.ajax({
            url: "../Orders/SerialBySeq",
            type: "post",
            data: {
                docEntry: docEntry,
                sequence: sequence,
                posId: posId,

            }, success: function (dados) {
                $("#timeReg").html("");              
                $("#timeReg").html(dados);           

            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    }

function TimeRegSerial(timeRegisterId) {

    $("#serials").html("");
    $.ajax({
        url: "../Orders/TimeRegSerial",
        type: "post",
        data: {
            timeRegisterId: timeRegisterId,           
        }, success: function (dados) {

            $("#serials").html(dados);
            // $("#linkTimeReg").click();      

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });


}



function TimeRegisters(docEntry, sequence, posId)
{
    $("#timeReg").html("");
    $.ajax({
        url: "../Orders/TimeRegisters",
        type: "post",
        data: {
            docEntry: docEntry,
            sequence: sequence,
            posId: posId,
        }, success: function (dados) {
                        
            $("#timeReg").html(dados);
           // $("#linkTimeReg").click();      

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
                if (dados != "true") {
                    alert(dados);
                } else {
                    window.location.reload();
                }

            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    }
}

function DeleteSerialSetup(id) {
    if(confirm("Deseja excluir o serial do SETUP?")){
        $.ajax({
            url: "../ProductionSetup/DeleteSerialSetup",
            type: "post",
            data: {
                id: id,

            }, success: function (dados) {

                if (dados != "true") {
                    alert(dados);
                } else {
                    window.location.reload();
                }

            }, beforeSend: function () {
            }
        }).done(function (msg) {
        }).fail(function (jqXHR, textStatus, msg) {
            alert("Error: " + msg);
        });
    }
}


function DeleteSerialRout(id) {
    if(confirm("Excluir o serial da Rota?")){
        $.ajax({
            url: "../Orders/DeleteSerialRout",
            type: "post",
            data: {
                id: id,

            }, success: function (dados) {            
                if (dados=="true") {
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

function ScannerSerialOnRout(docEntry,sequence,posId,idRgSetup,timeRegisterId, resource,user) {
  
    $.ajax({
        data: {

        }, success: function (dados) {
            window.location.href = "../Orders/ScannerSerialOnRout?docEntry=" + docEntry + "&sequence=" + sequence + "&posId=" + posId + "&idRgSetup=" + idRgSetup + "&timeRegisterId=" + timeRegisterId + "&resource=" + resource + "&user=" + user;
           

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });

}

function AddSerialRout( docEntry, sequence, posId, idRgSetup, timeRegisterId, resource,user) {

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
                        if (dados == 3)
                        {
                            alert("Já Registrado na Ordem!")
                        }
                        else
                        {
                            if (dados == 4)
                            {
                               

                                    alert("Material do Setup precisa ser revisado!")
                                    ScannerSerialOnRout(docEntry, sequence, posId, idRgSetup, timeRegisterId, resource, user);
                            }
                            else
                            {
                                if (dados == 5) {
                                    alert("Quantidade do componente inferior a consumida por placa!")

                                }
                                else
                                {

                                    if (dados == 6) {
                                        alert("Material do Setup insuficiente para proximo item!")
                                        ScannerSerialOnRout(docEntry, sequence, posId, idRgSetup, timeRegisterId, resource, user);
                                    }
                                    else
                                    {
                                        if (dados == 7) {
                                            alert("Quantidade superior a resgistrada no ultimo Setor!")
                                        }
                                        else {
                                            $('#serial').val("");
                                            $('#data').html(dados);


                                            var s = $('table tbody tr').length;
                                            $('#tbCount').html('Total: ' + s);

                                        }
                                        
                                    }

                                }
                            }
                        }
                    }
                } 
               
                $("#serial").prop("disabled", false);
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

        $("#title").prop("hidden", true);
        $("#loading").prop("hidden", false);


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


function ProductTest(serial, sequence, docEntry, timeRegisterId) {


    $.ajax({
        data: {

        }, success: function (dados) {
            window.location.href = "../QualityControl/ProductTest?serialNumber=" + serial + "&rout=" + sequence + "&docEntry=" + docEntry + "&timeRegisterId=" + timeRegisterId;


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


function CreateProductTest(serial, rout, docEntry, timeRegisterId) {
    $.ajax({
        data: {

        }, success: function (dados) {

            window.location.href = "../QualityControl/CreateProductTest?serial=" + serial + "&rout=" + rout + "&docEntry=" + docEntry + "&timeRegisterId=" + timeRegisterId;

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });


}


function DeleteSerialBatch(id) {

    if (confirm("Excluir essa linha?")) {
        $.ajax({
            url: "../ProductTrace/DeleteSerialBatch",
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