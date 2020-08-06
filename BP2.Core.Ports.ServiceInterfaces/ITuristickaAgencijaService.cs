using BP2.Repository.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Core.Ports.ServiceInterfaces
{
    public interface ITuristickaAgencijaService
    {
        
        TuristickaAgencija GetTuristickaAgencijaById(int turistickaAgencijaId);
        IEnumerable<TuristickaAgencija> GetAllTuristickeAgencije();
        
    }
}
