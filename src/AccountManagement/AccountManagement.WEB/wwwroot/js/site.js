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

$(function(){
    $('#utcDate').each(function () {
        var localDate = new Date(parseInt($(this).attr('#utcDate')));
        $(this).html(localDate.toLocaleDateString()+" "+localDate.toLocaleTimeString())
    });
});
