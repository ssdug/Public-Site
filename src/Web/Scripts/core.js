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
                var login_button = $('#js-login-btn');

                FB.getLoginStatus(function (response) {
                    if (response.status === 'connected') {
                        var accessToken = response.authResponse.accessToken;
                        loginUser(accessToken);
                    } else {
                        login_button.on('click', function (e) {
                            e.preventDefault();
                            FB.login(function (response) {
                                FB.api('/me', onSuccess);
                            });
                        });
                    }
                });

                function loginUser(accessToken) {
                    $.ajax({
                        type: 'post',
                        dataType: 'json',
                        url: '/session/create',
                        data: {
                            facebookToken: accessToken
                        },
                        success: onSuccess,
                        error: onError
                    });
                }

                function onSuccess(user) {
                    login_button.text(user.name);
                }

                function onError() {

                }
            });
        });


    });