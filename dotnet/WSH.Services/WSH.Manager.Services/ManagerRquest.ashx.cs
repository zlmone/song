using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSH.Services.Common;
using WSH.Common.Helper;

namespace WSH.Manager.Services
{
    /// <summary>
    /// ManagerRquest 的摘要说明
    /// </summary>
    public class ManagerRquest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            RequestMessage request = new RequestMessage();
            request.Header = new RequestHeader()
            {
                Domain = "EC",
                BIPCode = "EC0001",
                Token = "211fsfds=",
                UniqueID = StringHelper.GuidNonSplit
            };
            request.Body = new RequestBody() { 
                 
            };
            HttpSimpleService service = new HttpSimpleService("http://localhost:14538/ManagerResponse.ashx");
            service.SecretKey = CryptHelper.DefaultKey;
            ResponseMessage rsp= service.Request(request);
            string msg = rsp.Header.RspMsg;
            msg=FormatHelper.FormatXml(msg, false);
            context.Response.Write(msg);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}