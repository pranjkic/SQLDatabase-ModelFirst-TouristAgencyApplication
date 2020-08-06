using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Repository.DB.DAO
{
    public class UsvojiPutovanjeDAO : BaseRepo<PutovanjeKojeNudiTuristickaAgencija>
    {
        public bool DeleteCustom(int idTA, int idPutovanja, int vodicId)
        {
            try
            {
                using (var db = new ModelBP2Container())
                {
                    PutovanjeKojeNudiTuristickaAgencija putovanjeKojeNudiTuristickaAgencija = db.PutovanjeKojeTuristickaAgencijaNudiSet.SingleOrDefault(o => o.TuristickaAgencijaId == idTA && o.PutovanjeId == idPutovanja && o.VodicId == vodicId);
                    db.Entry(putovanjeKojeNudiTuristickaAgencija).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }            
        }

        public void UpdateCustom(PutovanjeKojeNudiTuristickaAgencija oldPutovanje)
        {
            using (var db = new ModelBP2Container())
            {
                PutovanjeKojeNudiTuristickaAgencija pknta = db.PutovanjeKojeTuristickaAgencijaNudiSet.SingleOrDefault(o => o.TuristickaAgencijaId == oldPutovanje.TuristickaAgencijaId && o.PutovanjeId == oldPutovanje.PutovanjeId && o.VodicId == oldPutovanje.VodicId);
                pknta.DatumDolaska = oldPutovanje.DatumDolaska;
                pknta.Trajanje = oldPutovanje.Trajanje;
                pknta.CenaPutovanja = oldPutovanje.CenaPutovanja;
                pknta.NazivSmestaja = oldPutovanje.NazivSmestaja;
                db.Entry(pknta).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<PutovanjeKojeNudiTuristickaAgencija> GetAllById(int taId)
        {
            using (var db = new ModelBP2Container())
            {
                return db.PutovanjeKojeTuristickaAgencijaNudiSet.Where(o => o.TuristickaAgencijaId == taId).ToList();
            }
        }
    }
}
