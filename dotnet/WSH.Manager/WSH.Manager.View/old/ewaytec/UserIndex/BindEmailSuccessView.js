/*
author:         wang song hua
createDate:     2013-4-25
content:        绑定邮箱成功页面
*/
define(function (require, exports, model) {
    var $ = require('jquery');
    var Backbone = require('backbone');
    var ens = require('ens');
    var tpl = require('templateLoad');
    var layoutView = require('~/Scripts/src/View/Shared/LayoutView.js');
    var emailView = require('~/Scripts/src/View/UserIndex/BindEmailView.js');

    var BindEmailSuccess = Backbone.View.extend({
        initialize: function () {
            new layoutView();
            $("#jsHome").html(tpl.get("UserIndex/BindEmailSuccess"));
            this.setText();
            var email = new emailView({ el: $("#jsHome"), email: this.options.email });
            $("#jsBindNewEmail").click(function () {
                email.open();
            });
        },
        setText: function () {
            $("#jsBindEmailText").html(this.options.email);
        }
    });

    return {
        BindEmailSuccess: BindEmailSuccess
    };
});