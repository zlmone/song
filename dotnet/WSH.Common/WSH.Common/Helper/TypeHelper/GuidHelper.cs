using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Common.Helper
{
   public  class GuidHelper
    {
       public static string GuidNonSplit {
           get {
               return Guid.NewGuid().ToString().Replace("-","");
           }
       }
    }
}
