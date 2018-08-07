/*
            window.addEventListener('load', function(){
                var newVideo = document.getElementById('myVideo');
                newVideo.addEventListener('ended', function() {
                    this.currentTime = 0;
                    this.play();
                }, false);

                newVideo.play();

            });
        */



function toggleFullScreen(elem) {
    // ## The below if statement seems to work better ## if ((document.fullScreenElement && document.fullScreenElement !== null) || (document.msfullscreenElement && document.msfullscreenElement !== null) || (!document.mozFullScreen && !document.webkitIsFullScreen)) {
    if ((document.fullScreenElement !== undefined && document.fullScreenElement === null) || (document.msFullscreenElement !== undefined && document.msFullscreenElement === null) || (document.mozFullScreen !== undefined && !document.mozFullScreen) || (document.webkitIsFullScreen !== undefined && !document.webkitIsFullScreen)) {
        if (elem.requestFullScreen) {
            elem.requestFullScreen();
        } else if (elem.mozRequestFullScreen) {
            elem.mozRequestFullScreen();
        } else if (elem.webkitRequestFullScreen) {
            elem.webkitRequestFullScreen(Element.ALLOW_KEYBOARD_INPUT);
        } else if (elem.msRequestFullscreen) {
            elem.msRequestFullscreen();
        }
    } else {
        if (document.cancelFullScreen) {
            document.cancelFullScreen();
        } else if (document.mozCancelFullScreen) {
            document.mozCancelFullScreen();
        } else if (document.webkitCancelFullScreen) {
            document.webkitCancelFullScreen();
        } else if (document.msExitFullscreen) {
            document.msExitFullscreen();
        }
    }
}





var vid = document.getElementById("myVideo");
vid.addEventListener('ended', videoEndHandler, false);
function videoEndHandler(e) {
    vid.load();
    vid.mute();
    vid.play();
}

$(function () {
    $.support.cors = true;
    // Declare a proxy to reference the hub.
    //var connection = $.hubConnection("http://114.31.10.21:9078/signalr", { useDefaultPath: false });
    var notifications = $.connection.notifyDisplay;
    //$.connection.hub.url = "http://114.31.10.21:9078/signalr";
    //debugger;
    // Create a function that the hub can call to broadcast messages.
    notifications.client.updateMessages = function (text, branch_id) {
        getAllMessages();
        if (text.length > 0 && $('#branch_id').val() == branch_id) textToTalk(text);
    };
    // Start the connection.
    $.connection.hub.start().done(function () {
        getAllMessages();
        welComeSpeech();
    }).fail(function (e) {
        alert(e);
    });

    /*
                        setTimeout(function(){
                            vid.load();
                            vid.mute();    
                            vid.play();
                        }, 1000); //5 second timeout in milliseconds
    */
});

vid.onpause = function () {
    vid.load();
    vid.mute();
    vid.play();
}

function welComeSpeech() {
    var text = $('#welcome').val();

    responsiveVoice.setDefaultVoice("US English Female");
    responsiveVoice.speak(text);

    /*var text = $('#welcome').val();

    $.ajax({
        url: webRootAddtionalPath + "/Counters/display",
        type: 'POST',
        dataType: "json",
        data: { text: text },
        success: function (data) {
            var audio = new Audio('../Voices/Welcome.mp3');
            audio.play();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + ": " + textStatus + ": " + errorThrown, 'Error!!!');
        }
    });
    */
}

function textToTalk(text) {
    /*var branch_id = $('#branch_id').val();
    var audio = new Audio('../Voices/' + branch_id + '.mp3');
    audio.play();
    */
    responsiveVoice.setDefaultVoice("US English Female");
    responsiveVoice.speak(text);
}


function getAllMessages() {
    var branch_id = $('#branch_id').val();
    $.ajax({
        url: '../Counters/GetDisplayInfo?branch_id=' + branch_id,
        //contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        //dataType: 'html'
    }).success(function (result) {
        if (result.success == "true") {
            $("#divCurrentTokens").empty();
            var row = '<div class="col-sm-6 bg-color-head"><h2 onclick="return toggleFullScreen(document.body);" style="text-align:center">Counter</h2></div><div class="col-sm-6 bg-color-head"><h2 style="text-align:center">Token</h2></div>';
            $('#divCurrentTokens').append(row);
            $.each(result.tokenInProgress, function (key, token) {
                row = '<div class="col-sm-6 bg-color"><h1>' + token.counter_no + '</h1></div><div class="col-sm-6 bg-color"><h1>' + token.token_no + '</h1></div>';
                $('#divCurrentTokens').append(row);
            });

            $("#nextToken").text('Next Token: ' + result.nextTokens);
        }
        else {
            alert(result.errorMsg);
        }
    }).error(function () {
        alert("Error");
    });
}
