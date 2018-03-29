using System;
using System.Data;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;
using System.Web;
using System.Xml;
namespace Ext.Common
{
    public class db
    {
        private Xml xml = new Xml(HttpContext.Current.Server.MapPath(Utils.GetApplicationPath+"Common/DataBase.config"));
        public DataBaseConfig GetDataBaseConfig()
        {
            DataBaseConfig dbc = new DataBaseConfig();
            XmlNodeList nodes = xml.GetNodeList("DataBase");
            foreach (XmlNode node in nodes)
            {
                if (xml.GetAttr(node, "default") == "true")
                {
                    dbc.Type = xml.GetAttr(node, "type");
                    dbc.Mode = xml.GetAttr(node, "mode");
                    dbc.Server = xml.FindNodeText(node, "server");
                    dbc.Source = xml.FindNodeText(node, "source");
                    dbc.Uid = xml.FindNodeText(node, "uid");
                    dbc.Pwd = xml.FindNodeText(node, "pwd");
                    break;
                }
            }
            return dbc;
        }
        public bool SetConnectionString(DataBaseConfig dbc,out string msg) {
            XmlDocument doc = xml.GetDocument();
            XmlNodeList nodes = doc.GetElementsByTagName("DataBase");
            try
            {
                foreach (XmlNode node in nodes)
                {
                    string t = xml.GetAttr(node, "type");
                    string m = xml.GetAttr(node, "mode");
                    if (t == dbc.Type)
                    {
                        xml.SetAttr(node, "default", "true");
                        if (dbc.Mode != "" && m != dbc.Mode)
                        {
                            xml.SetAttr(node, "mode", dbc.Mode);
                        }
                        xml.SetNodeText(node, "server", dbc.Server);
                        xml.SetNodeText(node, "source", dbc.Source);
                        xml.SetNodeText(node, "uid", dbc.Uid);
                        xml.SetNodeText(node, "pwd", dbc.Pwd);
                    }
                    else
                    {
                        xml.SetAttr(node, "default", "false");
                    }
                }
                doc.Save(xml.Path);
            }catch(Exception ex){
                msg = ex.Message;
                return false;
            }
            msg = "";
            return true;
        }
        public string GetConnectionString() {
            DataBaseConfig dbc = GetDataBaseConfig();
            return dbc.GetConnectionString();
        }
        public SqlConnection GetConn() {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            if(conn.State== ConnectionState.Closed){
                conn.Open();
            }
            return conn;
        }
        public DataTable GetDataTable(string sql) {
            SqlConnection conn = GetConn();
            DataTable dt = new DataTable();
            SqlDataAdapter dr = new SqlDataAdapter(sql, conn);
            dr.Fill(dt);
            return dt;
        }
        public bool ExecuteNonQuery(string sql) {
            SqlConnection conn = GetConn();
            SqlCommand comm = new SqlCommand(sql, conn);
            return comm.ExecuteNonQuery() > 0;
        }
        public object ExecuteSalar(string sql) {
            SqlConnection conn = GetConn();
            SqlCommand comm = new SqlCommand(sql, conn);
            return comm.ExecuteScalar();
        }
    }
}
