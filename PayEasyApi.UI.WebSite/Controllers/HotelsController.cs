using PayEasyApi.BL.Interfaces;
using PayEasyApi.BL.Services;
using PayEasyApi.Models;
using PayEasyApi.Models.Mobile2;
using PayEasyApi.Models.requestModels;
using PayEasyApi.Utility.Extensions.SerializerSettings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace PayEasyApi.UI.WebSite.Controllers
{
    public class HotelsController : Controller
    {
        public IMobileService MobileService { get; set; }

        public HotelsController()
            : this(new MobileService())
        {

        }

        public HotelsController(IMobileService mobileService)
        {
            this.MobileService = mobileService;
        }

        public ActionResult GetHotelsInfo(string output)
        {
            var data = this.MobileService.GetHotels();
            if (output == "xml")  
            {
                XmlSerializer Xml_Serializer = new XmlSerializer(data.GetType());
                StringWriter Writer = new StringWriter();
                Xml_Serializer.Serialize(Writer, data);
                return this.Content(Writer.ToString(), "text/xml");
            }
            else
            {
                return Json(data, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public string PostNotify(PackageModal modal)
        {
            var doc = new XmlDocument();
            return doc.DocumentElement.OuterXml;
        }

        [HttpPost]
        public HttpResponseMessage PostProduct(Product item)
        {
            return null;
        }

         [HttpPost]
         public string ReturnXmlDocument(HttpRequestMessage request)
         {
             var doc = new XmlDocument();
             doc.Load(request.Content.ReadAsStreamAsync().Result);
             return doc.DocumentElement.OuterXml;
         }

         [HttpPost]
         public string Test1([System.Web.Http.FromBody]OrderElements value)
         {
             return "";
         }

        [HttpPost]
        [ValidateInput(false)]
         public ActionResult Test(SendModel model)
        {
          if (!ModelState.IsValid)
          {
             return Content("error");
          }
          return Content("aaa");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult xmlTest(Test model)
        {
            if (!ModelState.IsValid)
            {
                return Content("error");
            }
            return Content("aaa");
        }

        /// <summary>
        /// xmlString for clinet post text format
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index()
        {
            string xml = "";
            SendOrderMain xmlobj;
            if(Request.InputStream != null){
                StreamReader stream = new StreamReader(Request.InputStream);
                string x = stream.ReadToEnd();
                xml = HttpUtility.UrlDecode(x);
                xmlobj = SerializeTool.DeserializeXml<SendOrderMain>(xml);
            }
            return View();
        }
    }
}
