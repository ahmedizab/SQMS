var dialogBox, dialogBody, inputBox, serviceDialog, breakDialog, missingListDialog, historyDialog;

$(document).ready(function () {
    dialogBox = $("#dialog-message");
    dialogBody = dialogBox.find("#body");
    
    inputBox = '<br/><input type="text" id="inputBox" placeholder="XXXXXXX" />'

    modalServiceTypeCreate(AddServiceCall);
    modalBreakCreate(breakAdd);
    modalHistoryCreate();
    modalMissingListCreate();
})

function modalAlert(msg){
    dialogBody.html(msg);
    dialogBox.dialog({
        resizable: false,
        modal: true,
        closeOnEscape: true,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });
}

function modalHistoryCreate() {
    historyDialog=
        $("#div-history").dialog({
        autoOpen: false,
        resizable: false,
        modal: true,
        height: 500,
        width: 700,
        closeOnEscape: true,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });
}

function modalConfirm(msg, callback, cancelCallBack) {
    dialogBody.html(msg);
    $("#dialog-message").dialog({
        autoOpen: true,
        resizable: false,
        modal: true,
        closeOnEscape: false,
        buttons: {
            "Yes": function () {
                $(this).dialog("close");
                callback();
            },
            "No": function () {
                $(this).dialog("close");
                if (cancelCallBack != null) {
                    cancelCallBack();
                }
            }
        }
    });
}

function modalPrompt(msg, callback) {

    dialogBody.html(msg + inputBox);
    
    $("#dialog-message").dialog({
        autoOpen: true,
        resizable: false,
        modal: true,
        height: "auto",
        width: "auto",
        closeOnEscape: false,
        buttons: {
            "Ok": function () {
                var value = dialogBody.find("#inputBox").val();
                if (value == null || value == "") {
                    //modalAlert("Please input a value then press Ok or press Cancel");
                    return;
                }
                
                $(this).dialog("close");
                callback(value);
            },
            "Cancel": function () {
                $(this).dialog("close");
                //callback("close");
            }
        }
    });
}



function modalServiceTypeCreate(callback) {

     serviceDialog=

     $("#div-services").dialog({
        autoOpen: false,
        resizable: false,
        modal: true,
        height: 400,
        width: 800,
        closeOnEscape: false,
        buttons: {
            "Ok": function () {
                var value = $("input[name=radio-service]:checked").val();
                var text = $("input[name=radio-service]:checked").next('label').text();
                var max_duration = $("input[name=radio-service]:checked").next('label').attr('max_duration');
                
                if (value == null || value == "") {
                    modalAlert("Please select a service then press Ok or press Cancel");
                    return;
                }

                $(this).dialog("close");
                callback(value, text, max_duration);
                
            },
            "Cancel": function () {
                $(this).dialog("close");
                //callback("close");
            }
        }
        });

    
}


function modalBreakCreate(callback) {
    breakDialog =

        $("#dialog-url-break").dialog({
            autoOpen: false,
            resizable: false,
            modal: true,
            title: 'Take a break',
            height: 'auto',
            width: 650,
            closeOnEscape: false,
            buttons: {
                "Ok": function () {
                    var break_type_id = $("#dialog-url-break").find("#break_type_id").val();
                    var remarks = $("#dialog-url-break").find("#remarks").val();
                    callback(break_type_id, remarks);
                    $(this).dialog("close");
                },
                "Cancel": function () {
                    $(this).dialog("close");
                    //callback("close");
                }
            }
        });
}

function loadBreakDialog() {
    breakDialog.load("../DailyBreaks/Create", function () {
        breakDialog.dialog('open');
    });

}

function modalMissingListCreate() {
    missingListDialog =

        $("#dialog-url-skipped").dialog({
            autoOpen: false,
            resizable: false,
            modal: true,
            title: 'Customer Missing List',
            height: 600,
            width: 950,
            closeOnEscape: true,
            buttons: {
                Ok: function () {
                    $(this).dialog("close");
                }
            }
        });
}

function loadMissingListDialog() {
    missingListDialog.load("../TokenQueues/Skipped", function () {
        missingListDialog.dialog('open');
    });

}
