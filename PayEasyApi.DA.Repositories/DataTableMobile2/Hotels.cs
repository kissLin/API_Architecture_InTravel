using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableImplement.Models.GetDB;

namespace PayEasyApi.DA.Repositories.DataTableMobile2
{
    public class Hotels
    {
        public ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private PgDB pgDB = new PgDB("connString");

        public DataSet GetHotelsAllInfo()
        {
            string strSQL = string.Empty;
            DataSet ds = new DataSet();
            Dictionary<string, object> args = new Dictionary<string, object>();
            try
            {
                try
                {
                    strSQL = "select * from hotels limit 20";
                    ds = pgDB.QueryIEnumerable(strSQL);
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
