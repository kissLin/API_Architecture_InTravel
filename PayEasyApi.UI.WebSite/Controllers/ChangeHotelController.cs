using Newtonsoft.Json;
using PayEasyApi.BL.Interfaces;
using PayEasyApi.BL.Services;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace PayEasyApi.UI.WebSite.Controllers
{
    public class ChangeHotelController : Controller
    {
        public IPHECDBService PHECDBService { get; set; }

        public ChangeHotelController()
            : this(new PHECDBService())
        {

        }

        public ChangeHotelController(IPHECDBService phecdbService)
        {
            this.PHECDBService = phecdbService;
        }

        public ActionResult GetChangeHotelInfo(string output)
        {
            var data = this.PHECDBService.GetChangeHOTEL();
            if (output == "xml")
            {
                XmlSerializer Xml_Serializer = new XmlSerializer(data.GetType());
                StringWriter Writer = new StringWriter();
                Xml_Serializer.Serialize(Writer, data);
                return this.Content(Writer.ToString(), "text/xml");
            }
            else
            {
                //JsonSerializer serializer = JsonSerializer.Create(data.GetType());

                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
