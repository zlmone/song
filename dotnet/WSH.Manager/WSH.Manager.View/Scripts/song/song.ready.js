/*
author:                 wang song hua
email:                  songhuaxiaobao@163.com
url:                    http://www.netstudio80.com
namespace:              document.ready
content:                domready
beforeLoad:             
dateUpdated:            2012-08-29
*/
; (function () { 
    var readyList = [],
        _binded = false,
        _domReady = function(){
			try{
				document.documentElement.doScroll("left");
				_ready();
			}catch(ex){
				setTimeout(_domReady,1);
				return;
			}
		},
        _ready = function(){
			while(readyList.length > 0){
				(readyList.shift())();
			}
			if(document.removeEventListener){
				document.removeEventListener("DOMContentLoaded",_ready,false);
			}
		};
    document.ready = function(func){
		if(document.readyState === "complete"){
			return setTimeout(func,1);
		}
		readyList.push(func);
		if(document.addEventListener && !_binded){
			document.addEventListener("DOMContentLoaded",_ready,false);
			_binded = true;
			return;
		}
		_domReady();
	}
})();