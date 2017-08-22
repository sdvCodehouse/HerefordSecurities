$(function () {

    $("textarea").each(function () {
        $(this).css("height", "auto").css("height", this.scrollHeight + this.offsetHeight);
    });

});