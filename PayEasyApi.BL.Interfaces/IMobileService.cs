using PayEasyApi.Models.Mobile2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayEasyApi.BL.Interfaces
{
    public interface IMobileService
    {
        IEnumerable<HotelsModel> GetHotels();
    }
}
