
$(function () {

    if ($("body").height() <= $(window).height()) {
        $('body').addClass('modal-no-scroll');
        $('.navbar-fixed-top').addClass('modal-no-scroll');
    }

    $('.delete').click(function () {
        var btn = $(this);
        var id = btn.data('id');
        var name = btn.data('name');
        var text = 'Are you sure to delete manufacturer ' + name + ' with all its models ?';
        $('[name=id]').val(id);
        $('#question').text(text);

        $('#myModalDelete').modal('toggle');
    });



    $('#btnDelete').click(function () {
        $('#myModalDelete').modal('toggle');
        $('#deleteForm').submit();
    });
});