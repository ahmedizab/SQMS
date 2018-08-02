﻿var bgColors = [
    'rgba(255,99,132,1)',
    'rgba(54, 162, 235, 1)',
    'rgba(255, 206, 86, 1)',
    'rgba(75, 192, 192, 1)',
    'rgba(153, 102, 255, 1)',
    'rgba(255, 159, 64, 1)'
];

var branches = [];
var services = [];
var tokens = [];

$(document).ready(function () {
    loadData();
});

function loadData() {
    $.ajax({
        url: '../ApiService/GetAdminDashboard',
        type: 'POST',
        dataType: 'json',
        success: function (result) {
            $.each(result.data, function (i, data) {
                branches.push(data.branch_name);
                tokens.push(data.tokens);
                services.push(data.services);
            });
            generateTokenChart();
            generateServiceChart();
        }
    });
}

function generateTokenChart() {
    var ctx = document.getElementById("serviceChart").getContext('2d');

    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: branches,
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
            "labels": branches,
            "datasets": [{
                "label": "Branch wise Services",
                "data": services,
                "backgroundColor": bgColors
            }]
        }
    });
}

