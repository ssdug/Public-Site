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
                FB.getLoginStatus( function (response) {
                    if (response.status === 'connected') {
                        var uid = response.authResponse.userID;
                        var accessToken = response.authResponse.accessToken;
                        console.log("Connected as " + uid + " with access token " + accessToken);
                    } else if (response.status === 'not_authorized') {
                        console.log("The user is logged into Facebook but app is not authorized");
                    } else {
                        console.log("The user is not logged into Facebook.");
                    }

                });

            });
        });
    });