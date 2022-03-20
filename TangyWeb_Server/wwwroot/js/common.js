window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, 'Успешная операция', 5000)
    }
    if (type === "error") {
        toastr.error(message, 'Операция неудачна', 5000 )
    }
}


window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Уведомление об успехе!',
            message,
            'success'
        )
    }
    if (type === "error") {
        Swal.fire(
            'Уведомление о НЕ успехе!',
            message,
            'error'
        )
    }
}

function ShowDeleteConfirmationModal()
{
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}