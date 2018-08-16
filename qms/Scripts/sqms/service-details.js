

$(document).ready(function () {
    $('#tablebody').empty();
    $("#historyDiv").hide();
    $("input[type=radio]").checkboxradio();
    NewServiceNo();
})


function LoadServices(type_id) {

    $.ajax({
        //url: "/SQMS/ServiceDetails/NewTokenNo",
        url: "../ServiceSubTypes/GetByTypeId",
        type: 'POST',
        dataType: "json",
        data: { service_type_id: type_id },
        success: function (data) {
            var serviceSubTypes = data.serviceSubTypes;

            $('#div-sub-type').empty();
            $.each(serviceSubTypes, function (index, service) {
                var div = '<div class="col-lg-4"><input type="radio" class="btn" name="radio-service" id="' + service.service_sub_type_id + '" value="' + service.service_sub_type_name + '" />'
                    + '<label for="' + service.service_sub_type_id + '" class="btn btn-primary glyphicon-text-color" hidden="hidden" style="padding:10px">' + service.service_sub_type_name + '</label></div>';
                $('#div-sub-type').append(div);
            });


        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            modalAlert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }
    });
}


$("#service_type_id").change(function () {
    var type_id = this.value;

    LoadServices(type_id);

});


function breakcall() {
   // user_id = $("#hiduserId").val();

    $.ajax({
        //url: "/SQMS/ServiceDetails/NewTokenNo",
        url: "../ServiceDetails/Update",
        type: 'POST',
        dataType: "json",
        //data: { user_id: user_id },
        success: function (data) {
            $("#txtServiceType").val('');
            $("#txtgnTime").val('');
            $("#txtCallTime").val('');
            $("#txtWtTime").val('');
            return;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            modalAlert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }
    });

    return;
}

function NewServiceNo() {


    $('#tablebody').empty();
    $("#historyDiv").hide();

    $.ajax({
        //url: "/SQMS/ServiceDetails/NewTokenNo",
        url:  "../ServiceDetails/NewTokenNo",
        type: 'POST',
        dataType: "json",
        success: function (data) {
            //debugger;
            if (data.Success == true) {
                if (data.Message.IsBreak == 1) {
                    modalConfirm("Do you want to Take a Break?", breakcall);
                    
                }
                $("#update-message").html('');
                $("#hiduserId").val(data.Message.user_id);
                $("#update-message").html(data.Message.token);
                $("#start_time").val('');
                $("#start_time").prop('disabled', true);
                $("#txtServiceType").val(data.Message.serviceType);
                $("#txtServiceType").prop('disabled', true);
                $("#hidtokenNo").val(data.Message.tokenid);
                $("#token").val(data.Message.token);
                $("#txtIssues").val('');
                $("#txtsolutions").val('');
                if (data.Message.mobile_no != "") {

                    $("#txtContact").val(data.Message.mobile_no);
                    $("#txtCallTime").val(data.Message.call_time);
                    $("#txtCallTime").prop('disabled', true);
                    $("#txtgnTime").val(data.Message.generate_time);
                    $("#txtgnTime").prop('disabled', true);
                    $("#txtWtTime").val(data.Message.waitingtime);
                    $("#txtWtTime").prop('disabled', true);
                    $("#txtName").val(data.Message.customer_name);
                    $("#txtAddress").val(data.Message.address);
                    //GetCustomerInformation(); // 2018-07-20
                } else {
                    $("#txtContact").prop('disabled', false);
                    $("#txtName").val("");
                    $("#txtAddress").val("");
                }

                $("#service_type_id").val(data.Message.service_type_id);
                LoadServices(data.Message.service_type_id);
                
            } else {
                modalAlert(data.Message);
            }


        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            modalAlert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }

    });
}


