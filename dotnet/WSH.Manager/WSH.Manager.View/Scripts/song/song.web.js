/*
author:               wang song hua
email:                 songhuaxiaobao@163.com
url:                      http://www.netstudio80.com
namespace:      Song.Web
content:            网站应用相关
beforeLoad:     j,base
dateUpdated:  2012-03-14
*/
; (function (song,j) { 
    //跑马灯滚动
    song.marquee=function(el,direction, spe){
        spe = spe ? spe : 20;
        var d1 = el, obj = this;
        var d2 = d1.childNodes[0];
        var d3 = d1.childNodes[1];

        d3.innerHTML = d2.innerHTML;
        inter = setInterval(function() {
            obj.run(direction);
        }, spe);
        d1.onmouseover = function() {
            clearInterval(inter);
        }
        d1.onmouseout = function() {
            inter = setInterval(function() {
                obj.run(direction);
            }, spe);
        }
        this.run = function() {
            if (direction == "up") {
                if (d3.offsetTop - d1.scrollTop <= 0) d1.scrollTop -= d2.offsetHeight;
                else d1.scrollTop++;
            }
            else if (direction == "down") {
                if (d2.offsetTop - d1.scrollTop >= 0) d1.scrollTop += d2.offsetHeight;
                else d1.scrollTop--;
            }
            else if (direction == "left") {
                if (d3.offsetWidth - d1.scrollLeft <= 0) d1.scrollLeft -= d2.offsetWidth;
                else d1.scrollLeft++;
            }
            else if (direction == "right") {
                if (d1.scrollLeft <= 0) d1.scrollLeft += d3.offsetWidth;
                else d1.scrollLeft--;
            }
        }
    };
    song.scale=function(el,maxWidth,maxHeight){
        el=j(el);
        var w=~~el.width(),h=~~el.height();
        if(w/h >= maxWidth/maxHeight){
            if(w>maxWidth){
                w=maxWidth;
                h=h*maxWidth/w;
            } 
            if(h>maxHeight){
                h=maxHeight;
                w=w*maxWidth/h;
            }
            el.width(w).height(h);
        }
    };
    song.imgCenter=function(el,maxWidth,maxHeight){
        
    }
})(window.song,window.jQuery);