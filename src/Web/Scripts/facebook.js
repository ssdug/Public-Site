define(['core'], function ($) {
    var onReadyQueue = [];

    var facebook = {};

    facebook.options = {
        appId: "188145164542799",
        cookie: true,
        status: true,
        xfbml: true,
        oauth: true,
        reloadIfSessionStateChanged: true
    };

    facebook.ready = function (callback) {
        if (typeof callback != 'function') {
            throw new Error('callback must be a function');
        }
        onReadyQueue.push(callback);
    };

    facebook.setup = function (cfg) {
        $.extend(facebook.options, cfg);

        facebook.ready(function () {
            FB.init(facebook.options);
        });

        window.fbAsyncInit = function () {
            for (var i = 0, l = onReadyQueue.length; i < l; i += 1) {
                onReadyQueue[i]();
            }

            facebook.ready = function (callback) {
                if (typeof callback != 'function') {
                    throw new Error('callback must be a function');
                }
                callback();
            };
        };

        if (typeof FB === 'object') {
            window.fbAsyncInit();
        } else {
            var e = document.createElement('script'); e.async = true;
            e.src = document.location.protocol + '//connect.facebook.net/en_US/all.js';
            document.getElementById('fb-root').appendChild(e);
        }

        return this;
    };

    facebook.reparse = function (scope) {
        facebook.ready(function () {
            FB.XFBML.parse(scope);
        });
    };

    return facebook;
});