using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableImplement.Models.GetDB;

namespace PayEasyApi.DA.Repositories.DataTablePHECDB
{
    public class ChangeHotels
    {
        public ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private MsSqlDB msSqlDB = new MsSqlDB("MSconnString_PHECDB");

        public DataSet GetChangeHotelsInfo()
        {
            string strSQL = string.Empty;
            DataSet ds = new DataSet();
            Dictionary<string, object> args = new Dictionary<string, object>();
            try
            {
                try
                {
                    strSQL = "select htl_cd,eng_nme,chn_nme from change_HOTEL";
                    ds = msSqlDB.QueryIEnumerable(strSQL);
                }
                catch (IOException ex)
                {
                    logger.Error(ex.ToString());
                    throw (ex);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw (ex);
            }
            return ds;
        }
    }
}
