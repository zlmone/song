using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Services.Common
{
    public enum ResponseType { 
        Success=0,
        Fail=1,
        AllSuccess=2,
        AllFail=3,
        PartSuccess=4
    }
    /*
     * 应答报文
     */
    public class ResponseMessage
    {
        //<response>
        //    <header>
        //        <rsptype></rsptype>
        //        <rspcode></rspcode>
        //        <rspmsg></rspmsg>
        //    </header>
        //    <body>
        //        <!--应答报文-->
        //    </body>
        //</response>
        public ResponseHeader Header { get; set; }
        public ResponseBody Body { get; set; }
    }
    public class ResponseHeader
    {
        public ResponseType RspType { get; set; }
        /// <summary>
        /// 响应的业务编码
        /// </summary>
        public string RspCode { get; set; }
        public string RspMsg { get; set; }
    }
    public class ResponseBody
    {

    }
}
