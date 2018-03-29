using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using WSH.Common.Helper;
using WSH.Common;

namespace WSH.Pdm.Common
{
    public class PdmReader
    {
        public const string a = "attribute", c = "collection", o = "object";

        public const string cClasses = "c:Classes";
        public const string oClass = "o:Class";

        public const string cAttributes = "c:Attributes";
        public const string oAttribute = "o:Attribute";

        public const string cTables = "c:Tables";
        public const string oTable = "o:Table";

        public const string cColumns = "c:Columns";
        public const string oColumn = "o:Column";


        XmlDocument xmlDoc;
        XmlNamespaceManager xmlnsManager;
        /// <summary>构造函数 </summary>
        public PdmReader()
        {
            // TODO: 在此处添加构造函数逻辑
            xmlDoc = new XmlDocument();
        }
        /// <summary>构造函数 </summary>
        public PdmReader(string pdm_file)
        {
            PdmFile = pdm_file;
        }

        string pdmFile;

        public string PdmFile
        {
            get { return pdmFile; }
            set
            {
                pdmFile = value;
                if (xmlDoc == null)
                {
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(pdmFile);
                    xmlnsManager = new XmlNamespaceManager(xmlDoc.NameTable);
                    xmlnsManager.AddNamespace("a", "attribute");
                    xmlnsManager.AddNamespace("c", "collection");
                    xmlnsManager.AddNamespace("o", "object");
                }
            }
        }

        IList<PdmTable> tables;

        public IList<PdmTable> Tables
        {
            get { return tables; }
            set { tables = value; }
        }
        public string DbTypeString;
        public void InitData()
        {
            if (Tables == null)
                Tables = new List<PdmTable>();
            XmlNode xnTables = xmlDoc.SelectSingleNode("//" + cTables, xmlnsManager);
            //获取pdm文件指令
            XmlProcessingInstruction pi = (XmlProcessingInstruction)xmlDoc.SelectSingleNode("/processing-instruction(\"PowerDesigner\")");
            if (pi != null)
            {
                var pivalue = pi.Value;
                //解析指令，获取数据库来源
                IList<TagBuilder> tags = TagHelper.ParseSiblingHmlt("<PowerDesigner " + pivalue + " />");
                if (tags != null && tags.Count > 0)
                {
                    DbTypeString = tags[0].GetAttribute("Target");
                }
            }
            foreach (XmlNode xnTable in xnTables.ChildNodes)
            {
                Tables.Add(GetTable(xnTable));
            }
        }
        /// <summary>
        /// 获取数据库类型
        /// </summary>
        /// <returns></returns>
        public DataBaseType GetDbType()
        {
            string dbString = this.DbTypeString;
            if (!string.IsNullOrEmpty(dbString))
            {
                dbString = dbString.ToLower();
                if (dbString.Contains("sql server") || dbString.Contains("sqlserver"))
                {
                    return DataBaseType.SqlServer;
                }
                if (dbString.Contains("mysql"))
                {
                    return DataBaseType.MySql;
                }
                if (dbString.Contains("oracle"))
                {
                    return DataBaseType.Oracle;
                }
                if (dbString.Contains("access"))
                {
                    return DataBaseType.Access;
                }
                if (dbString.Contains("sqlite"))
                {
                    return DataBaseType.SQLite;
                }
            }
            return DataBaseType.Other;
        }
        //初始化"o:Table"的节点
        private PdmTable GetTable(XmlNode xnTable)
        {
            PdmTable mTable = new PdmTable();
            XmlElement xe = (XmlElement)xnTable;
            mTable.TableId = xe.GetAttribute("Id");
            XmlNodeList xnTProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnTProperty)
            {
                switch (xnP.Name)
                {
                    case "a:ObjectID": mTable.ObjectID = xnP.InnerText;
                        break;
                    case "a:Name": mTable.Name = xnP.InnerText;
                        break;
                    case "a:Code": mTable.Code = xnP.InnerText;
                        break;
                    case "a:CreationDate": mTable.CreationDate = Convert.ToInt32(xnP.InnerText);
                        break;
                    case "a:Creator": mTable.Creator = xnP.InnerText;
                        break;
                    case "a:ModificationDate": mTable.ModificationDate = Convert.ToInt32(xnP.InnerText);
                        break;
                    case "a:Modifier": mTable.Modifier = xnP.InnerText;
                        break;
                    case "a:Comment": mTable.Comment = xnP.InnerText;
                        break;
                    case "a:PhysicalOptions": mTable.PhysicalOptions = xnP.InnerText;
                        break;
                    case "c:Columns": InitColumns(xnP, mTable);
                        break;
                    case "c:Keys": InitKeys(xnP, mTable);
                        break;
                }
            }
            return mTable;
        }
        //初始化"c:Columns"的节点
        private void InitColumns(XmlNode xnColumns, PdmTable pTable)
        {
            foreach (XmlNode xnColumn in xnColumns)
            {
                pTable.AddColumn(GetColumn(xnColumn));
            }
        }

