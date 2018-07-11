using log4net;
using PayEasyApi.DA.Interfaces;
using PayEasyApi.DA.Repositories.DataTablePHECDB;
using PayEasyApi.Models.PHECDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayEasyApi.DA.Repositories
{
    public class PHECDBRepository : IPHECDBRepository
    {
        public ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ChangeHotels ChangeHotels = new ChangeHotels();

        public IEnumerable<ChangeHOTELModel> GetChangeHOTEL()
        {
            logger.Debug("Entering with GetHotels:");
            DataSet ds = new DataSet();
            ds = ChangeHotels.GetChangeHotelsInfo();
            List<ChangeHOTELModel> list = new List<ChangeHOTELModel>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                list.Add(new ChangeHOTELModel
                {
                    htl_cd = r[0].ToString(),
                    eng_nme =r[1].ToString(),
                    chn_nme =r[2].ToString()
                });
            }
            return list;
        }
    }
}
