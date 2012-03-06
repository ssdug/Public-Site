$(function() {
    $(".hero-unit:first").fadeIn(500);

    $(".hero-unit .btn").click(function() {
        
        var $visibleItem = $('div.hero-unit:visible');
        var total = $('div.hero-unit').length;
        var index = $visibleItem.prevAll().length;

        //if we click next increment current index, else decrease index (we aren't using a previous button)
        $(this).attr('id') === 'Next' ? index++ : index--;

        //if we are now past the beginning or end show the last or first item
        if (index === -1) {
            index = total - 1;
        }
        if (index === total) {
            index = 0;
        }

        $visibleItem.hide();

        $('div.hero-unit:eq(' + index + ')').fadeIn(500);

        return false;
    });
});

$(function() {
  $('.slideshow').cycle({
    fx: 'fade'
  });
});

