$(document).ready(function () {
    $('#tablebody').empty();
    $("#historyDiv").hide();
    NewServiceNo();
})


function loadServices(services) {
    //service_sub_type_id
    $('#service_sub_type_id').empty();
    $.each(services, function (index, service) {
        $('#service_sub_type_id').append($('<option>').text(service.Text).attr('value', service.Value));
    });
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
                    $("#txtName").val(data.Message.customer_name);
                    $("#txtAddress").val(data.Message.address);
                    //GetCustomerInformation(); // 2018-07-20
                } else {
                    $("#txtContact").prop('disabled', false);
                    $("#txtName").val("");
                    $("#txtAddress").val("");
                }

            
                loadServices(data.Services);
            } else {
                alert(data.Message);
            }


        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }

    });
}

function AddService() {
    var contactNo = $("#txtContact").val();
    var Customername = $("#txtName").val();
    var Customeraddress = $("#txtAddress").val();
    var customerissues = $("#txtIssues").val();
    var customersolutions = $("#txtsolutions").val();
    var customertokenno = $("#hidtokenNo").val();
    if (customertokenno == "") {
        alert("Please First Generate New Service No.....");
        return false;
    }
    if (contactNo == "") {
        alert("Please Enter Mobile No.....");
        return false;
    }

    if (Customername == "") {
        alert("Please Enter Customer Name....");
        return false;
    }

    if (Customeraddress == "") {
        alert("Please Enter Address.....");
        return false;
    }

    if (customerissues == "") {
        alert("Please Enter Issues.....");
        return false;
    }
    if (customersolutions == "") {
        alert("Please Enter Solutions.....");
        return false;
    }

    if (confirm("Current service will finish and next service will start automatically for this customer. Do you want to continue?")) {


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

                $("#txtIssues").val('');
                $("#txtsolutions").val('');
                $("#start_time").val(getCurrentDate());


            }
        });
    }

}

function ManualCall() {
    var token = $("#hidtokenNo").val();
    if (token != '') {
        alert("First, finish the current service");
        return;
    }
    $('#tablebody').empty();
    $("#historyDiv").hide();

    var token_no = prompt("Please enter token no which is not served yet or skipped:", "");
    if (token_no == null || token_no == "") {
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
                    $("#txtName").val(data.Message.customer_name);
                    $("#txtAddress").val(data.Message.address);
                    //GetCustomerInformation(); // 2018-07-20
                } else {
                    $("#txtContact").prop('disabled', false);
                    $("#txtName").val("");
                    $("#txtAddress").val("");
                }


                loadServices(data.Services);
            } else {
                alert(data.Message);
            }


        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }

    });
}


function Cancel() {

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
            $("#txtServiceType").val('');
            $("#start_time").val('');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }
    });
} function Transfer() {

    $('#tablebody').empty();
    $("#historyDiv").hide();

    var counter_no = prompt("Please enter counter no where you transfer the token:", "");
    if (counter_no == null || counter_no == "") {
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
                
                if (confirm(data.Message + ", Do you want to call new token for service?")) {
                    NewServiceNo();
                }
            } else {
                alert(data.Message);
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }
    });
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
            alert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
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
            alert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
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
            alert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
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
                alert(data.Message);
            }


        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
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
            alert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
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
        alert("Please First Generate New Service No.....");
        return false;
    }
    if (contactNo == "") {
        alert("Please Enter Mobile No.....");
        return false;
    }

    if (Customername == "") {
        alert("Please Enter Customer Name....");
        return false;
    }

    if (Customeraddress == "") {
        alert("Please Enter Address.....");
        return false;
    }

    if (customerissues == "") {
        alert("Please Enter Issues.....");
        return false;
    }
    if (customersolutions == "") {
        alert("Please Enter Solutions.....");
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
        alert("Please First Generate New Service No.....");
        return false;
    }
    if (contactNo == "") {
        alert("Please Enter Mobile No.....");
        return false;
    }

    if (Customername == "") {
        alert("Please Enter Customer Name....");
        return false;
    }

    if (Customeraddress == "") {
        alert("Please Enter Address.....");
        return false;
    }

    if (customerissues == "") {
        alert("Please Enter Issues.....");
        return false;
    }
    if (customersolutions == "") {
        alert("Please Enter Solutions.....");
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
    //    alert('Please type Mobile no');
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



