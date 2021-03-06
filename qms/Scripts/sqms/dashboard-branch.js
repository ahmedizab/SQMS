﻿var bgColors = [
    'rgba(255,99,132,1)',
    'rgba(54, 162, 235, 1)',
    'rgba(255, 206, 86, 1)',
    'rgba(75, 192, 192, 1)',
    'rgba(153, 102, 255, 1)',
    'rgba(255, 159, 64, 1)'
];

var counters = [];
var services = [];
var tokens = [];
var status_names = [];
var status_tokens = [];

$(document).ready(function () {
    loadData();
});

function loadData() {
    $.ajax({
        url: '../ApiService/GetBranchAdminDashboard',
        type: 'POST',
        dataType: 'json',
        success: function (result) {
            $.each(result.data, function (i, data) {
                counters.push(data.counter_no);
                tokens.push(data.tokens);
                services.push(data.services);
            });

            $.each(result.statusData, function (i, data) {
                status_names.push(data.service_status);
                status_tokens.push(data.tokens);
            });

            generateTokenChart();
            generateServiceChart();
            generateStatusChart();
        }
    });
}

function generateTokenChart() {
    var ctx = document.getElementById("serviceChart").getContext('2d');

    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: counters,
            datasets: [{
                label: 'Tokens',
                data: tokens,
                backgroundColor: bgColors,
                borderColor: bgColors,
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}

function generateServiceChart() {
    new Chart(document.getElementById("tokenChart"), {
        "type": "doughnut",
        "data": {
            "labels": counters,
            "datasets": [{
                "label": "Branch wise Services",
                "data": services,
                "backgroundColor": bgColors
            }]
        }
    });
}

function generateStatusChart() {
    new Chart(document.getElementById("statusChart"), {
        "type": "pie",
        "data": {
            "labels": status_names,
            "datasets": [{
                "label": "Branch wise Services",
                "data": status_tokens,
                "backgroundColor": bgColors
            }]
        }
    });
}