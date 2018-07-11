using PayEasyApi.BL.Interfaces;
using PayEasyApi.DA.Interfaces;
using PayEasyApi.DA.Repositories.DataTableMobile2;
using PayEasyApi.Models.Mobile2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayEasyApi.BL.Services
{
    public class MobileService : IMobileService
    {
        public IMobileRepository MobileRepository { get; set; }

        public MobileService()
            : this(new MobileRepository())
        {

        }

        public MobileService(IMobileRepository mobileRepository)
        {
            this.MobileRepository=mobileRepository;
        }

        public IEnumerable<HotelsModel> GetHotels(){
            return this.MobileRepository.GetHotels();
        }
    }
}
