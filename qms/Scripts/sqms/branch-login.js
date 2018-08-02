$(document).ready(function () {
    var selectedBranch = $("#branch_name option:selected").text();
    var selectedVal = @ViewBag.userBranchId;
    $('#counter_no').empty();
    $.ajax({
        url: "../../Home/GetCounterByBranchId",
        type: "GET",
        dataType: "json",
        data: { branchId: selectedVal },
        success: function (data) {
            // alert(response);
            // debugger;
            //$.each(data, function (key, value) {
            //    $('#counter_no').append($("<option></option>").attr("value", counter_id).text(counter_no));
            //});
            if (data.data.length > 0) {
                $('#counter_no').append($("<option value=''>Select a Counter</option>"));

                for (var i = 0; i < data.data.length; i++) {
                    $('#counter_no').append($("<option></option>").attr("value", data.data[i].counter_id).text(data.data[i].counter_no));
                }
            } else {
                $('#counter_no').append($("<option value=''>No Counter Found!!!</option>"));
            }
        },
        error: function (response) {
            alert(response);
        }
    });
    $("#branch_name").attr('disabled', true);
});