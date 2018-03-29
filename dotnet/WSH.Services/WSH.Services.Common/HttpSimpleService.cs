using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.Common.Http;
using WSH.Options.Common;
using WSH.Common;
using WSH.Common.Helper;

namespace WSH.Services.Common
{
    public enum ServiceDataType
    {
        XML,
        JSON
    }
    public class HttpSimpleService
    {
        public const string SUCCESSDEFAULTCODE = "00";
        public const string FAILDEFAULTCODE = "99";
        public HttpSimpleService() { }
        public HttpSimpleService(string url) {
            this.Url = url;
        }
        /// <summary>
        /// 请求的服务地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 报文加密秘钥
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// 报文传输的数据格式
        /// </summary>
        public ServiceDataType DataType { get; set; }
        private bool isEncrypt = true;
        /// <summary>
        /// 是否进行报文加密加密
        /// </summary>
        public bool IsEncrypt
        {
            get { return isEncrypt; }
            set { isEncrypt = value; }
        }
        private bool isValidIP = false;
        /// <summary>
        /// 是否验证IP地址
        /// </summary>
        public bool IsValidIP
        {
            get { return isValidIP; }
            set { isValidIP = value; }
        }
        private bool isValidXsd = false;
        /// <summary>
        /// 是否开启Xsd校验
        /// </summary>
        public bool IsValidXsd
        {
            get { return isValidXsd; }
            set { isValidXsd = value; }
        }
        #region 公有方法
        public ResponseMessage Request(RequestMessage request)
        {
            //验证参数属性
            try
            {
                ValidParamters(request);
                HttpSimpleRequest req = new HttpSimpleRequest(Url);
                req.Method = RequestMethod.POST;
                //解析报文参数
                req.ParamterContent = ParseRequestMessage(request);
                //请求接口服务
                Result result = req.Request();
                //解析应答内容
                return ParseResponseMessage(result);
            }
            catch (Exception ex)
            {
                return GetFailResponseMessage(new ResponseHeader()
                {
                    RspMsg = ex.Message
                });
            }
        }
        public ResponseMessage GetFailResponseMessage(ResponseHeader header)
        {
            var rsp = new ResponseMessage();
             
            header.RspType = ResponseType.AllFail;
            if (string.IsNullOrWhiteSpace(header.RspCode))
            {
                header.RspCode = FAILDEFAULTCODE;
            }
            rsp.Header = header;
            return rsp;
        }
        #endregion
        private bool ValidParamters(RequestMessage request)
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(Url))
            {
                result = false;
                throw new DataValidException("接口地址不能为空");
            }
            if (IsEncrypt && string.IsNullOrWhiteSpace(SecretKey))
            {
                result = false;
                throw new DataValidException("指定报文需要加解密，秘钥不能为空");
            }
            string msg;
            if (!ValidRequestMessage(request, out msg))
            {
                result = false;
                throw new DataValidException(msg);
            }
            return result;
        }
        /// <summary>
        /// 验证报文
        /// </summary>
        /// <param name="request"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private bool ValidRequestMessage(RequestMessage request, out string msg)
        {
            bool result = true;
            msg = null;
            return result;
        }
        /// <summary>
        /// 解析请求参数
        /// </summary>
        /// <returns></returns>
        private string ParseRequestMessage(RequestMessage request)
        {
            string paramters = null;
            switch (DataType)
            {
                case ServiceDataType.JSON:
                    break;
                default:
                    XmlSerializeHelper<RequestMessage> serialize = new XmlSerializeHelper<RequestMessage>();
                    paramters = serialize.ParseString(request);
                    break;
            }
            //判断是否需要 加解密
            if (!string.IsNullOrWhiteSpace(paramters) && IsEncrypt)
            {
                return WSH.Common.Helper.CryptHelper.EncryptDES(paramters, SecretKey);
            }
            return paramters;
        }
        private ResponseMessage ParseResponseMessage(Result result)
        {
            ResponseMessage rsp = new ResponseMessage();
            ResponseHeader header = new ResponseHeader()
            {
                RspType = ResponseType.Success,
                RspCode = SUCCESSDEFAULTCODE,
                RspMsg = "请求成功"
            };
            if (!result.IsSuccess)
            {
                //请求失败，请检查网络
                header.RspType = ResponseType.Fail;
                header.RspCode = FAILDEFAULTCODE;
                header.RspMsg = "请求失败";
            }
            if (!string.IsNullOrWhiteSpace(result.Msg))
            {
                //请求成功，相应失败
                header.RspType = ResponseType.Fail;
                header.RspCode = FAILDEFAULTCODE;
                header.RspMsg = "请求成功，应答失败";
            }
            if (IsEncrypt)
            {
                result.Msg = WSH.Common.Helper.CryptHelper.DecryptDES(result.Msg, SecretKey);
            }
            
            header.RspMsg = result.Msg;
            switch (DataType)
            {
                case ServiceDataType.JSON:
                    break;
                default:
                    //XmlSerializeHelper<ResponseMessage> serialize = new XmlSerializeHelper<ResponseMessage>();
                    //rsp = serialize.ReadEntity();
                    break;
            }
            rsp.Header = header;
            return rsp;
        }
    }
}
