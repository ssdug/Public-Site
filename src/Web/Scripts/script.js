(function ($) {
  $(".hero-unit:first").show();

  $(".hero-unit .btn").click(function (e) {

    e.preventDefault();
  });

})(jQuery);

$(document).ready(function () {
  $('.slideshow').cycle({
    fx: 'fade'
  });
});