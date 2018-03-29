/*
content:        下拉加载数据插件
beforeload:     jquery
createdate:     2013-06-27
*/
window.scrollView = function (options) {
    //设置对象参数
    $.extend(this,options);
    this.init();
}
window.scrollView.prototype = {
    theRequest: false,          //表示是否正在加载
    isFinish: false,            //表示是否加载完毕
    pageSize: 15,               //页大小，默认每页15条记录
    pageIndex: 1,               //当前页码，默认第一页
    pageCount: 1,               //总页数，默认第一页
    scrollElement: $(window),   //滚动条所属的元素，默认window滚动条
    init: function () {
        this.bindScroll();
    },
    getPosition: function () {
        //获取页面高度，和包含滚动条的页面高度
        var de = document.documentElement,
            dd=document.body,
            h = de.clientHeight || dd.clientHeight,
            maxh = de.scrollHeight || dd.scrollHeight;
        return {
            client: { height: h },
            maxClient: { height: maxh }
        }
    },
    bindScroll: function () {
        var win = $(window),
            that = this;
        //绑定滚动加载事件
        that.scrollElement.bind("scroll", function () {
            //判断如果到了最后一页，拖动滚动条不加载数据
            if (that.isFinish) {
                return false;
            }
            //如果正在请求则不加载
            if (!that.theRequest) {
                var top = that.scrollElement.scrollTop(),
                pos = that.getPosition(),
                client = pos.client,
                maxClient = pos.maxClient;
                //如果滚动到了下边界则加载数据
                if ((client.height + top) == maxClient.height) {
                    //记录异步加载数据之前的滚动条位置
                    that.oldTop = top;
                    //每次滚动加载，则页码加1
                    that.pageIndex++;
                    that.request();
                }
            }
        });
    },
    setPageInfo: function (data) {
        //设置分页信息，计算页码和页数
        this.totalRecord = data.TotalRecord;
        if (!this.totalRecord) {
            this.isFinish = true;
        } else {
            this.pageCount = this.totalRecord < this.pageSize ? 1 : Math.ceil(this.totalRecord / this.pageSize);
            //判断如果是最后一页，则不加载数据
            if (this.pageIndex >= this.pageCount) {
                this.isFinish = true;
            }
        }
    },
    query: function () {
        //每次点击查询，将页数重置为第一页
        this.pageIndex = 1;
        this.theRequest = false;
        this.isFinish = false;
        this.request();
    },
    request: function () {
        if (!this.theRequest && !this.isFinish) {
            //表示当前已经在请求数据，防止重复请求
            this.theRequest = true;
            //执行搜索前的事件
            this.beforeLoad && this.beforeLoad(this.isFinish);
            //如果当前正在请求，则不加载数据
            var url = this.url,
                params = this.setParams ? this.setParams() : {},
                that = this;
            $.ajax({
                type: "get",
                dataType: "json",
                url: url,
                data: params,
                success: function (result) {
                    if (result) {
                        that.setPageInfo(result);
                        //调用页面渲染函数
                        that.render && that.render(result);
                        //绑定页面列表之后，将滚动条设置到最初浏览的位置
                        //that.scrollElement.scrollTop(that.oldTop+20);
                    } else {
                        //表示加载数据完毕
                        that.isFinish = true;
                    }
                    //请求完毕
                    that.theRequest = false;
                    //执行搜索后的事件
                    that.afterLoad && that.afterLoad(that.isFinish);
                },
                error: function (xhr, err) {
                    that.theRequest = false;
                    //执行搜索后的事件
                    that.afterLoad && that.afterLoad(that.isFinish);
                }
            });
        }
    }
}