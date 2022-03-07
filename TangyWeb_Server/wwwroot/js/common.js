window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, 'Успешная операция', 5000)
    }
    if (type === "error") {
        toastr.error(message, 'Операция неудачна', 5000 )
    }

}