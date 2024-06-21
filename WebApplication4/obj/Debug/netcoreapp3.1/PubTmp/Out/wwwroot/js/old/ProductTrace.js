function ProductTraceSerialBatch(ProductTraceId, docEntry, itemCode, posId) {
    alert('');
    $.ajax({
        data: {

        }, success: function (dados) {

            window.location.href = "../ProductTrace/ProductTraceSerialBatch?ProductTraceId=" + ProductTraceId + "&docEntry=" + docEntry + "&itemCode=" + itemCode + "&posId=" + posId;

        }, beforeSend: function () {
        }
    }).done(function (msg) {
    }).fail(function (jqXHR, textStatus, msg) {
        alert("Error: " + msg);
    });
}






function SaveTableProductTraceSerialBatch() {
    var i = 0;
    alert('');
    var count = $("#count").val();
   
    var query = "";
    var productTraceId = $("#ProductTraceId").val();
    var itemCode = $("#ItemCode").val();
    var batchNum = $("#BatchNum_0").val();
    var quantity = $("#Quantity_0").val();
  
    query = "INSERT INTO ATEEI_SRTP_PRODUCT_TRACE_BATCH (ID_PRODUCT_TRACE_WO,ItemCode,BatchNum,Quantity) VALUES(" + productTraceId + ",'" + itemCode + "','" + batchNum + "'," + quantity +") ";
    alert(query);
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



}