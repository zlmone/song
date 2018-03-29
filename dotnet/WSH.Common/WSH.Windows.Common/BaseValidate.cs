using System;
using System.Collections.Generic;
 
using System.Text;

namespace WSH.Windows.Common
{
    public enum ValidatorType{
        Required,Url,CardID,Email,QQ,En,Cn,IP,Alpha,Zip,Tel,Mobile,Int,Float
    }
    public class BaseValidate
    {
        public BaseValidate() { }
        private Dictionary<string, string> requiredList = new Dictionary<string, string>();
        private Dictionary<string, string> regexList = new Dictionary<string, string>();
        public string GetRegex(ValidatorType type){
            string regex=null;
            return regex;
        }
        public BaseValidate AddRequired(string value, string msg)
        {
            this.requiredList.Add(msg, value);
            return this;
        }
        public BaseValidate Add(ValidatorType type, string value, string msg)
        {
            if (type == ValidatorType.Required)
            {
                return this.AddRequired(value,msg);
            }
            else { 
                //正则表达式验证。。。。
            }
            return this;
        }
        public string CheckRequired() {
            string msg = "";
            foreach (string key in requiredList.Keys)
            {
                if (string.IsNullOrEmpty(requiredList[key]))
                {
                    msg += "--" + key + "\n";
                }
            }
            return msg;
        }
        public string CheckRegex() {
            string msg = "";
            return msg;
        }
    }
}