        //初始化c:Keys"的节点
        private void InitKeys(XmlNode xnKeys, PdmTable pTable)
        {
            foreach (XmlNode xnKey in xnKeys)
            {
                pTable.AddKey(GetKey(xnKey));
            }
        }

        private PdmColumn GetColumn(XmlNode xnColumn)
        {
            PdmColumn mColumn = new PdmColumn();
            XmlElement xe = (XmlElement)xnColumn;
            mColumn.ColumnId = xe.GetAttribute("Id");
            XmlNodeList xnCProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnCProperty)
            {
                switch (xnP.Name)
                {
                    case "a:ObjectID": mColumn.ObjectID = xnP.InnerText;
                        break;
                    case "a:Name": mColumn.Name = xnP.InnerText;
                        break;
                    case "a:Code": mColumn.Code = xnP.InnerText;
                        break;
                    case "a:CreationDate": mColumn.CreationDate = Convert.ToInt32(xnP.InnerText);
                        break;
                    case "a:Creator": mColumn.Creator = xnP.InnerText;
                        break;
                    case "a:ModificationDate": mColumn.ModificationDate = Convert.ToInt32(xnP.InnerText);
                        break;
                    case "a:Modifier": mColumn.Modifier = xnP.InnerText;
                        break;
                    case "a:Comment": mColumn.Comment = xnP.InnerText;
                        break;
                    case "a:DataType": mColumn.DataType = xnP.InnerText;
                        break;
                    case "a:Length": mColumn.Length = xnP.InnerText;
                        break;
                    case "a:Identity": mColumn.IdEntity = ConvertBool(xnP.InnerText);
                        break;
                    case "a:Mandatory": mColumn.Mandatory = ConvertBool(xnP.InnerText);
                        break;
                    case "a:PhysicalOptions": mColumn.PhysicalOptions = xnP.InnerText;
                        break;
                    case "a:ExtendedAttributesText": mColumn.ExtendedAttributesText = xnP.InnerText;
                        break;
                }
            }
            return mColumn;
        }
        private bool ConvertBool(string obj)
        {
            if (obj != null)
            {
                string mStr = obj.ToString();
                mStr = mStr.ToLower();
                if ((mStr.Equals("y") || mStr.Equals("1")) || mStr.Equals("true"))
                {
                    return true;
                }
            }
            return false;
        }
        private PdmKey GetKey(XmlNode xnKey)
        {
            PdmKey mKey = new PdmKey();
            XmlElement xe = (XmlElement)xnKey;
            mKey.KeyId = xe.GetAttribute("Id");
            XmlNodeList xnKProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnKProperty)
            {
                switch (xnP.Name)
                {
                    case "a:ObjectID": mKey.ObjectID = xnP.InnerText;
                        break;
                    case "a:Name": mKey.Name = xnP.InnerText;
                        break;
                    case "a:Code": mKey.Code = xnP.InnerText;
                        break;
                    case "a:CreationDate": mKey.CreationDate = Convert.ToInt32(xnP.InnerText);
                        break;
                    case "a:Creator": mKey.Creator = xnP.InnerText;
                        break;
                    case "a:ModificationDate": mKey.ModificationDate = Convert.ToInt32(xnP.InnerText);
                        break;
                    case "a:Modifier": mKey.Modifier = xnP.InnerText;
                        break;
                    //还差 <c:Key.Columns>
                }
            }
            return mKey;
        }
    }
}
