using BP2.Repository.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Core.Ports.RepositoryInterfaces
{
    public interface ITuristickaAgencijaRepository
    {
        
        TuristickaAgencija GetTuristickaAgencijaById(TuristickaAgencija turistickaAgencijaId);
        IEnumerable<TuristickaAgencija> GetAllTuristickeAgencije();
        
    }
}
