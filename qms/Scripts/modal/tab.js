var tabs = $("#div-tab-main").tabs();
$('#div-tab-main-1 button').click(function () {
    tabs.tabs('add', '/url_for_tab/', 'New tab');
});