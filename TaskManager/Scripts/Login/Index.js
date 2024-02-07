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
});

function displayUserForm() {
    var loginForm = document.getElementById('login-form');
    loginForm.classList.add('d-none');

    var userForm = document.getElementById('user-form');
    userForm.classList.remove('d-none');
}

function displayLoginForm() {
    var loginForm = document.getElementById('login-form');
    loginForm.classList.remove('d-none');

    var userForm = document.getElementById('user-form');
    userForm.classList.add('d-none');
}