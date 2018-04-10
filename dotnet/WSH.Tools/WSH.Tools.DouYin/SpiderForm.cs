using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WSH.Tools
{
    public class SpiderForm : Form
    {
        public SpiderForm() {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        protected JObject parseJObject(string jsonString)
        {
            return (JObject)JsonConvert.DeserializeObject(jsonString);
        }
        protected JArray parseJArray(string jsonString)
        {
            return (JArray)JsonConvert.DeserializeObject(jsonString);
        }
    }
}
