(function ($) {
  $(".hero-unit:first").fadeIn(500);

  $(".hero-unit .btn").click(function (e) {

    //prevent browser jumping to top
    e.preventDefault();

    //get current visible item
    var $visibleItem = $('div.hero-unit:visible');

    //get total item count
    var total = $('div.hero-unit').length;

    //get index of current visible item
    var index = $visibleItem.prevAll().length;

    //if we click next increment current index, else decrease index (we aren't using a previous button)
    $(this).attr('id') === 'Next' ? index++ : index--;

    //if we are now past the beginning or end show the last or first item
    if (index === -1) {
      index = total - 1;
    }
    if (index === total) {
      index = 0
    }

    //hide current show item
    $visibleItem.hide();

    //fade in the relevant item
    $('div.hero-unit:eq(' + index + ')').fadeIn(500);

  });



})(jQuery);

$(document).ready(function () {
  $('.slideshow').cycle({
    fx: 'fade'
  });
});

