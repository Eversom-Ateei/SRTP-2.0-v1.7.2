const { Tab } = require("bootstrap");

function SaveTableProductTestLines() {
    var table = "ATEEI_SRTP_ProductTestLines";
    var i = 1;
    var count = $("#count").val();
    var query = "";
    var productTestId;
    while ((i-1) < count) {
        var minimun = $("#minimun_" + i).val();
        var maximun = $("#maximun_" + i).val();
        var mark = $("#mark_" + i).val();
        var quantity = $("#quantity_" + i).val();
        var measurement = $("#measurement_" + i).val();
        var comments = $("#comments_" + i).val();
     
        var status = $("#status_" + i).val();
        var tool = $("#toolCod_" + i).val();
        var justity = $("#justify_" + i).val();
        var productTestLinesId = $("#productTestLinesId_" + i).val();
        productTestId = $("#productTestId_" + i).val();
        var statusOld = $("#statusOld_" + i).val();

        if (status == "Y" || status == "B") {

            if ((status == "Y" && statusOld == "B") || (status == "B" && statusOld == "Y")) {

                query = query + "  " + "UPDATE " + table + " SET Justify = '" + justity + "' , Comments = '" + comments + "', measurement = '" + measurement + "', Status = '" + status + "', UserRealese = {USER}, DateRealese=GETDATE() , ToolCod = '" + tool + "', Minimun = '" + minimun + "', Maximun = '" + maximun + "' ,Mark = '" + mark + "' WHERE ID = " + productTestLinesId + "";

            }
            else {
                if (statusOld == "N") {

                    query = query + "  " + "UPDATE " + table + " SET Justify = '" + justity + "' , Comments ='" + comments + "', measurement = '" + measurement + "', Status = '" + status + "', UserRealese = {USER}, DateRealese=GETDATE() , ToolCod = '" + tool + "', Minimun = '" + minimun + "', Maximun = '" + maximun + "' ,Mark = '" + mark + "' WHERE ID = " + productTestLinesId + "";

                }
                else {
                    query = query + "  " + "UPDATE " + table + " SET Justify = '" + justity + "' , Comments ='" + comments + "', measurement = '" + measurement + "', Status = '" + status + "', ToolCod = '" + tool + "', Minimun = '" + minimun + "', Maximun = '" + maximun + "' ,Mark = '" + mark + "' WHERE ID = " + productTestLinesId + "";

                }
            }
        }
        else {

            query = query + "  " + "UPDATE " + table + " SET Justify = '" + justity + "' , Comments ='" + comments + "', measurement = '" + measurement + "',Status = '" + status + "' , ToolCod = '" + tool + "', Minimun = '" + minimun + "', Maximun = '" + maximun + "' ,Mark = '" + mark + "' WHERE ID = " + productTestLinesId + "";

        }
        i++;
    }


    alert(query);
    $.ajax({
        url: "../QualityControl/SaveTableProductTestLines",
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




}
