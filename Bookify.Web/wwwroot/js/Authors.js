
//using datatable plugin
var myTable = $('#myTable').DataTable();

$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var itemId = $(this).data('id');
        currentElement = this;
        bootbox.confirm({
            message: 'Are you sure?',
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result) {
                    $.ajax({
                        method: 'POST',
                        url: '/Authors/Delete/' + itemId,
                        data: {
                            '__RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
                        },
                        success: function () {
                            //$('#' + itemId).parents('.js-row').html('');
                            //location.reload();
                            Swal.fire({
                                icon: 'success',
                                title: "The Data Was Deleted",
                                showConfirmButton: false,
                                timer: 1500
                            })
                                //delete data from body
                                .then(function () {
                                    console.log($(currentElement).parents('tr'));

                                    //to remove data if you dont use datatable
                                    // $(currentElement).parents('tr').remove();

                                    //to remove data from datatable if dont use this when delete item and
                                    //  search in it you will find it
                                    myTable.row($(currentElement).parents('tr'))
                                        .remove()
                                        .draw();
                                });
                        },
                        error: function () {
                            showErrorMessage();
                        }
                    });
                }
            }
        });
    });
});