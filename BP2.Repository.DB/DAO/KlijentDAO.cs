using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Repository.DB.DAO
{
    public class KlijentDAO : BaseRepo<Klijent>
    {
        //public bool InsertCustom(Klijent klijent, int filijalaId, int taId)
        //{
        //    try
        //    {
        //        using (var db = new ModelBP2Container())
        //        {
        //            db.KlijentSet.Add(klijent);
        //            db.SaveChanges();
        //            KlijentKojiPoslujeSaFilijalom kpf = new KlijentKojiPoslujeSaFilijalom() { KlijentId = klijent.Id, FilijalaId = filijalaId, FilijalaTuristickaAgencijaId = taId };
        //            db.KlijentKojiPoslujeSaFilijalomSet.Add(kpf);
        //            db.SaveChanges();
        //        }
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }
        //}

        //public bool DeleteCustom(int id)
        //{
        //    try
        //    {
        //        using (var db = new ModelBP2Container())
        //        {
        //            Klijent entityToDelete = db.KlijentSet.Find(id);
        //            db.Entry(entityToDelete).State = EntityState.Deleted;
        //            db.SaveChanges();
        //        }
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
