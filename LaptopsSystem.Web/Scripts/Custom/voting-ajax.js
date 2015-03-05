$(function () {
    $('#voteButton').click(function () {
        var $that = $(this);
        var id = $('#Id').val();
        $.ajax({
            url: '/ajax/vote',
            type: 'POST',
            data: { id: id },
            success: function (data) {
                if (data.message == 'Success') {
                    var votes = parseInt($('#votes').text());
                    $('#votes').text(votes + 1);
                    $that.removeClass().addClass('btn btn-default disabled btn-xs');
                    var span = $that.children('span')[0];
                    $(span).removeClass().addClass('glyphicon glyphicon-remove-sign');
                }
                else {
                    $('#ajaxResult').text(data.message);
                }
            }
        });
        return false;
    });
});