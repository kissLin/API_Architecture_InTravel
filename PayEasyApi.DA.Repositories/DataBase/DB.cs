using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Microsoft.VisualBasic.Devices;

namespace TableImplement.Models.DataBase
{
    public class DB
    {
        protected string strConn; 
        private static string fileName = System.AppDomain.CurrentDomain.BaseDirectory + "config.json";
        private static string configValue = new Computer().FileSystem.ReadAllText(fileName);
        private static JavaScriptSerializer objSerializer=new System.Web.Script.Serialization.JavaScriptSerializer();
        private static Dictionary<string, object> config = objSerializer.Deserialize<Dictionary<string, object>>(configValue);
        public DB(){}
        public DB(string strConn) {
            this.strConn = ConfigAttribure(strConn).ToString();
        }
        private object ConfigAttribure(string key)
        {
            return config[key];
        } 
        
    }
}