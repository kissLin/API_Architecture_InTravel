using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableImplement.Models.DataBase;
using Npgsql;

namespace TableImplement.Models.GetDB
{
    public partial class PgDB : DB, IDataBase
    {
        /// <summary>
        /// open connection
        /// </summary>
        /// <param name="strConn">connection string</param>
        /// <returns></returns>
        private NpgsqlConnection GetConnection(string strConn)
        {
            logger.logger.Debug("Entering with strConn:" + strConn.ToString());
            NpgsqlConnection conn;
            try 
            {
                conn = new NpgsqlConnection(strConn);
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