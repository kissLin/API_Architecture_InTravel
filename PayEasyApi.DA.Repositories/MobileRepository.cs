using log4net;
using PayEasyApi.DA.Interfaces;
using PayEasyApi.Models.Mobile2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableImplement.Models.GetDB;

namespace PayEasyApi.DA.Repositories.DataTableMobile2
{
    public class MobileRepository : IMobileRepository
    {
        public ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Hotels hotels = new Hotels();

        public IEnumerable<HotelsModel> GetHotels()
        {
            logger.Debug("Entering with GetHotels:");
            DataSet ds = new DataSet();
            ds = hotels.GetHotelsAllInfo();
            List<HotelsModel> list = new List<HotelsModel>();
           
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                list.Add(new HotelsModel
                {
                    seq = int.Parse(r[0].ToString()),
                    hotel_no = r[1].ToString(),
                    chinese_name = r[2].ToString(),
                    english_name = r[3].ToString(),
                    tel = r[4].ToString(),
                    fax = r[5].ToString(),
                    address = r[6].ToString(),
                    city_name = r[7].ToString(),
                    city_code = r[8].ToString(),
                    link_url = r[9].ToString(),
                    hotel_kind = r[10].ToString(),
                    country_name = r[11].ToString(),
                    address_other = r[12].ToString(),
                });
            }

            return list;   
        }
    }
}
