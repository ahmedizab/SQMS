var dialogBox, dialogBody, inputBox, serviceDialog, breakDialog;

$(document).ready(function () {
    dialogBox = $("#dialog-message");
    dialogBody = dialogBox.find("#body");
    
    inputBox = '<br/><input type="text" id="inputBox" placeholder="XXXXXXX" />'

    modalServiceTypeCreate();
    modalBreakCreate(breakAdd);
})

function modalAlert(msg){
    dialogBody.html(msg);
    dialogBox.dialog({
        resizable: false,
        modal: true,
        closeOnEscape: false,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });
}

function modalConfirm(msg, callback) {
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
                //callback("close");
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



function modalServiceTypeCreate() {

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
                $(this).dialog("close");
                //callback(dialogBody.find("#inputBox").val());
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

        $("#dialog-url").dialog({
            autoOpen: false,
            resizable: false,
            modal: true,
            title: 'Take a break',
            height: 'auto',
            width: 650,
            closeOnEscape: false,
            buttons: {
                "Ok": function () {
                    var break_type_id = $("#dialog-url").find("#break_type_id").val();
                    var remarks = $("#dialog-url").find("#remarks").val();
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
    breakDialog.load(webRootAddtionalPath + "/DailyBreaks/Create", function () {
        breakDialog.dialog('open');
    });

}