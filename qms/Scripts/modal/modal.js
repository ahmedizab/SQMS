var dialogBox, dialogBody, inputBox;

$(document).ready(function () {
    dialogBox = $("#dialog-message");
    dialogBody = dialogBox.find("#body");
    
    inputBox = '<br/><input type="text" id="inputBox" placeholder="XXXXXXX" />'
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
                $(this).dialog("close");
                callback(dialogBody.find("#inputBox").val());
            },
            "Cancel": function () {
                $(this).dialog("close");
                //callback("close");
            }
        }
    });
}

