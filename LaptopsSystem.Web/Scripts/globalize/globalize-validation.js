$(function () {

    //var currentculture = $("meta[name='accept-language']").prop("content");
    var currentculture = $('html').prop('lang');

    // set globalize to the current culture driven by the meta tag (if any)
    if (currentculture) {
        Globalize.culture(currentculture);
    }

    //fix the range to use globalized methods
    jQuery.extend(jQuery.validator.methods, {
        date: function (value, element) {
            if (Globalize.parseDate(value)) {
                return true;
            }
            return false;
        },
        range: function (value, element, param) {
            //use the globalization plugin to parse the value
            var val = Globalize.parseFloat(value);
            return this.optional(element) || (val >= param[0] && val <= param[1]);
        },
        number: function (value, element) {
            if (!value) {
                return this.optional(element);
            }
            try {
                var val = Globalize.parseFloat(value);
                return val;
            } catch (e) {
                return value;
            }
        }

    });

});