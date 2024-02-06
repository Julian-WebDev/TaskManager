$(document).ready(function () {
    const table = $('#completed_tasks').DataTable({
        ajax: {
            url: getCompletedTasks,
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
            'targets': 5,
            //To render a button I have to use <a></a> tag, button tag doesnt works
            'render': function (data, type, row, meta) {
                return `
                        <a onclick="deleteTask(${data.Id})" class='ms-1'><i class="fs-5 bi bi-trash3-fill" style="color: #2D3436;"></i></a>
                        <a onclick="incompleted(${data.Id})"><i class="fs-5 bi bi-file-arrow-up-fill" style="color: red;"></i></a>
                       `;
            }
        }]
    });
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
                $('#completed_tasks').DataTable().ajax.reload();
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

function incompleted(id) {
    $.ajax({
        url: incompleteURL,
        type: 'POST',
        data: {
            param: id
        },
        success: function (response) {
            //Here I use the server response
            if (response == 1) {
                Swal.fire({
                    icon: 'success',
                    title: 'Nice',
                    text: 'Task status updated'
                });
                $('#completed_tasks').DataTable().ajax.reload();
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