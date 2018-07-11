using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableImplement.Models.DataBase;
using System.Data.SqlClient;

namespace TableImplement.Models.GetDB
{
    public partial class MsSqlDB : DB, IDataBase
    {
        /// <summary>
        /// open connection
        /// </summary>
        /// <param name="strConn">connection string</param>
        /// <returns></returns>
        private SqlConnection GetConnection(string strConn)
        {
            logger.logger.Debug("Entering with strConn:" + strConn);
            SqlConnection conn;
            try 
            {
                conn = new SqlConnection(strConn);
                conn.Open();
            }catch( Exception ex){
                logger.logger.Error(ex.ToString());
                throw (ex);                
            }
            logger.logger.Debug("Exit with conn: " + conn.ToString());
            return conn;            
        }
    }
}