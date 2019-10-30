$(document).ready(function () {
    $(document).on("click", ".tcModalButton", function () {
        var url = $(this).data("url");
        var title = $(this).data("title");

        $("#mdlModal .modal-title").html(title);
        $("#mdlModal .modal-body").load(url);
    });
});