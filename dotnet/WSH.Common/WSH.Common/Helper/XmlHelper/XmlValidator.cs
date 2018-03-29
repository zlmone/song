using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace WSH.Common.Helper
{
    /// <summary>
    /// 使用Schema验证XML文件
    /// </summary>
    public class XmlValidator
    {
        public string ErrorMsg = string.Empty;
        public bool IsValid = true;

        ///<summary>
        /// 根据XSD验证XML是否符合规范
        ///</summary>
        ///<param name="entityXML">需要验证的XML</param>
        ///<param name="xmlSchema">包含XSD的数据流</param>
        public void Validate(Stream xmlSchema, string entityXML)
        {

            var sr = XmlReader.Create(xmlSchema);
            var schemaSet = new XmlSchemaSet();
            schemaSet.Add(null, sr);
            var doc = new XmlDocument();
            doc.LoadXml(entityXML);
            doc.Schemas = schemaSet;
            doc.Validate(ValidationEventHandler);

        }

        ///<summary>
        /// 根据XSD验证XML是否符合规范,字符串校验
        ///</summary>
        ///<param name="entityXML">需要验证的XML</param>
        ///<param name="xmlSchema">包含XSD的数据流</param>
        public void Validate(string xmlSchema, string entityXML)
        {

            var sr = XmlReader.Create(new StringReader(xmlSchema));
            var schemaSet = new XmlSchemaSet();
            schemaSet.Add(null, sr);
            var doc = new XmlDocument();
            doc.LoadXml(entityXML);
            doc.Schemas = schemaSet;
            doc.Validate(ValidationEventHandler);

        }

        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            ErrorMsg += e.Message + "\r\n";
            IsValid = false;
        }
    }
}