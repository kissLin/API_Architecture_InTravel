using System;
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
        /// sql ExcSPROC
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataTable ExcSPROC(string procName, Dictionary<string, object> args = null)
        {
            logger.logger.Debug("Entering with procName:" + procName);
            if (args != null)
            {
                logger.logger.Debug("args:" + args.ToString());
            }
            DataTable dt = new DataTable();
            SqlConnection conn = GetConnection(base.strConn);
            try
            {
                SqlCommand command = StrToCommand(conn, procName, args);
                SqlDataReader dataReader = command.ExecuteReader();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    dt.Columns.Add(dataReader.GetName(i));
                }
                dt.Load(dataReader);
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
            logger.logger.Debug("Exit with dt: " + dt.ToString());
            return dt;
        }
    }
}
