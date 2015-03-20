
var modalOperations = {
    init: function () {
        if ($("body").height() <= $(window).height()) {
            $('body').addClass('modal-no-scroll');
            $('.navbar-fixed-top').addClass('modal-no-scroll');
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
        });
    },

    modalShowImage: function (modalCallerSelector) {

        if (!modalCallerSelector) {
            throw new Error('Specify element to call modal window')
        }

        $(modalCallerSelector).click(function () {
            var $that = $(this);
            var src = $($that).attr('src');
            var alt = $($that).attr('alt');
            $('.modal-body img').attr('src', src).attr('alt', alt);
            $('#myModalLabel').text(alt);
            $('#myModal').modal('toggle');
        })
    }
};