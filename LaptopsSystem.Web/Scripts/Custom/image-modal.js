
$(function () {
    $('.img-laptop').click(function () {
        console.log($(this));
        var $that = $(this);
        var src = $($that).attr('src');
        var alt = $($that).attr('alt');
        $('.modal-body img').attr('src', src).attr('alt', alt);
        $('#myModalLabel').text(alt);
        $('#myModal').modal('toggle');
    })
})