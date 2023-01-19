// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('#checkAllUsers').click(function() {
        $('input[type=checkbox]', "#usersTable").prop('checked', $(this).prop('checked'));
    });
    $('input[type=checkbox]', "#usersTable").click(function() {
        if (!$(this).prop('checked')) {
            $('#checkAllUsers').prop('checked', false);
        }
    });
});

$('#utcDateTime').each(function () {
    var utcTime = $(this).html() + "Z";
    var date = new Date(utcTime);
    $(this).html(date.toLocaleString());
})
