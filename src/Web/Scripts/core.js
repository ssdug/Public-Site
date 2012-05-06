require.config({
    baseUrl: '/Scripts/',
    paths: {
        bootstrap: 'bootstrap'// Omitted the .js as requireJs will add it automagically
        // And so on for other frameworks/utils
    }
});

define(
    'core',
    [
        'jquery',
        'bootstrap'
    ],
    function ($) {
        // jQuery and bootstrap have been loaded
        return $;
    });

    require(['core', 'facebook'], function ($, facebook) {
        $(function () {
            facebook.setup();
            facebook.ready(function () {
                FB.getLoginStatus(function() {
                    console.log('something happened');
                });
            });
        });
    });