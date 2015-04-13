
var modalOperations = {
    init: function (ajaxResultHeight) {
        var isOpera = !!window.opera || navigator.userAgent.indexOf(' OPR/') >= 0;
        var isChrome = !!window.chrome && !isOpera;
        var isSafari = Object.prototype.toString.call(window.HTMLElement).indexOf('Constructor') > 0;

        if (!ajaxResultHeight) {
            ajaxResultHeight = 0;
        }
        if ($("body").height() + ajaxResultHeight <= $(window).height() || !(isChrome || isSafari)) {
            $('body').addClass('modal-no-scroll');
            $('.navbar-fixed-top').addClass('modal-no-scroll');
        }
        else {
            $('body').removeClass('modal-no-scroll');
            $('.navbar-fixed-top').removeClass('modal-no-scroll');
        }
    },

    modalDelete: function (modalCallerSelector, firstText, secondText) {
        $('#btnDelete').click(function () {
            $('#myModalDelete').modal('toggle');
            $('#deleteForm').submit();
        });

        if (!modalCallerSelector) {
            throw new Error('Specify element to call modal window')
        }

        $(modalCallerSelector).click(function () {
            var id = $(this).data('id');
            var name = $(this).data('name') || "";
            firstText = firstText || "";
            secondText = secondText || "";
            var text = firstText + name + secondText;
            $('[name=id]').val(id);
            $('#question').text(text);

            $('#myModalDelete').modal('toggle');

            $('#myModalDelete').on('hidden.bs.modal', function () {
                $('a.text-danger').css('color', '#ee5f5b');
            });
        });
    },

    modalShowImage: function (modalCallerSelector) {

        if (!modalCallerSelector) {
            throw new Error('Specify element to call modal window')
        }

        $('#myModal').on('shown.bs.modal', function () {
            $('.close').focus();
        });

        $(modalCallerSelector).click(function () {
            var $that = $(this);
            var src = $that.attr('src');
            var alt = $that.attr('alt');
            $('.modal-body img').attr('src', src).attr('alt', alt);
            $('#myModalLabel').text(alt);
            $('#myModal').modal('toggle');
        })
    }
};