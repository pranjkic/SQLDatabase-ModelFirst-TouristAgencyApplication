using BP2.Core.Model;
using BP2.Repository.DB;
using BP2.Repository.DB.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Core.ServiceAdapter.Services
{
    public class KlijentService
    {
        KlijentDAO klijentDAO = new KlijentDAO();

        public void Create(string name, string lastName, string passport)
        {
            Klijent klijent = new Klijent()
            {
                Ime = name,
                Prezime = lastName,
                BrojPasosa = passport
            };
            klijentDAO.Insert(klijent);
        }

        public BindingList<KlijentDTO> GetAll()
        {
            List<Klijent> all = klijentDAO.GetAll();
            BindingList<KlijentDTO> allDTO = new BindingList<KlijentDTO>();
            foreach (Klijent klijent in all)
            {
                KlijentDTO klijentDAO = new KlijentDTO()
                {
                    Id = klijent.Id,
                    Ime = klijent.Ime,
                    Prezime = klijent.Prezime,
                    BrojPasosa = klijent.BrojPasosa
                };
                allDTO.Add(klijentDAO);
            }
            return allDTO;
        }

        public bool Remove(int id)
        {
            return klijentDAO.Delete(id);
        }

        public void Update(KlijentDTO klijentDTO)
        {
            Klijent Klijent = new Klijent()
            {
                Id = klijentDTO.Id,
                Ime = klijentDTO.Ime,
                Prezime = klijentDTO.Prezime,
                BrojPasosa = klijentDTO.BrojPasosa
            };
            klijentDAO.Update(Klijent);
        }

        public KlijentDTO FindById(object id)
        {
            Klijent klijent = klijentDAO.FindById(id);
            KlijentDTO klijentDTO = new KlijentDTO()
            {
                Id = klijent.Id,
                Ime = klijent.Ime,
                Prezime = klijent.Prezime
            };

            return klijentDTO;
        }
    }
}
