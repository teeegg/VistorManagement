// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    SetActiveNav();

})


function SetActiveNav() {
    var path = window.location.pathname.split('/')[1];

    console.log(path);
    
    $('.nav-link.active').removeClass('active');
    if (path == "")
        $('.nav-link[href="/"]').addClass('active');
    else if (path == 'Home')
        $('.nav-link[href="/Home/VisitorStatistics"]').addClass('active');
    else {
        path = "/" + path;
        $('.nav-link[href="' + path + '"]').addClass('active');
    }
}

function FilterByBuilding(select) {
    var id = $(select).val();
    console.log(id);
    $.post('/Hosts/FilterByBuidingId', { id: id })
        .done(function (data) {
            $('main').html();
            $('main').html(data);
        });
}

function FilterByCampus(select) {
    var id = $(select).val();
    console.log(id);
    $.post('/Hosts/FilterByCampusId', { id: id })
        .done(function (data) {
            $('main').html();
            $('main').html(data);
        });
}