function showSuccessMessage(message) {
    if (message !== '') {
        Swal.fire({
            icon: 'success',
            title: message,
            showConfirmButton: false,
            timer: 1500
        });
    }
}

function showErrorMessage() {
    Swal.fire({
        icon: 'error',
        title: 'Error',
        showConfirmButton: false,
        timer: 1500
    });
}

$(document).ready(function () {
    var message = $('#Message').text();
    showSuccessMessage(message);
});