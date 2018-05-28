/**
 * Created by 王松华 on 2018/3/15.
 */
(function (cmp, $) {
    cmp.yearmonth = cmp.create({
        init: function () {
            var that=this;
            var options={
                editable:false,
                onShowPanel: function () {
                    var p = that.el.datebox('panel'), //日期选择对象
                        tds = false, //日期选择对象中月份
                        span = p.find('span.calendar-text'); //显示月份层的触发控件
                    //触发click事件弹出月份层
                    span.trigger('click');
                    if (!tds)
                    //延时触发获取月份对象，因为上面的事件触发和对象生成有时间间隔
                        setTimeout(function() {
                            tds = p.find('div.calendar-menu-month-inner td');
                            tds.click(function(e) {
                                //禁止冒泡执行easyui给月份绑定的事件
                                e.stopPropagation();
                                //得到年份
                                var year = /\d{4}/.exec(span.html())[0] ,
                                    //月份
                                    //之前是这样的month = parseInt($(this).attr('abbr'), 10) + 1;
                                    month = parseInt($(this).attr('abbr'), 10);

                                //隐藏日期对象
                                that.el.datebox('hidePanel')
                                //设置日期的值
                                    .datebox('setValue', year + '-' + month);
                            });
                        }, 0);
                },
                //配置parser，返回选择的日期
                parser: function (s) {
                    if (!s) return new Date();
                    var arr = s.split('-');
                    return new Date(parseInt(arr[0], 10), parseInt(arr[1], 10) - 1, 1);
                },
                //配置formatter，只返回年月 之前是这样的d.getFullYear() + '-' +(d.getMonth());
                formatter: function (d) {
                    var currentMonth = (d.getMonth()+1);
                    var currentMonthStr = currentMonth < 10 ? ('0' + currentMonth) : (currentMonth + '');
                    return d.getFullYear() + '-' + currentMonthStr;
                }
            };
            var isWidth = that.el.attr("width");
            if (isWidth){
                options.width=isWidth;
            }
            this.el.datebox(options);
        },
        getValue: function () {
            return this.el.datebox("getValue");
        }
    });
})(window.cmp, window.jQuery);

