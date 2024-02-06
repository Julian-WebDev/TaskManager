$('#btn_send_form').click(function (e) {
    e.preventDefault();
    const form = document.getElementById('update_form');
    const fd = new FormData(form);
    console.log(fd);

    const data = Object.fromEntries(fd);
    console.log(data);

    $.ajax({
        url: updateURL,
        type: 'POST',
        data: data,
        success: function (response) {
            //Here I use the server response
            if (response == 1) {
                Swal.fire({
                    icon: 'success',
                    title: 'Nice',
                    text: 'Task updated correctly'
                });
            }
            else if (response == 2) {
                Swal.fire({
                    icon: 'error',
                    title: 'D:',
                    text: 'The task information could not be updated',
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