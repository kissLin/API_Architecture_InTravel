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

        private SqlCommand StrToCommand(SqlConnection conn, string strSQL, Dictionary<string,object> args = null)
        {
            logger.logger.Debug("Entering with conn:" + conn.ToString());
            logger.logger.Debug("strSQL: " + strSQL);
            if (args != null){
                logger.logger.Debug("args:" + args.ToString());
            }
            SqlCommand command;
            try
            {
                command = new SqlCommand(strSQL, conn);
                if (args != null) { 
                    foreach(KeyValuePair<string,object> kvp in args){
                        command.Parameters.AddWithValue(kvp.Key,kvp.Value);
                    }                               
                }
            }
            catch (Exception ex)
            {
                logger.logger.Error(ex.ToString());
                throw (ex);
            }
            logger.logger.Debug("Exit with command: " + command.CommandText);
            return command;
        }
    }
}