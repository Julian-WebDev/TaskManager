$(document).ready(function () {
    $('#login-form').submit(function (e) {
        e.preventDefault();

        parameters = $(this).serialize();

        $.post(path, parameters, function (data) {
            if (data == '1') {
                document.location.href = URL;
            }
            else {
                alert(data);
            }
        })
    })
})