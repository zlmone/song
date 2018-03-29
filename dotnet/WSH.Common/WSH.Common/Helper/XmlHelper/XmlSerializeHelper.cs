using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;

namespace WSH.Common.Helper
{
    public class XmlSerializeHelper<T> where T : class,new()
    {
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private string rootName;
        /// <summary>
        /// 指定根节点的名称
        /// </summary>
        public string RootName
        {
            get { return rootName; }
            set { rootName = value; }
        }
        private bool isNameSpace = false;
        /// <summary>
        /// 是否生成命名空间
        /// </summary>
        public bool IsNameSpace
        {
            get { return isNameSpace; }
            set { isNameSpace = value; }
        }
        /// <summary>
        /// 将xml配置文件序列化成集合对象
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="path">配置文件路径</param>
        /// <returns></returns>
        public List<T> ReadList()
        {
            Type type = typeof(List<T>);
            XmlSerializer ser = GetSerializer(type);
            List<T> list = new List<T>();
            using (FileStream fs = File.OpenRead(FileName))
            {
                list = ser.Deserialize(fs) as List<T>;
            }
            return list;
        }
        /// <summary>
        /// 将xml配置文件序列化成实体对象
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="path">配置文件路径</param>
        /// <returns></returns>
        public T ReadEntity()
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            T t = default(T);
            using (FileStream fs = File.OpenRead(FileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
               
                if (!IsNameSpace)
                {
                    t = (T)ser.Deserialize(fs);
                }
                else
                {
                    t = (T)ser.Deserialize(fs);
                }
            }
            return t;
        }
        /// <summary>
        /// 加载第一个配置映射
        /// </summary>
        /// <returns></returns>
        public T ReadFirst()
        {
            List<T> list = ReadList();
            if (list == null && list.Count <= 0)
            {
                return null;
            }
            return list[0];
        }
         
        /// <summary>
        /// 将对象序列化成xml字符串
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="entity">对象实例</param>
        /// <param name="isDeclaration">是否生成xml声明</param>
        /// <param name="isNamespace">是否生成命名空间</param>
        /// <returns>xml字符串</returns>
        public string ParseString(T entity, bool isDeclaration = false)
        {
            if (entity != null)
            {
                StringBuilder buffer = new StringBuilder();
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = !isDeclaration;
                settings.Encoding = Encoding.UTF8;
                using (XmlWriter w = XmlWriter.Create(buffer, settings))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    if (!IsNameSpace)
                    {
                        serializer.Serialize(w, entity, GetNameSpace());
                    }
                    else
                    {
                        serializer.Serialize(w, entity);
                    }
                }
                return buffer.ToString();
            }
            return null;
        }
        /// <summary>
        /// 将对象序列化到xml配置文件中
        /// </summary>
        /// <typeparam name="T">对象实体</typeparam>
        /// <param name="t">对象实例</param>
        /// <param name="path">文件保存路径</param>
        /// <param name="isNameSpace">是否保留命名空间</param>
        public void Save(T t)
        {
            if (t != null)
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                using (FileStream fs = File.Create(FileName))
                {
                    if (!isNameSpace)
                    {
                        //去除命名空间
                        ser.Serialize(fs, t, GetNameSpace());
                    }
                    else
                    {
                        ser.Serialize(fs, t);
                    }
                }
            }
        }
        /// <summary>
        /// 将对象集合序列化到xml配置文件中
        /// </summary>
        /// <typeparam name="T">对象实体</typeparam>
        /// <param name="list">对象集合</param>
        /// <param name="path">文件保存路径</param>
        /// <param name="rootName">根节点名称</param>
        /// <param name="isNameSpace">是否保留命名空间</param>
        public void Save(List<T> list)
        {
            if (list != null && list.Count > 0)
            {
                Type type = typeof(List<T>);
                XmlSerializer ser = GetSerializer(type);
                using (FileStream fs = File.Create(FileName))
                {
                    if (!isNameSpace)
                    {
                        //去除命名空间
                        ser.Serialize(fs, list, GetNameSpace());
                    }
                    else
                    {
                        ser.Serialize(fs, list);
                    }
                }
            }
        }
        #region 私有方法
        public XmlRootAttribute GetRoot()
        {
            return new XmlRootAttribute()
                    {
                        ElementName = rootName
                    };
        }
        private XmlSerializerNamespaces GetNameSpace() {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            return ns;
        }
        private XmlSerializer GetSerializer(Type type) {
            if (string.IsNullOrEmpty(RootName))
            {
                return  new XmlSerializer(type);
            }
            else
            {
                return new XmlSerializer(type, GetRoot());
            }
        }
        #endregion
    }
}
