﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableImplement.Models.DataBase;
using System.Data;
using System.Data.SqlClient;


namespace TableImplement.Models.GetDB
{
    public partial class MsSqlDB : DB, IDataBase
    {
        /// <summary>
        /// sql retrieve
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public object Retrieve(string strSQL, Dictionary<string, object> args = null)
        {
            logger.logger.Debug("Entering with strSQL:" + strSQL);
            if (args != null)
            {
                logger.logger.Debug("args:" + args.ToString());
            }
            object result = null;
            SqlConnection conn = GetConnection(base.strConn);
            try
            {
                SqlCommand command = StrToCommand(conn, strSQL, args);
                result = command.ExecuteScalar();
                if (result == null) {
                    result = "";
                }
            }
            catch (SqlException ex)
            {
                logger.logger.Error(ex.Errors.ToString() + "\n" + ex.ToString());
                throw (ex);
            }
            catch (Exception ex)
            {
                logger.logger.Error(ex.ToString());
                throw (ex);
            }
            finally
            {
                conn.Close();
            }
            logger.logger.Debug("Exit with rowsAffected: " + result.ToString());
            return result;
        }
    }
}