// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// $('#checkAllUsers').click(function () {
//     var chk = $(this).is(':checked');
//     var cnt = $('input[type=checkbox]', "#usersTable").length;
//     $('input[type=checkbox]', "#usersTable").each(function () {
//         if (chk) {
//             $(this).attr('checked','checked');
//         }
//         else {
//             $(this).removeAttr('checked');
//         }
//     });
// });

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
