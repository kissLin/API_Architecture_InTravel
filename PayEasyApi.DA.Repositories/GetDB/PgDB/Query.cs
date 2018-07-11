using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableImplement.Models.DataBase;
using Npgsql;
using System.Data;
using NpgsqlTypes;


namespace TableImplement.Models.GetDB
{
    public partial class PgDB : DB, IDataBase
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
            if (args != null)
            {
                logger.logger.Debug("args:" + args.ToString());
            }
            DataTable dt = new DataTable();
            NpgsqlConnection conn = GetConnection(base.strConn);
            try
            {                 
                NpgsqlCommand command = StrToCommand(conn, strSQL, args);
                NpgsqlDataReader dataReader = command.ExecuteReader();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    dt.Columns.Add(dataReader.GetName(i));
                }
                dt.Load(dataReader);
            }
            catch (NpgsqlException ex)
            {
                //logger.logger.Error(ex.ErrorSql + "\n" + ex.ToString());
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

        public DataSet QueryIEnumerable(string strSQL, Dictionary<string, object> args = null)
        {
            logger.logger.Debug("Entering with strSQL:" + strSQL);
            if (args != null)
            {
                logger.logger.Debug("args:" + args.ToString());
            }
            DataSet ds = new DataSet();
            NpgsqlConnection conn = GetConnection(base.strConn);
            try
            {
                NpgsqlCommand command = StrToCommand(conn, strSQL, args);
                NpgsqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    dataReader.Dispose();
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                    adapter.Fill(ds);
                }
            }
            catch (NpgsqlException ex)
            {
                //logger.logger.Error(ex.ErrorSql + "\n" + ex.ToString());
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