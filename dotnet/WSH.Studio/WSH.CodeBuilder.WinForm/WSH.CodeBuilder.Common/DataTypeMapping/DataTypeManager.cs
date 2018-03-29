using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.Common.Helper;
using System.IO;
using System.Xml;
using WSH.Common.Helper;
using WSH.Common;

namespace WSH.CodeBuilder.Common
{
    public class DataTypeManager
    {
        #region 数据类型转换
        public static DataType Parse(string dataType)
        {
            return StringHelper.ToEnum<DataType>(dataType);
        }
        public static DataType ParseDbDataType(DataBaseType dbType, string dataType) {
            return GetDataType(dbType.ToString().ToLower(), dataType);
        }
        public static DataType ParseDbDataType(string dbType, string dataType)
        {
            return GetDataType(dbType.ToLower(), dataType);
        }
         
        /// <summary>
        /// 根据语言类型和语言对应的数据类型，获取自定义数据类型
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="langDataType"></param>
        /// <returns></returns>
        public static DataType GetDataType(string lang, string langDataType)
        {
            foreach (DataTypeMapping mapping in Mappings)
            {
                foreach (DataTypeLanguage typeLang in mapping.Languages)
                {
                    if (typeLang.Language.ToLower() == lang.ToLower())
                    {
                        if (typeLang.DataTypeHelper.Contains(langDataType) || typeLang.ReplaceTypes.Contains(langDataType))
                        {
                            return mapping.DataType;
                        }
                    }
                }
            }
            return DataType.Object;
        }
        /// <summary>
        /// 根据语言类型和自定义数据类型，获取语言对应的数据类型
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static List<string> GetLangDataTypes(string lang, DataType dataType)
        {
            foreach (DataTypeMapping mapping in Mappings)
            {
                if (dataType == mapping.DataType)
                {
                    foreach (DataTypeLanguage typeLang in mapping.Languages)
                    {
                        if (typeLang.Language.ToLower() == lang.ToLower())
                        {
                            return typeLang.DataTypeHelper.Count > 0 ? typeLang.DataTypeHelper : typeLang.ReplaceTypes;
                        }
                    }
                }
            }
            return new List<string> { "object" };
        }
        /// <summary>
        /// 根据语言类型和自定义数据类型，获取语言对应的数据类型
        /// </summary>
        /// <param name="lang">语言类型</param>
        /// <param name="dataType">自定义数据类型</param>
        /// <returns>语言对应的数据类型</returns>
        public static string GetLangDataType(string lang, DataType dataType)
        {
            List<string> types = GetLangDataTypes(lang, dataType);
            if (types != null || types.Count > 0)
            {
                return types[0];
            }
            return "object";
        }

        public static string GetLangDataType(string lang, string dataType)
        {
            return GetLangDataType(lang, Parse(dataType));
        }
        #endregion

        #region 初始化Mapping
        private static List<DataTypeMapping> Mappings=null;
        public static void InitMappingConfig(string fileName = null)
        {
            if (Mappings!=null)
            {
                return;
            }
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = Path.Combine(PathHelper.GetConfigPath, "DataTypeMapping.xml");
            }
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("文件：" + fileName + "不存在");
            }
            XmlHelper helper = new XmlHelper(fileName);
            XmlNodeList mappingNodes = helper.Root.SelectNodes("dataTypeMapping");
            if (mappingNodes != null)
            {
                Mappings = new List<DataTypeMapping>();
                foreach (XmlNode mappingNode in mappingNodes)
                {
                    DataType dataType = DataType.Object;
                    try
                    {
                        dataType = DataTypeManager.Parse(mappingNode.Attributes["type"].Value);
                    }
                    catch { }
                    if (dataType != DataType.Object)
                    {
                        DataTypeMapping dataTypeMapping = new DataTypeMapping()
                        {
                            DataType = dataType
                        };
                        XmlNodeList langNodes = mappingNode.ChildNodes;
                        if (langNodes != null)
                        {
                            foreach (XmlNode langNode in langNodes)
                            {
                                if (langNode.NodeType == XmlNodeType.Element)
                                {
                                    DataTypeLanguage lang = new DataTypeLanguage()
                                    {
                                        Language = langNode.Name
                                    };
                                    string langText = langNode.InnerText.Trim();
                                    if(!string.IsNullOrEmpty(langText)){
                                        lang.DataTypeHelper = langText.Split(',').ToList();
                                    }
                                    XmlAttribute attrLength = langNode.Attributes["replaceLength"];
                                    if (attrLength != null)
                                    {
                                        lang.ReplaceLength = attrLength.Value;
                                    }
                                    XmlAttribute attrReplace = langNode.Attributes["replace"];
                                    if (attrReplace != null)
                                    {
                                        string replaceValue = attrReplace.Value.Trim();
                                        if (!string.IsNullOrEmpty(replaceValue))
                                        {
                                            lang.ReplaceTypes = replaceValue.Split(',').ToList();
                                        }
                                    }
                                    dataTypeMapping.Languages.Add(lang);
                                }
                            }
                        }
                        Mappings.Add(dataTypeMapping);
                    }
                }
            }
        }
        #endregion
    }
}
