/*
author:               wang song hua
email:                 songhuaxiaobao@163.com
url:                      http://www.netstudio80.com
namespace:      Song.Fmt
content:            一些数据的格式化处理
beforeLoad:     j,base
dateUpdated:  2012-03-14
*/
; (function (song, j) {
      Date.prototype.f = function (mask) {

                var d = this;

                var zeroize = function (value, length) {

                    if (!length) length = 2;

                    value = String(value);

                    for (var i = 0, zeros = ''; i < (length - value.length); i++) {

                        zeros += '0';

                    }

                    return zeros + value;

                };

                return mask.replace(/"[^"]*"|'[^']*'|\b(?:d{1,4}|m{1,4}|yy(?:yy)?|([hHMstT])\1?|[lLZ])\b/g, function ($0) {

                    switch ($0) {

                        case 'd': return d.getDate();

                        case 'dd': return zeroize(d.getDate());

                        case 'ddd': return ['Sun', 'Mon', 'Tue', 'Wed', 'Thr', 'Fri', 'Sat'][d.getDay()];

                        case 'dddd': return ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'][d.getDay()];

                        case 'M': return d.getMonth() + 1;

                        case 'MM': return zeroize(d.getMonth() + 1);

                        case 'MMM': return ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'][d.getMonth()];

                        case 'MMMM': return ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'][d.getMonth()];

                        case 'yy': return String(d.getFullYear()).substr(2);

                        case 'yyyy': return d.getFullYear();

                        case 'h': return d.getHours() % 12 || 12;

                        case 'hh': return zeroize(d.getHours() % 12 || 12);

                        case 'H': return d.getHours();

                        case 'HH': return zeroize(d.getHours());

                        case 'm': return d.getMinutes();

                        case 'mm': return zeroize(d.getMinutes());

                        case 's': return d.getSeconds();

                        case 'ss': return zeroize(d.getSeconds());

                        case 'l': return zeroize(d.getMilliseconds(), 3);

                        case 'L': var m = d.getMilliseconds();

                            if (m > 99) m = Math.round(m / 10);

                            return zeroize(m);

                        case 'tt': return d.getHours() < 12 ? 'am' : 'pm';

                        case 'TT': return d.getHours() < 12 ? 'AM' : 'PM';

                        case 'Z': return d.toUTCString().match(/[A-Z]+$/);

                            // Return quoted strings with the surrounding quotes removed     

                        default: return $0.substr(1, $0.length - 2);

                    }

                });

            };
    song.fmt = {
        //千分位符
        fixMoney: function (value) {
            return value.toString().replace(/(\d{1,3})(?=(\d{3})+(?:$|\.))/g, "$1,");
        },
        //转化json中的日期为可辨别日期
        jsonDate:function(date,format){
            return new Date(eval(date.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).format(format);
        },
        fileSize :(function(info){
            return function(bytes){
                var i = 0;
                while(1023 < bytes){
                    bytes /= 1024;
                    ++i;
                };
                return  (i ? bytes.toFixed(2) : bytes) + info[i];
            };
        })([" Bytes", " KB", " MB", " GB", " TB"]),
        usMoney : function(v) {
			v = (Math.round((v - 0) * 100)) / 100;
			v = (v == Math.floor(v)) ? v + ".00" : ((v * 10 == Math
					.floor(v * 10)) ? v + "0" : v);
			v = String(v);
			var ps = v.split('.');
			var whole = ps[0];
			var sub = ps[1] ? '.' + ps[1] : '.00';
			var r = /(\d+)(\d{3})/;
			while (r.test(whole)) {
				whole = whole.replace(r, '$1' + ',' + '$2');
			}
			v = whole + sub;
			if (v.charAt(0) == '-') {
				return '-$' + v.substr(1);
			}
			return "$" + v;
		},
        dateDiff: function (biggerDate, smallerDate) {
            var intervalSeconds = parseInt((biggerDate - smallerDate) / 1000);
            if (intervalSeconds < 60) {
                return intervalSeconds + "秒";
            }
            else if (intervalSeconds < 60 * 60) {
                return Math.floor(intervalSeconds / 60) + "分钟";
            }
            else if (intervalSeconds < 60 * 60 * 24) {
                return Math.floor(intervalSeconds / (60 * 60)) + "小时";
            }
            else if (intervalSeconds < 60 * 60 * 24 * 7) {
                return Math.floor(intervalSeconds / (60 * 60 * 24)) + "天";
            }
            else if (intervalSeconds < 60 * 60 * 24 * 31) {
                return Math.floor(intervalSeconds / (60 * 60 * 24 * 7)) + "周";
            }
            else if (intervalSeconds < 60 * 60 * 24 * 365) {
                return Math.floor(intervalSeconds / (60 * 60 * 24 * 30)) + "月";
            }
            else if (intervalSeconds < 60 * 60 * 24 * 365 * 1000) {
                return Math.floor(intervalSeconds / (60 * 60 * 24 * 365)) + "年";
            }
            else {
                return Math.floor(intervalSeconds / (60 * 60 * 24)) + "天";
            }
        },
        dateInterval: function (biggerDate, smallerDate) {
            var intervalSeconds = parseInt((biggerDate - smallerDate) / 1000),
                day = Math.floor(intervalSeconds / (60 * 60 * 24)),
                hour = Math.floor((intervalSeconds - day * 24 * 60 * 60) / 3600),
                minute = Math.floor((intervalSeconds - day * 24 * 60 * 60 - hour * 3600) / 60),
                second = Math.floor(intervalSeconds - day * 24 * 60 * 60 - hour * 3600 - minute * 60);
            return day + "天:" + hour + "小时:" + minute + "分钟:" + second + "秒";
        },
        replaceURLWithHTMLLinks: function (sText, bBlank) {
            var pattern = /(\b(https?|ftp|file):\/\/[-A-Z0-9+&@#\/%?=~_|!:,.;]*[-A-Z0-9+&@#\/%=~_|])/ig;
            if (bBlank) {
                sText = sText.replace(pattern, "<a target='_blank' href='$1'>$1</a>");
            }
            else {
                sText = sText.replace(pattern, "<a href='$1'>$1</a>");
            }
            return sText;
        },
        //获取字节长度
        getLength: function (sVal, bChineseDouble) {
            var chineseRegex = /[\u4e00-\u9fa5]/g;
            if (bChineseDouble != undefined && bChineseDouble === false) {
                return sVal.length;
            }
            else {
                if (chineseRegex.test(sVal)) {
                    return sVal.replace(chineseRegex, "zz").length;
                }
                return sVal.length;
            }
        }
    }
})(window.song,window.jQuery);