function AddServiceCall() {
    var contactNo = $("#txtContact").val();
    var Customername = $("#txtName").val();
    var Customeraddress = $("#txtAddress").val();
    var customerissues = $("#txtIssues").val();
    var customersolutions = $("#txtsolutions").val();
    var customertokenno = $("#hidtokenNo").val();
    var data0 = {
        "contact_no": contactNo,
        "customer_name": Customername,
        "issues": customerissues,
        "address": Customeraddress,
        "solutions": customersolutions,
        "token_id": customertokenno,
        "start_time": $("#start_time").val(),
        "service_sub_type_id": $('#service_sub_type_id').val()
    }

    $.ajax({
        url: '../ServiceDetails/AddService',
        type: 'POST',
        dataType: 'json',
        data: { model: data0 },
        success: function (data) {
            if (data.Success == true) {
                $("#txtIssues").val('');
                $("#txtsolutions").val('');
                $("#start_time").val(getCurrentDate());
            }
            else {
                modalAlert(data.Message);
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            modalAlert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }
    });
}


function AddService() {

    modalServiceType();
    return;
    var contactNo = $("#txtContact").val();
    var Customername = $("#txtName").val();
    var Customeraddress = $("#txtAddress").val();
    var customerissues = $("#txtIssues").val();
    var customersolutions = $("#txtsolutions").val();
    var customertokenno = $("#hidtokenNo").val();
    if (customertokenno == "") {
        modalAlert("Please First Generate New Service No.....");
        return false;
    }
    if (contactNo == "") {
        modalAlert("Please Enter Mobile No.....");
        return false;
    }

    if (Customername == "") {
        modalAlert("Please Enter Customer Name....");
        return false;
    }

    if (Customeraddress == "") {
        modalAlert("Please Enter Address.....");
        return false;
    }

    if (customerissues == "") {
        modalAlert("Please Enter Issues.....");
        return false;
    }
    if (customersolutions == "") {
        modalAlert("Please Enter Solutions.....");
        return false;
    }

    modalConfirm("Current service will finish and next service will start automatically for this customer. Do you want to continue?", AddServiceCall);

}

function CallToken(token_no) {
    if (token_no == null || token_no == "") {
        modalAlert("Please input a token no for next service");
        return;
    }

    $.ajax({
        url: "../ServiceDetails/CallManualTokenNo",
        type: 'POST',
        data: { token_no_string: token_no },
        data: { token_no_string: token_no },
        dataType: "json",
        success: function (data) {
            //debugger;
            if (data.Success == true) {
                modalAlert("Token No# " + token_no + " is now in your queue list after current service, it will automatically call.");
            } else {
                modalAlert(data.Message);
            }


        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            modalAlert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }

    });
}

function ManualCall() {
    var token = $("#hidtokenNo").val();
    
    $('#tablebody').empty();
    $("#historyDiv").hide();

    modalPrompt("Please enter token no which is not served yet or missed:", CallToken);
    
}


function Cancel() {

    var token = $("#hidtokenNo").val();

    $.ajax({
        url: "../ServiceDetails/Cancel",
        type: 'POST',
        dataType: "json",
        data: { tokenID: token },
        success: function (data) {


            $("#txtContact").val('');
            $("#txtName").val('');
            $("#txtIssues").val('');
            $("#txtsolutions").val('');
            $("#txtAddress").val('');
            $("#update-message").html('');
            $("#hidtokenNo").val('');
            $("#txtServiceType").val('');
            $("#start_time").val('');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            modalAlert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }
    });

    

}



function CounterTransfer(counter_no) {
    if (counter_no == null || counter_no == "") {
        modalAlert("Please input a counter no for transfer this service");
        return;
        return;
    }



    var token = $("#hidtokenNo").val();

    $.ajax({
        url: "../ServiceDetails/Transfer",
        type: 'POST',
        dataType: "json",
        data: { token_id: token, counter_no: counter_no },
        success: function (data) {

            if (data.Success == true) {
                $("#txtContact").val('');
                $("#txtName").val('');
                $("#txtIssues").val('');
                $("#txtsolutions").val('');
                $("#txtAddress").val('');
                $("#update-message").html('');
                $("#hidtokenNo").val('');
                $("#txtServiceType").val('');
                $("#start_time").val('');

                NewServiceNo();

            } else {
                modalAlert(data.Message);
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            modalAlert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }
    });
}

function Transfer() {

    $('#tablebody').empty();
    $("#historyDiv").hide();


    modalPrompt("Please enter counter no where you transfer this token:", CounterTransfer);
    
}

function CancelN() {

    var token = $("#hidtokenNo").val();

    $.ajax({
        url: "../ServiceDetails/CancelTokenNo",
        type: 'POST',
        dataType: "json",
        data: { tokenID: token },
        success: function (data) {

            $("#txtContact").val('');
            $("#txtName").val('');
            $("#txtIssues").val('');
            $("#txtsolutions").val('');
            $("#txtAddress").val('');
            $("#update-message").html('');
            $("#hidtokenNo").val('');

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            modalAlert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }
    });
}

function CancelNext() {
    var token = $("#hidtokenNo").val();

    $.ajax({
        url: "../ServiceDetails/CancelTokenNo",
        type: 'POST',
        dataType: "json",
        data: { tokenID: token },
        success: function (data) {

            $("#txtContact").val('');
            $("#txtName").val('');
            $("#txtIssues").val('');
            $("#txtsolutions").val('');
            $("#txtAddress").val('');
            $("#update-message").html('');
            $("#hidtokenNo").val('');

            NewServiceNo();

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            modalAlert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }
    });
}

function Skip() {
    var token = $("#hidtokenNo").val();

    $.ajax({
        url: "../ServiceDetails/Skip",
        type: 'POST',
        dataType: "json",
        data: { tokenID: token },
        success: function (data) {
            debugger;
            $("#txtContact").val('');
            $("#txtName").val('');
            $("#txtIssues").val('');
            $("#txtsolutions").val('');
            $("#txtAddress").val('');
            $("#update-message").html('');
            $("#hidtokenNo").val('');

            NewServiceNo();

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            modalAlert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }
    });
}
function ReIssue() {
    debugger;
    $.ajax({
        url: "../ServiceDetails/ReIssue",
        type: 'POST',
        dataType: "json",
        success: function (data) {
            //debugger;
            if (data.Success == true) {
                $("#update-message").html('');
                $("#update-message").html(data.Message.token);
                $("#start_time").val(data.Message.start_time);
                $("#start_time").prop('disabled', true);
                $("#txtServiceType").val(data.Message.serviceType);
                $("#txtServiceType").prop('disabled', true);
                $("#hidtokenNo").val(data.Message.tokenid);
                $("#token").val(data.Message.token);
                if (data.Message.mobile_no != "") {

                    $("#txtContact").val(data.Message.mobile_no);
                    $("#txtContact").prop('disabled', true);
                } else {
                    $("#txtContact").prop('disabled', false);
                }

                $("#txtName").val("");
                $("#txtAddress").val("");
                loadServices(data.Services);
            } else {
                modalAlert(data.Message);
            }


        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            modalAlert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }
    });
}



function GetCustomerInformation() {
    $('#tablebody').empty();
    var token = $("#hidtokenNo").val();
    var contact_nember = $("#txtContact").val();
    $.ajax({
        url: "../ServiceDetails/GetCustomerInformation",
        type: 'POST',
        dataType: "json",
        data: {
            token_id: token,
            contact_no: contact_nember
        },
        success: function (response) {
            //debugger;

            $("#historyDiv").show();
            var select = $('#tablebody');
            for (var i = 0; i < response.Message.length; i++) {
                select.append($('<tr><td>' + response.Message[i].issues + '</td><td>'
                    + response.Message[i].solutions + '</td><td>'
                    + response.Message[i].service_datetime_string + '</td></tr>'));

                
            }

            if (response.customerDetails.customer_name != "") {
                $("#txtName").val(response.customerDetails.customer_name);

            } 

            if (response.customerDetails.address != "") {
                $("#txtAddress").val(response.customerDetails.address);
            } 


        }, error: function (XMLHttpRequest, textStatus, errorThrown) {
            modalAlert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }
    });

}

function Save() {
    var contactNo = $("#txtContact").val();
    var Customername = $("#txtName").val();
    var Customeraddress = $("#txtAddress").val();
    var customerissues = $("#txtIssues").val();
    var customersolutions = $("#txtsolutions").val();
    var customertokenno = $("#hidtokenNo").val();
    if (customertokenno == "") {
        modalAlert("Please First Generate New Service No.....");
        return false;
    }
    if (contactNo == "") {
        modalAlert("Please Enter Mobile No.....");
        return false;
    }

    if (Customername == "") {
        modalAlert("Please Enter Customer Name....");
        return false;
    }

    if (Customeraddress == "") {
        modalAlert("Please Enter Address.....");
        return false;
    }

    if (customerissues == "") {
        modalAlert("Please Enter Issues.....");
        return false;
    }
    if (customersolutions == "") {
        modalAlert("Please Enter Solutions.....");
        return false;
    }



    var data0 = {
        "contact_no": contactNo,
        "customer_name": Customername,
        "issues": customerissues,
        "address": Customeraddress,
        "solutions": customersolutions,
        "token_id": customertokenno,
        "start_time": $("#start_time").val(),
        "service_sub_type_id": $('#service_sub_type_id').val()
    }

    $.ajax({
        url: '../ServiceDetails/Done',
        type: 'POST',
        dataType: 'json',
        data: { model: data0 },
        success: function (data) {

            $("#update-message").html('');
            $("#txtContact").val('');
            $("#txtName").val('');
            $("#txtIssues").val('');
            $("#txtsolutions").val('');
            $("#txtAddress").val('');
            $("#historyDiv").hide();
            $("#txtServiceType").val('');
            $("#start_time").val('');
            $("#hidtokenNo").val('');

        }
    });

}

function SaveNext() {
    debugger;
    var contactNo = $("#txtContact").val();
    var Customername = $("#txtName").val();
    var Customeraddress = $("#txtAddress").val();
    var customerissues = $("#txtIssues").val();
    var customersolutions = $("#txtsolutions").val();
    var customertokenno = $("#hidtokenNo").val();
    if (customertokenno == "") {
        modalAlert("Please First Generate New Service No.....");
        return false;
    }
    if (contactNo == "") {
        modalAlert("Please Enter Mobile No.....");
        return false;
    }

    if (Customername == "") {
        modalAlert("Please Enter Customer Name....");
        return false;
    }

    if (Customeraddress == "") {
        modalAlert("Please Enter Address.....");
        return false;
    }

    if (customerissues == "") {
        modalAlert("Please Enter Issues.....");
        return false;
    }
    if (customersolutions == "") {
        modalAlert("Please Enter Solutions.....");
        return false;
    }



    var data0 = {
        "contact_no": contactNo,
        "customer_name": Customername,
        "issues": customerissues,
        "address": Customeraddress,
        "solutions": customersolutions,
        "token_id": customertokenno,
        "start_time": $("#start_time").val(),
        "service_sub_type_id": $('#service_sub_type_id').val()
    }


    //if (contactNo == "") {
    //    modalAlert('Please type Mobile no');
    //    return false;
    //}
    //var con = JSON.stringify(contactNo);

    $.ajax({
        url: '../ServiceDetails/Create',
        type: 'POST',
        dataType: 'json',
        data: { model: data0 },
        success: function (data) {

            $("#update-message").html('');
            $("#txtContact").val('');
            $("#txtName").val('');
            $("#txtIssues").val('');
            $("#txtsolutions").val('');
            $("#txtAddress").val('');
            $("#historyDiv").hide();
            $("#txtServiceType").val('');
            $("#start_time").val('');

            NewServiceNo();
        }
    });

}



