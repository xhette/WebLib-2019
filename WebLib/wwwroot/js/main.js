$(document).ready(function() {
    $(".arrow-down").click(function() {
        $('html').animate({
            scrollTop: $(window).height()
          }, 500);
    });
});
    