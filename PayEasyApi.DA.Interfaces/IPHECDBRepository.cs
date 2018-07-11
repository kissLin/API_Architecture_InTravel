using PayEasyApi.Models.PHECDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayEasyApi.DA.Interfaces
{
    public interface IPHECDBRepository
    {
        IEnumerable<ChangeHOTELModel> GetChangeHOTEL();
    }
}
