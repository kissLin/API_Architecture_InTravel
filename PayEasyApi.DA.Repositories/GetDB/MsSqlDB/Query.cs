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
        /// sql query
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataTable Query(string strSQL, Dictionary<string, object> args = null)
        {
            logger.logger.Debug("Entering with strSQL:" + strSQL);
            if (args != null){
                logger.logger.Debug("args:" + args.ToString());
            }
            DataTable dt = new DataTable();
            SqlConnection conn = GetConnection(base.strConn);
            try
            {
                SqlCommand command = StrToCommand(conn, strSQL, args);
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
            finally {
                conn.Close();
            }
            logger.logger.Debug("Exit with dt: " + dt.ToString());
            return dt;
        }


        /// <summary>
        /// sql query
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataSet QueryIEnumerable(string strSQL, Dictionary<string, object> args = null)
        {
            logger.logger.Debug("Entering with strSQL:" + strSQL);
            if (args != null)
            {
                logger.logger.Debug("args:" + args.ToString());
            }
            DataSet ds = new DataSet();
            SqlConnection conn = GetConnection(base.strConn);
            try
            {
                SqlCommand command = StrToCommand(conn, strSQL, args);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    dataReader.Dispose();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds);
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
            logger.logger.Debug("Exit with dt: " + ds.ToString());
            return ds;
        }
    }
}