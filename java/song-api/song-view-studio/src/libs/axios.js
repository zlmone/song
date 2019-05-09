import axios from 'axios'
import store from '@/store'
import { Spin } from 'iview'
const addErrorLog = errorInfo => {
  const { statusText, status, request: { responseURL } } = errorInfo
  let info = {
    type: 'ajax',
    code: status,
    mes: statusText,
    url: responseURL
  }
  if (!responseURL.includes('save_error_logger')) store.dispatch('addErrorLog', info)
}

class HttpRequest {
  constructor (baseUrl = baseURL) {
    this.baseUrl = baseUrl
    this.queue = {}
  }
  getInsideConfig () {
    const config = {
      baseURL: this.baseUrl,
      withCredentials: true,
      headers: {
        "Content-Type": "application/x-www-form-urlencoded"
      }
    }
    return config
  }
  destroy (url) {
    delete this.queue[url]
    if (!Object.keys(this.queue).length) {
       Spin.hide()
    }
  }
  interceptors (instance, url) {
    // 请求拦截
    instance.interceptors.request.use(config => {
      // 添加全局的loading...
      if (!Object.keys(this.queue).length) {
         Spin.show() // 不建议开启，因为界面不友好
      }
      this.queue[url] = true
      return config
    }, error => {
      return Promise.reject(error)
    })
    // 响应拦截
    instance.interceptors.response.use(res => {
      this.destroy(url)
 
      const { data, status } = res
      let success=false;
      if(data.data && data.data.success){
        success=true;
        
      }
      console.log(data);
      let successData=data.data==null ? null : data.data;
      return successData;
    }, error => {
      this.destroy(url)
      let errorInfo = error.response
      if (!errorInfo) {
        const { request: { statusText, status }, config } = JSON.parse(JSON.stringify(error))
        errorInfo = {
          statusText,
          status,
          request: { responseURL: config.url }
        }
      }
      addErrorLog(errorInfo)
      return Promise.reject(error)
    })
  }
  request (options={}) {
    const instance = axios.create({withCredentials:true})
    options = Object.assign(this.getInsideConfig(), options)
    this.interceptors(instance, options.url)
    return instance(options)
  }
  post(url,data,options={}){
    options.method="POST";
    options.url=url;
    options.data=data;
    return this.request(options);
  }
  delete(url,params,options={}){
    options.method="DELETE";
    options.url=url;
    options.params=params;
    return this.request(options);
  }
  put(url,data,options={}){
    options.method="PUT";
    options.url=url;
    options.data=data;
    return this.request(options);
  }
  get(url,params,options={}){
    options.method="GET";
    options.url=url;
    options.params=params;
    return this.request(options);
  }
  postJSON(url,data,options={}){
    options.url=url;
    if(data){
      options.data=JSON.stringify(data);
    }
    if(!options.headers){
      options.headers={};
    }
    options.headers["Content-Type"]="application/json";
    return this.post(options);
  }
}
export default HttpRequest
