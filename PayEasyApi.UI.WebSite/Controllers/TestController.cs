using PayEasyApi.Models.requestModels;
using PayEasyApi.Models.requestModels.ListTravelTour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PayEasyApi.UI.WebSite.Controllers
{
    public class TestController : ApiController
    {

        /// <summary>
        /// test for clinet post xml format
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Test5([FromBody] SendOrderMain value)
        {
            if (!ModelState.IsValid)
            {
                return "error";
            }
            return "";
        }


        /// <summary>
        /// test for clinet post xml format
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string ListTravelTour([FromBody] ListTravelTour value)
        {
            if (!ModelState.IsValid)
            {
                return "error";
            }
            return "";
        }

    }
}
