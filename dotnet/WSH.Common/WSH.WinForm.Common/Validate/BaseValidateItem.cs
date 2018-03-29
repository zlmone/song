using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WSH.WinForm.Common
{
   public abstract  class BaseValidateItem
    {
       public BaseValidateItem() { }
      
       private bool required=true;

       public bool Required
       {
           get { return required; }
           set { required = value; }
       }
       private string requiredMsg="此项必填";

       public string RequiredMsg
       {
           get { return requiredMsg; }
           set { requiredMsg = value; }
       }
       private string value;

       public virtual string Value
       {
           get { return this.value; }
           set { this.value = value; }
       }
       private string regex;

       public string Regex
       {
           get { return regex; }
           set { regex = value; }
       }
       private string regexMsg="数据格式不正确";

       public string RegexMsg
       {
           get { return regexMsg; }
           set { regexMsg = value; }
       }
       private long maxLength = 0x7fffffffffffffffL;

       public long MaxLength
       {
           get { return maxLength; }
           set { maxLength = value; }
       }
       private string maxLengthMsg = "数据长度过长";

       public string MaxLengthMsg
       {
           get { return maxLengthMsg; }
           set { maxLengthMsg = value; }
       }
       private long minLength = 1L;

       public long MinLength
       {
           get { return minLength; }
           set { minLength = value; }
       }
       private string minLengthMsg="数据长度过短";

       public string MinLengthMsg
       {
           get { return minLengthMsg; }
           set { minLengthMsg = value; }
       }
       public abstract bool Check();
       public abstract void ClearError();
    }
}
