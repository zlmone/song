$.extend($.fn.validatebox.defaults.rules, {
    chs: {
        validator: function (value, param) {
            return /^[\u0391-\uFFE5]+$/.test(value);
        },
        message: '请输入汉字'
    },
    zip: {
        validator: function (value, param) {
            return /^[1-9]\d{5}$/.test(value);
        },
        message: '邮政编码不正确'
    },
    qq: {
        validator: function (value, param) {
            return /^[1-9]\d{4,15}$/.test(value);
        },
        message: 'QQ号码不正确'
    },
    mobile: {
        validator: function (value, param) {
            return /^((\(\d{2,3}\))|(\d{3}\-))?1[3|4|8|9|5|6]\d{9}$/.test(value);
        },
        message: '手机号码不正确'
    },
    englisthOrNumberChar: {
        validator: function (value, param) {
            return /^[A-Za-z0-9]+$/.test(value);
        },
        message: '只能输入由数字和26个英文字母组成的字符串'
    },
    onlyBigEnglisthChar: {
        validator: function (value, param) {
            return /^[A-Z]+$/.test(value);
        },
        message: '只能输入大写英文字母组成的字符串'
    },
    safepass: {
        validator: function (value, param) {
            return safePassword(value);
        },
        message: '密码由字母和数字组成，至少6位'
    },
    equal: {
        validator: function (value, param) {
            return value == $(param[0]).val();
        },
        message: '两次输入的字符不一至'
    },
    number: {
        validator: function (value, param) {
            return /^\d+$/.test(value);
        },
        message: '请输入数字'
    },
    englishchar: {
        validator: function (value, param) {
            return /^[a-zA-Z][a-zA-Z0-9_]{1,20}$/.test(value);
        },
        message: '必须以字母开头，且长度在2-20之间，允许字母数字下划线'
    },
    chars: {
        validator: function (value, param) {
            return /^^\w+$/.test(value);
        },
        message: '只能输入由数字、英文字母、下划线组成的字符串'
    },
    positive: {
        validator: function (value, param) {
            return /^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$/.test(value);
        },
        message: '请输入正确的正浮点数'
    },
    biggerZero: {
        validator: function (value, param) {
            return !isNaN(value) && value > 0;
        },
        message: '请输入大于0的数'
    },
    biggerOrEqualZero: {
        validator: function (value, param) {
                return !isNaN(value)&&value >= 0;
        },
        message: '请输入大于或等于0的数字'
    },
    litterOrEqualZero: {
        validator: function (value, param) {
            return !isNaN(value) && value <= 0;
        },
        message: '请输入小于或等于0的数字'
    },
    floatNumber: {
        validator: function (value, param) {
            return !isNaN(value);
        },
        message: '请输入数字'
    },
    idcard: {
        validator: function (value, param) {
            return !/(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/.test(value);
        },
        message: '请输入正确的身份证号码'
    },
    password: {
        validator: function (value, param) {
            return !(/^(([A-Z]*|[a-z]*|\d*|[-_\~!@#\$%\^&\*\.\(\)\[\]\{\}<>\?\\\/\'\"]*)|.{0,5})$|\s/.test(value));
        },
        message: '密码必须包含数字、字母或符号，至少6位'
    }

});

