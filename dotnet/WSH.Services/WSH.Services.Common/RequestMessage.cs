using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Services.Common
{
    public class RequestMessage
    {
        //<request>
        //    <header>
        //        <domain>网元</domain>
        //        <bipcode>业务编码</bipcode>
        //        <token>秘钥标识</token>
        //        <uniqueid>唯一的流水号</uniqueid>
        //    </header>
        //    <body>
        //        <!--应答报文-->
        //    </body>
        //</request>
        public RequestHeader Header { get; set; }
        public RequestBody Body { get; set; }
    }
    public class RequestHeader {
        public string Domain { get; set; }
        public string BIPCode { get; set; }
        public string Token { get; set; }
        public string UniqueID { get; set; }
    }
    public class RequestBody { 
        
    }
}
