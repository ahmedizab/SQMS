

$(document).ready(function () {
    $('#tablebody').empty();
    $("input[type=radio]").checkboxradio();
    
    NewServiceNo();
})

function ShowPannel(pannel_index) {
    if (pannel_index == 1) {
        $("#collapse1").collapse('show');
        $("#collapse2").collapse('hide');
    }
    else {
        $("#collapse1").collapse('hide');
        $("#collapse2").collapse('show');
    }
}


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
                var div = '<div class="col-lg-6 col-md-6 col-sm-6" style="text-align: left;" ><input type="radio" style="cursor:pointer" name="radio-service" id="' + service.service_sub_type_id + '" value="' + service.service_sub_type_id + '"/>'
                    + '<label for="' + service.service_sub_type_id + '" style="cursor:pointer;" hidden="hidden" max_duration="' + service.max_duration + '" style="padding:10px">' + service.service_sub_type_name + '</label></div>';
                $('#div-sub-type').append(div);
            });
            $("input[type=radio]").checkboxradio();

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


function breakAdd(break_type_id, remarks) {
    $.ajax({
        //daily_break_id, break_type_id, user_id, start_time, end_time, remarks//
        url: "../DailyBreaks/Create",
        type: 'POST',
        dataType: "json",
        data: {
            break_type_id: break_type_id,
            remarks: remarks
        },
        success: function (data) {
            if (data.success == false) {
                modalAlert(data.Message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            modalAlert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }
    });
}

function breakcall() {
   // user_id = $("#hiduserId").val();

    $.ajax({
        //url: "/SQMS/ServiceDetails/NewTokenNo",
        url: "../DailyBreaks/Update",
        type: 'POST',
        dataType: "json",
        //data: { user_id: user_id },
        success: function (data) {
            if (data.Success == true) {
                //window.location.href(webRootAddtionalPath + "/DailyBreaks/Index");
                $(location).attr('href', "../DailyBreaks/Index");
            }
            else {
                modalAlert(data.Message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            modalAlert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }
    });

    return;
}

function NewServiceNo() {


    $('#tablebody').empty();

    ShowPannel(1);
    
    

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
                //$("#start_time").val(data.Message.start_time);
                $("#start_time").prop('disabled', true);
                $("#txtServiceType").val(data.Message.serviceType);
                $("#txtServiceType").prop('disabled', true);
                $("#service_sub_type_name").prop('disabled', true);
                $("#hidtokenNo").val(data.Message.tokenid);
                $("#token").val(data.Message.token);
                $("#txtIssues").val('');
                $("#txtsolutions").val('');
                $("#txtCallTime").val(data.Message.call_time);
                $("#txtCallTime").prop('disabled', true);
                $("#txtgnTime").val(data.Message.generate_time);
                $("#txtgnTime").prop('disabled', true);
                $("#txtWtTime").val(data.Message.waitingtime);
                $("#txtWtTime").prop('disabled', true);
                if (data.Message.mobile_no != "") {

                    $("#txtContact").val(data.Message.mobile_no);
                    $("#txtName").val(data.Message.customer_name);
                    $("#txtAddress").val(data.Message.address);
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

function AddServiceCall(value, text, max_duration) {
    ShowPannel(2);
    $('#service_sub_type_id').val(value);
    $('#service_sub_type_name').val(text + ' (Maximum duration: ' + max_duration + ' minuties)');
    $("#start_time").val(getCurrentTime());
}

function AddServiceSave() {

    ShowPannel(2);
    var contactNo = $("#txtContact").val();
    var Customername = $("#txtName").val();
    var Customeraddress = $("#txtAddress").val();
    var customerissues = $("#txtIssues").val();
    var customersolutions = $("#txtsolutions").val();
    var customertokenno = $("#hidtokenNo").val();
    var service_sub_type_id = $('#service_sub_type_id').val();

    if (contactNo == "") {
        modalAlert("Please Enter Mobile No.....");
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
        "service_sub_type_id": service_sub_type_id
    }

    $.ajax({
        url: '../ServiceDetails/Create',
        type: 'POST',
        dataType: 'json',
        data: { model: data0 },
        success: function (data) {
            if (data.Success) {
                $("#txtIssues").val('');
                $("#txtsolutions").val('');
                $("#start_time").val('');
                $("#service_sub_type_name").val('');
                $("#service_sub_type_id").val('');

                serviceDialog.dialog('open');
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
    ShowPannel(2);
    var contactNo = $("#txtContact").val();
    var Customername = $("#txtName").val();
    var Customeraddress = $("#txtAddress").val();
    var customerissues = $("#txtIssues").val();
    var customersolutions = $("#txtsolutions").val();
    var customertokenno = $("#hidtokenNo").val();
    var service_sub_type_id = $('#service_sub_type_id').val();
    if (customertokenno == "") {
        ShowPannel(1);
        modalAlert("Please First Generate New Service No.....");
        return false;
    }

    if (service_sub_type_id == null || service_sub_type_id == "") {
        serviceDialog.dialog('open');
        return false;
    }
    else {
        modalConfirm("Do you want to finish current service?", AddServiceSave, IgnoreCurrentService)
    }



    

}

function IgnoreCurrentService() {
    serviceDialog.dialog('open');
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
    
    modalPrompt("Please enter token no which is not served yet or missed:", CallToken);
    
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
    

    modalPrompt("Please enter counter no where you transfer this token:", CounterTransfer);
    
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

            var select = $('#tablebody');
            for (var i = 0; i < response.Message.length; i++) {
                select.append($('<tr><td>' + response.Message[i].service_datetime_string + '</td><td>'
                    + response.Message[i].issues + '</td><td>'
                    + response.Message[i].solutions + '</td></tr>'));

                
            }

            historyDialog.dialog('open');


        }, error: function (XMLHttpRequest, textStatus, errorThrown) {
            modalAlert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }
    });

}


function SaveNext() {
    ShowPannel(2);
    var contactNo = $("#txtContact").val();
    var Customername = $("#txtName").val();
    var Customeraddress = $("#txtAddress").val();
    var customerissues = $("#txtIssues").val();
    var customersolutions = $("#txtsolutions").val();
    var customertokenno = $("#hidtokenNo").val();
    var service_sub_type_id = $('#service_sub_type_id').val();
    if (customertokenno == "") {
        ShowPannel(1);
        modalAlert("Please First Generate New Service No.....");
        return false;
    }

    if (service_sub_type_id == null || service_sub_type_id == "") {
        modalAlert("Please add a service.....");
        return false;
    }

    if (contactNo == "") {
        modalAlert("Please Enter Mobile No.....");
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
        "service_sub_type_id": service_sub_type_id
    }

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
            $("#txtServiceType").val('');
            $("#start_time").val('');
            $("#service_sub_type_name").val('');
            $("#service_sub_type_id").val('');

            NewServiceNo();
        }
    });

}




function TokenReInitiate(token_id) {
    $.ajax({
        url: '../TokenQueues/ReInitiate',
        type: 'POST',
        dataType: 'json',
        data: { token_id: token_id },
        success: function (data) {
            if (data.Success == true) {
                $("#data-skipped").find("#" + token_id).remove();
                modalAlert(data.Message);
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

function TokenAssignToMe(token_id) {
    $.ajax({
        url: '../TokenQueues/AssignToMe',
        type: 'POST',
        dataType: 'json',
        data: { token_id: token_id },
        success: function (data) {
            if (data.Success == true) {
                $("#data-skipped").find("#" + token_id).remove();
                modalAlert(data.Message);
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