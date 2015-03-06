
$(function () {
    $('#model').val('').autocomplete({
        minlength: 1,
        source: "/ajax/search",
        select: function (event, ui) {
            var model = ui.item.value;
            window.location.replace('/Home/Details/' + model);
        }
    });

    $('#slider').slider({
        animate: 'fast',
        max: 10000,
        min: 0,
        step: 100,
        range: true,
        values: [1000, 5000],
        slide: function (event, ui) {
            $('#from').val(ui.values[0]);
            $('#to').val(ui.values[1]);
        }
    });

    $('#slider').slider('values', 0, $('#from').val());
    $('#slider').slider('values', 1, $('#to').val());
});