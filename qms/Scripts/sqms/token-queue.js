$(document).ready(function () {
    $("input[type=radio]").checkboxradio();
});
var today = new Date();
function AddNmber(number) {
    $("#contact_no").html($("#contact_no").html() + number);
}

function voidMsisdn() {
    $("#contact_no").html("01");
}

function backSpace() {
    var str = $("#contact_no").html().substr(0, $("#contact_no").html().length - 1);
    $("#contact_no").html(str);
}
document.getElementById('date').innerHTML = today.getDate();

//$("#message").html(document.location.host); 

function Save() {

    var contactNo = $("#contact_no").html();
    var servicetype = $("input[name=radio-service]:checked").val();
    if (servicetype == "") {
        alert('Please Select Service Type!!!');
        return;
    }

    //var con = JSON.stringify(contactNo);
    $.ajax({
        url:  '../TokenQueues/Create',
        type: 'POST',
        dataType: 'json',
        data: { mobile: contactNo, service: servicetype },
        success: function (data) {
            $("#message").html(data.Message);
            $("#service_name").val('');
            $("#txtContact").val('');
            $("#hidtokenNo").val(data.tokenId);
            $("#printTokenId").text(data.tokenNo);
            $("#tokenNo").val(data.tokenNo);

            $("#mobileNo").val(data.msisdn);

            $("#date").text(data.Date);
             // 2018-07-20

            //  $("#service_name").empty();
        }
    });
};

function sms() {

    var mobileNo = $("#mobileNo").val();
    var tokenNo = $("#tokenNo").val();


    //var con = JSON.stringify(contactNo);
    $.ajax({
        url: '../TokenQueues/SMSSend',
        type: 'POST',
        dataType: 'json',
        data: { mobileNo: mobileNo, tokenNo: tokenNo },
        success: function (data) {
            if (data.Success == true)
                {
                $("#message").html("Message sent");
                voidMsisdn();
            }
            else
                $("#message").html(data.Message);
            //  $("#service_name").empty();
        }
    });
};
//function sms() {
//    //var contactNo = $("#txtContact").val();
//    var tokenId = $("#hidtokenNo").val();
//    if (tokenId == "") {
//        alert('Please Create a Token First!!!');
//        return;
//    }

//    //var con = JSON.stringify(contactNo);
//    $.ajax({
//        url: webRootAddtionalPath + '/TokenQueues/Sms',
//        type: 'POST',
//        dataType: 'json',
//        data: { tokenId: tokenId },
//        success: function (data) {
//            $("#message").html(data.Message);
//            $("#service_name").val('');
//            $("#txtContact").val('');
//            $("#hidtokenNo").val('');

//            //  $("#service_name").empty();
//        }
//    });
//};

function printDiv(divName) {
    var printContents = document.getElementById(divName).innerHTML;
    var originalContents = document.body.innerHTML;
    document.body.innerHTML = printContents;
    $("#message").val('');
    window.print();
    document.body.innerHTML = originalContents;

}