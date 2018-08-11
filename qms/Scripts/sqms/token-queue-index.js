function FilterTable() {
    index = -1;
    inp = $('#filterBox').val();
    $("#data:visible tr:not(:has(>th))").each(function () {
        if (~$(this).text().toLowerCase().indexOf(inp.toLowerCase())) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
    $('#Hedding').show();
}

$(document).ready(function () {
    inp = $("#branch_name option:selected").text();
    if (inp == "All Branch") {
        $("#branch_name").attr('disabled', false);
    }
    else $("#branch_name").attr('disabled', true);

    FilterTable2();
    $("#branch_name").change(function () {
        // var selectedBranch = $("#branch_name option:selected").text();
        FilterTable2();

    });
});

function FilterTable2() {
    index = -1;
    inp = $("#branch_name option:selected").text();
    if (inp == "All Branch") {
        inp = "";
    }
    $("#data:visible tr:not(:has(>th))").each(function () {
        if (~$(this).text().toLowerCase().indexOf(inp.toLowerCase())) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
    $('#Hedding').show();
};
function GetList() {

    var date = $('#txtAsOnDate').val();

    if (date == "") {
        ShowModalMessage("Please select a date");
        return;
    }

    var URL = '../TokenQueues/GetList/?date=' + date;
    $.get(URL, function (data) {

        $("#data").html('');
        $("#data").html(data);
    });
};

function sms(mobileNo, tokenNo) {


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
                    
                }
                else
                    $("#message").html(data.Message);
            
            //  $("#service_name").empty();
        }
    });
};

function printDiv(divName) {
    var printContents = document.getElementById(divName).innerHTML;
    var originalContents = document.body.innerHTML;

    document.body.innerHTML = printContents;

    window.print();

    document.body.innerHTML = originalContents;
}

function printToken(id) {
    //var contactNo = $("#save_btn").val();
    var tokenNo = id//$("#hidtokenNo").val();
    //var con = JSON.stringify(contactNo);
    $.ajax({
        url: '../TokenQueues/Print',
        type: 'POST',
        dataType: 'json',
        data: { tokenNo: tokenNo },
        success: function (data) {
            $("#date").text(data.Date);
            $("#printTokenId").text(data.Message);
            printDiv('printableArea');
            //  $("#service_name").empty();
        }
    });
};