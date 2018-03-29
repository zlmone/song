 

    /** 
     * 转换&取整 
     */  
    -45.67890^0 //-45  
    -45.67890|0 //-45   
    ~~5645.1132 //5645  
    '-45.67890'^0 //-45  
    '-45.67890'|0 //-45   
    ~~'5645.1132' //5645  
  
    var a = [1,2,3];  
    var b = [4,5,6];  
    Array.prototype.push.apply(a, b);  
    eval(a); //[1,2,3,4,5,6]  
      
    /** 
     *指定位置合并 
     */   
    var a = [1,2,3,7,8,9];  
    var b = [4,5,6];  
    a.splice.apply(a, Array.concat(3, 0, b));  
 
    var a=function(v1){  
                this.v1=v1  
                this.test=function(){  
                    alert(this.v1)  
                }  
            }  
            var b=function(){  
            }  
            b.prototype=new a('12312')  
            var b1=new b('tttt')  
            b1.test()  
      
              function classA(t){  
              this.t=t  
              this.sayArg=function(){  
                alert(this.t)  
              }  
           }  
           function classB(tt){  
            this.extend=classA  
            this.extend(tt)  
            delete this.extend  
           }  
           var b2=new classB('test')  
           b2.sayArg()  
             
              function classC(cc){  
             this.c=cc  
             this.sayC=function(){  
                alert(this.c)  
             }  
           }  
           function classD(cc){  
                classC.call(this,cc)  
                 classC.apply(this,[cc])  
           }  
           var d =new classD('dddddd')  
           d.sayC()  
 
    /** 
     *随机数 
     */  
    Math.random().toString(16).substring(2); //14位  
    Math.random().toString(36).substring(2); //11位  
      
    /** 
     *赋值处理 
     */  
    a= [b, b=a][0];//交换值  
 
    var date = +new Date; //转为日期的数值  
 