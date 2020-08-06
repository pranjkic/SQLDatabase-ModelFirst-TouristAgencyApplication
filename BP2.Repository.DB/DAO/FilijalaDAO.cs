using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Repository.DB.DAO
{
    public class FilijalaDAO : BaseRepo<Filijala>
    {
        public List<Filijala> GetAllCustom()
        {
            using (var db = new ModelBP2Container())
            {
                List<Filijala> filijalas = db.FilijalaSet.ToList();
                foreach(Filijala filijala in filijalas)
                {
                    filijala.TuristickaAgencija = db.TuristickaAgencijaSet.Find(filijala.TuristickaAgencijaId);
                }
                return filijalas;
            }
        }

        public void DeleteCustom(int id, int idTA)
        {
            using (var db = new ModelBP2Container())
            {
                Filijala filijalaToDelete = db.FilijalaSet.SingleOrDefault(o => o.Id == id && o.TuristickaAgencijaId == idTA);
                db.Entry(filijalaToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void UpdateCustom(Filijala filijala)
        {
            using (var db = new ModelBP2Container())
            {
                Filijala filijalaToUpdate = db.FilijalaSet.SingleOrDefault(o => o.Id == filijala.Id && o.TuristickaAgencijaId == filijala.TuristickaAgencijaId);
                filijalaToUpdate.Naziv = filijala.Naziv;
                filijalaToUpdate.Grad = filijala.Grad;
                filijalaToUpdate.Adresa = filijala.Adresa;
                filijalaToUpdate.Email = filijala.Email;
                //filijalaToUpdate.TuristickaAgencijaId = filijala.TuristickaAgencijaId;
                db.Entry(filijalaToUpdate).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Filijala FindByIdCustom(int id, int idTA)
        {
            using (var db = new ModelBP2Container())
            {
                return db.FilijalaSet.SingleOrDefault(o => o.Id == id && o.TuristickaAgencijaId == idTA);
            }
        }

        public List<Filijala> GetAllById(int taId)
        {
            using (var db = new ModelBP2Container())
            {
                return db.FilijalaSet.Where(o => o.TuristickaAgencijaId == taId).ToList();
            }
        }
    }
}
