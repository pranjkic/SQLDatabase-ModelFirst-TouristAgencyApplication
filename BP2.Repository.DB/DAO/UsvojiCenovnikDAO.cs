using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Repository.DB.DAO
{
    public class UsvojiCenovnikDAO : BaseRepo<CenovnikKojiTuristickaAgencijaFormira>
    {
        public void DeleteCustom(int idTA, int idCenovnik)
        {
            using (var db = new ModelBP2Container())
            {
                CenovnikKojiTuristickaAgencijaFormira cenovnikKojiTuristickaAgencijaFormira = db.CenovnikKojiTuristickaAgencijaFormiraSet.SingleOrDefault(o => o.TuristickaAgencijaId == idTA && o.CenovnikId == idCenovnik);
                db.Entry(cenovnikKojiTuristickaAgencijaFormira).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void UpdateCustom(CenovnikKojiTuristickaAgencijaFormira oldObject)
        {
            using (var db = new ModelBP2Container())
            {
                CenovnikKojiTuristickaAgencijaFormira cktaf = db.CenovnikKojiTuristickaAgencijaFormiraSet.SingleOrDefault(o => o.TuristickaAgencijaId == oldObject.TuristickaAgencijaId && o.CenovnikId == oldObject.CenovnikId);
                cktaf.KoeficijentNaplate = oldObject.KoeficijentNaplate;
                db.Entry(cktaf).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

    }
}
