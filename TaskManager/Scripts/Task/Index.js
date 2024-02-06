$(document).ready(function () {
    const table = $('#task_table').DataTable({
        ajax: {
            url: getURL,
            type: 'GET',
            datatype: 'json'
        },
        ordering: false,
        info: false,
        columns: [
            {
                'data': 'Id'
            },
            {
                'data': 'TaskSubject'
            },
            {
                'data': 'TaskDeadline'
            },
            {
                'data': 'TaskName'
            },
            {
                'data': 'Description'
            },
            {
                'data': null,
                'deafultContent': ''
            }
        ],
        columnDefs: [{
            //If want to send parameters by URL I can use the next line
            //href='../../Task/DeleteTask/${data.Id}'

            'targets': 5,
            //To render a button I have to use <a></a> tag, button tag doesnt works
            'render': function (data, type, row, meta) {
                return `
                        <a href='../../Task/EditTask/${data.Id}'><i class="fs-5 bi bi-pencil-square" style="color: #2D3436;"></i></a>
                        <a onclick="deleteTask(${data.Id})" class='ms-1'><i class="fs-5 bi bi-trash3-fill" style="color: #2D3436;"></i></a>
                        <a onclick='completed(${data.Id})' style="color: green;"><i class="fs-5 bi bi-check-circle-fill"></i></a>
                       `;
            }
        }]
    });
    $('#input_search').keyup(function () {
        table.search($(this).val()).draw();
    });
});


$('#btn_send_form').click(function (e) {
    e.preventDefault();
    const form = document.getElementById('task_form');
    const fd = new FormData(form);
    console.log(fd);

    /*
    const data = {
        subject = document.getElementById('subject')
        date = document.getElementById('date')
        name = document.getElementById('name')
        description = document.getElementById('description')
    }
    */

    const data = Object.fromEntries(fd);
    console.log(data);

    $.ajax({
        url: sendURL,
        type: 'POST',
        data: data,
        success: function (response) {
            //Here I use the server response
            if (response == 1) {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Please fill the spaces with your task information'
                });
            }
            else if (response == 2) {
                document.getElementById('staticBackdrop').setAttribute('aria-hidden', 'true');;
                Swal.fire({
                    icon: 'success',
                    title: ':)',
                    text: 'Task succesfully added',
                });
                $('#task_table').DataTable().ajax.reload();
                document.getElementById('task_form').reset();
            }
            console.log(response)
        },
        error: function (error) {
            console.log(error)
        }
    })

});

function deleteTask(id) {
    $.ajax({
        url: deleteURL,
        type: 'POST',
        data: {
            param: id
        },
        success: function (response) {
            //Here I use the server response
            if (response == 1) {
                Swal.fire({
                    icon: 'success',
                    title: '😁',
                    text: 'The task was succesfully deleted'
                });
                $('#task_table').DataTable().ajax.reload();
                document.getElementById('task_form').reset();
            }
            else if (response == 2) {
                document.getElementById('staticBackdrop').setAttribute('aria-hidden', 'true');;
                Swal.fire({
                    icon: 'error',
                    title: '😫',
                    text: 'The task could no be deleted',
                });
            }
            console.log(response)
        },
        error: function (error) {
            console.log(error)
        }
    });
}

function completed(id) {
    $.ajax({
        url: completeURL,
        type: 'POST',
        data: {
            param: id
        },
        success: function (response) {
            //Here I use the server response
            if (response == 1) {
                Swal.fire({
                    icon: 'success',
                    title: '😁',
                    text: 'Congrats! Task completed'
                });
                $('#task_table').DataTable().ajax.reload();
                document.getElementById('task_form').reset();
            }
            else if (response == 2) {
                document.getElementById('staticBackdrop').setAttribute('aria-hidden', 'true');;
                Swal.fire({
                    icon: 'error',
                    title: '😫',
                    text: 'Oops, something happend, try again.',
                });
            }
            console.log(response)
        },
        error: function (error) {
            console.log(error)
        }
    });
}