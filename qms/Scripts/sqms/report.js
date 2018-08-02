$(document).ready(function () {
    $("#branch_id").change(function () {
        // debugger;
        var selectedBranch = $("#branch_id option:selected").text();
        var selectedVal = this.value;
        $('#txtCounter').empty();
        $.ajax({
            url: "../../Home/GetCounterByBranchId",
            type: "GET",
            dataType: "json",
            data: { branchId: selectedVal },
            success: function (data) {
                if (data.data.length > 0) {
                    $('#txtCounter').append($("<option value=''>Select a Counter</option>"));

                    for (var i = 0; i < data.data.length; i++) {
                        $('#txtCounter').append($("<option></option>").attr("value", data.data[i].counter_id).text(data.data[i].counter_no));
                    }
                } else {
                    $('#txtCounter').append($("<option value=''>No Counter Found!!!</option>"));
                }
            },
            error: function (response) {
                alert(response);
            }
        });

    });
    $("#txtCounter").change(function () {
        // debugger;
        var selectedCounter = $("#txtCounter option:selected").text();
        var selectedCounterVal = this.value;
        $('#txtToken').empty();
        $.ajax({
            url: "../../Report/GetTokenByBranchId",
            type: "GET",
            dataType: "json",
            data: { CounterId: selectedCounterVal },
            success: function (data) {
                debugger;
                if (data.data.length > 0) {
                    $('#txtToken').append($("<option value=''>Select a Token</option>"));

                    for (var i = 0; i < data.data.length; i++) {
                        $('#txtToken').append($("<option></option>").attr("value", data.data[i].token_id).text(data.data[i].token_id));
                    }
                } else {
                    $('#txtToken').append($("<option value=''>No Token Found!!!</option>"));
                }
            },
            error: function (response) {
                alert(response);
            }
        });

    });
});
//$(document).ready(function () {
//    $("#txtBranch").autocomplete({
//        source: function (request, response) {
//            $.ajax({
//                url: "/Branches/AutocompleteBranchSuggestions",
//                type: "POST",
//                dataType: "json",
//                data: { term: request.term },
//                success: function (data) {
//                    response($.map(data, function (item) {
//                        return { label: item.label,
//                            value: item.label
//                        };
//                    }))
//                }
//            })
//        },
//        messages: {
//            noResults: "", results: ""
//        }
//    });
//})

//$("#branch_id").change(function () {
//    // Pure JS
//  //  debugger;
//    var selectedVal = this.value;
//    var selectedText = this.options[this.selectedIndex].text;
//    $.ajax({
//        url: "//NewTokenNo",
//        type: 'POST',
//        dataType: "json",
//        success: function (data) {
//            $("#token").val(data.Message);
//            $("#update-message").html(data.Message);
//            $("#hidtokenNo").val(data.Message);

//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
//        }
//    });
//    // jQuery
//   // /var selectedVal = $(this).find(':selected').val();
//  //  var selectedText = $(this).find(':selected').text();
//});

$(function () {
    $("#txtBranch").autocomplete({
        source:  "../Branches/AutocompleteBranchSuggestions",
        minLength: 1,
        select: function (event, ui) {
            event.preventDefault();
            $('input[name="txtBranch"]').val(ui.item.label);
            //  $('input[name="txtEmpName"]').val(ui.item.value);
            //GetEmpId();
            //return false;
        },
        focus: function (event, ui) {
            event.preventDefault();
            $("#txtBranch").val(ui.item.label);
        },
    });
});

$(function () {

    var x = document.querySelector('input[name="ReportOptionCS"]:checked').value;
    $("input[name='ReportOptionCS']").change(function () {
        var x = document.querySelector('input[name="ReportOptionCS"]:checked').value;

        if (x == "Summary") {
            $("#txtCounter").prop('disabled', true);
            $("#txtToken").prop('disabled', true);
            $("#txtBranch").val("");
            $("#txtCounter").val("");
            $("#txtToken").val("");


        } else {

            $("#txtCounter").prop('disabled', false);
            $("#txtToken").prop('disabled', false);
            $("#txtBranch").val("");
            $("#txtCounter").val("");
            $("#txtToken").val("");
        }
    });
});

$("#RemoveFilter").click(function () {

    $("#txtBranch").val("");
    $("#txtCounter").val("");
    $("#txtToken").val("");
    $("#txtToDate").val("");
    $("#txtFromDate").val("");
})

function GeneratePFReportRDLC(fileType) {
    var d = new Date();
    var x = document.querySelector('input[name="ReportOptionCS"]:checked').value;
    var fromDate = $('#txtFromDate').val();
    var toDate = $('#txtToDate').val();
    var branchID = $('#branch_id').val();
    var counterID = $('#txtCounter').val();
    var token = $('#txtToken').val();

    if (x == "Summary" && branchID == "") {
        alert("Please Enter Branch");
        return false;
    }
    //if (fromDate > toDate) {
    //    alert("To Date must be Greater than From Date");
    //    return false;
    //}

    if ((fromDate == "" || toDate == "")) {
        alert("Pl's Fill To Date & From Date");
        return false;
    }

    var viewURL = '../Report/CustomerServiceReport/?id=' + fileType + '&reportOptions=' + x + '&branchID=' + branchID + '&CounterID=' + counterID + '&tokenID=' + token + '&fromDate=' + fromDate + '&toDate=' + toDate;

    window.location = viewURL;
    //FancyBox(viewURL);
    return false;
};