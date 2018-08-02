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