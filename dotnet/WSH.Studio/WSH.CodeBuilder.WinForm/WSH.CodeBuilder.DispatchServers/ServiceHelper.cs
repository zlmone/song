using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.Common.Configuration;

namespace WSH.CodeBuilder.DispatchServers
{
    public class ServiceHelper
    {
        /// <summary>
        /// 获取服务地址
        /// </summary>
        public static string CodeBuilderServicesUrl
        {
            get
            {
                AppSetting setting = new AppSetting();
                string url = setting.GetValue("CodeBuilderServiceUrl");
                if (string.IsNullOrEmpty(url))
                {
                    url = "http://192.168.100.158:81/CodeBuilderService.svc/CodeBuilderService";
                }
                return url;
            }
        }
        /// <summary>
        /// 获取使用说明文档的地址
        /// </summary>
        public static string CodeBuilderInstructionUrl
        {
            get
            {
                Uri uri = new Uri(CodeBuilderServicesUrl);
                string path = uri.PathAndQuery;
                string url = CodeBuilderServicesUrl.Replace(path,"/") + "Template/instruction.htm";
                return url;
            }
        }
        /// <summary>
        /// 获取服务对象
        /// </summary>
        private static CodeBuilderService CodeBuilderServiceInstance;
        public static CodeBuilderService GetCodeBuilderService()
        {
            if (CodeBuilderServiceInstance == null)
            {
                CodeBuilderServiceInstance = new CodeBuilderService();
                CodeBuilderServiceInstance.Url = CodeBuilderServicesUrl;
            }
            return CodeBuilderServiceInstance;
        }
    }
}
