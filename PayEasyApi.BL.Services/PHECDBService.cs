using PayEasyApi.BL.Interfaces;
using PayEasyApi.DA.Interfaces;
using PayEasyApi.DA.Repositories;
using PayEasyApi.Models.PHECDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayEasyApi.BL.Services
{
    public class PHECDBService : IPHECDBService
    {
        public IPHECDBRepository PHECDBRepository { get; set; }

        public PHECDBService()
            : this(new PHECDBRepository())
        {

        }

        public PHECDBService(IPHECDBRepository phecdbRepository)
        {
            this.PHECDBRepository = phecdbRepository;
        }

        public IEnumerable<ChangeHOTELModel> GetChangeHOTEL()
        {
            return this.PHECDBRepository.GetChangeHOTEL();
        }
    }
}
