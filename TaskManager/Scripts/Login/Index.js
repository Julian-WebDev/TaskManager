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
    });

    $('#user-form').submit(function (e) {
        e.preventDefault();
        const form = document.getElementById('user-form');

        const fd = new FormData(form);

        const data = Object.fromEntries(fd);

        $.ajax({
            url: controllerURL,
            type: 'POST',
            data: data,
            success: function (response) {
                //Here I use the server response
                if (response == 1) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Please fill the spaces with your information'
                    });
                }
                else if (response == 2) {
                    Swal.fire({
                        icon: 'success',
                        title: ':)',
                        text: 'User succesfully added',
                    });
                    displayLoginForm();
                } else if (response == 3) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops',
                        text: 'The user could no be added',
                    });
                }
                console.log(response);
            },
            error: function (error) {
                console.log(error);
            }
        });
    });
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

