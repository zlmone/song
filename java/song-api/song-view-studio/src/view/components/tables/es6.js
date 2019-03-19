//-------------------------对象--------------------------------
let bar = { a: 1, b: 2 };//浅拷贝
let baz = { ...bar }; // { a: 1, b: 2 }
let baz = Object.assign({}, bar); // { a: 1, b: 2 }
//判断属性是否存在对象
var obj = {name:'jack'};
alert('name' in obj); // --> true
alert('toString' in obj); // --> true
var obj = {name:'jack'};
obj.hasOwnProperty('name'); // --> true
obj.hasOwnProperty('toString'); // --> false

//-------------------------数组-------------------------------
const args = [...arguments];//参数转数组
const rest=[1,2,3];
const arr=[4,5,...rest];//数组赋值和合并

//-------------------------异步编程-------------------------------
const getJSON = function(url) {
    const promise = new Promise(function(resolve, reject){
      const handler = function() {
        if (this.readyState !== 4) {
          return;
        }
        if (this.status === 200) {
          resolve(this.response);
        } else {
          reject(new Error(this.statusText));
        }
      };
      const client = new XMLHttpRequest();
      client.open("GET", url);
      client.onreadystatechange = handler;
      client.responseType = "json";
      client.setRequestHeader("Accept", "application/json");
      client.send();
    });
    return promise;
  };
  
  getJSON("/posts.json").then(rsp=>{

  }).catch(err=>{

  });

//-------------------------对象-------------------------------
const foo = Object.freeze({});//冻结对象，后续无法赋值新属性

//-------------------------代理（拦截对象，监控属性变化，实例可作为其他对象原型）-------------------------------
var proxy = new Proxy({}, {
    get: function(target, property) {
      return 35;
    }
  });

  proxy.time // 35
  proxy.name // 35
  proxy.title // 35
  //-------------------------遍历器-------------------------------
  let arr=[1,2,3];
  for(let i of arr){
      console.log(i);
  }
  