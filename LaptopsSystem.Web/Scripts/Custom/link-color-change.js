function LinkColorChange() {
    $('a.text-success').on('click', function () {
        $(this).css('color', 'forestgreen');
    });

    $('a.text-danger').on('click', function () {
        $(this).css('color', 'red');
    });

    $('a.text-info').on('click', function () {
        $(this).css('color', 'aqua');
    });
}