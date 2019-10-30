$(document).ready(function () {
    $(document).on("click", ".tcModalButton", function () {
        var url = $(this).data("url");
        var title = $(this).data("title");

        $("#mdlModal .modal-title").html(title);
        $("#mdlModal .modal-body").load(url, function () {
            //re-init unobtrusive validation for dynamic content
            var form = $("#mdlModal form")
                .removeData("validator") /* added by the raw jquery.validate plugin */
                .removeData("unobtrusiveValidation");  /* added by the jquery unobtrusive plugin*/
            $.validator.unobtrusive.parse(form);
        });
    });
});