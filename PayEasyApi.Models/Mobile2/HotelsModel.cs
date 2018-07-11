using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayEasyApi.Models.Mobile2
{
    public class HotelsModel
    {
        public int seq { get; set; }

        public string hotel_no { get; set; }

        public string chinese_name { get; set; }

        public string english_name { get; set; }

        public string tel { get; set; }

        public string fax { get; set; }

        public string address { get; set; }

        public string city_name { get; set; }

        public string city_code { get; set; }

        public string link_url { get; set; }

        public string hotel_kind { get; set; }

        public string country_name { get; set; }

        public string address_other { get; set; }
    }
}
