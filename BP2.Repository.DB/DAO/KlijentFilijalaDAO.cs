using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Repository.DB.DAO
{
    public class KlijentFilijalaDAO : BaseRepo<KlijentKojiPoslujeSaFilijalom>
    {
        public bool DeleteCustom(int klijentId, int filijalaId, int taId)
        {
            try
            {
                using (var db = new ModelBP2Container())
                {
                    KlijentKojiPoslujeSaFilijalom kpf = db.KlijentKojiPoslujeSaFilijalomSet.SingleOrDefault(o => o.KlijentId == klijentId && o.FilijalaId == filijalaId && o.FilijalaTuristickaAgencijaId == taId);
                    db.Entry(kpf).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<KlijentKojiPoslujeSaFilijalom> GetAllById(int taId)
        {
            using (var db = new ModelBP2Container())
            {
                return db.KlijentKojiPoslujeSaFilijalomSet.Where(o => o.FilijalaTuristickaAgencijaId == taId).ToList();
            }
        }
    }
}
