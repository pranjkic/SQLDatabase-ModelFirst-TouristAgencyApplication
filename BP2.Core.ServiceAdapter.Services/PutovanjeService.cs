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
    public class PutovanjeService
    {
        PutovanjeDAO putovanjeDAO = new PutovanjeDAO();

        public void Create(string destination)
        {
            Putovanje putovanje = new Putovanje() { Destinacija = destination };
            putovanjeDAO.Insert(putovanje);
        }

        public BindingList<PutovanjeDTO> GetAll()
        {
            List<Putovanje> all = putovanjeDAO.GetAll();
            BindingList<PutovanjeDTO> allDAO = new BindingList<PutovanjeDTO>();
            foreach(Putovanje putovanje in all)
            {
                PutovanjeDTO putovanjeDAO = new PutovanjeDTO()
                {
                    Id = putovanje.Id,
                    Destinacija = putovanje.Destinacija
                };
                allDAO.Add(putovanjeDAO);
            }
            return allDAO;
        }

        public bool Remove(int id)
        {
            return putovanjeDAO.Delete(id);
        }

        public void Update(PutovanjeDTO putovanjeDTO)
        {
            Putovanje putovanje = new Putovanje()
            {
                Id = putovanjeDTO.Id,
                Destinacija = putovanjeDTO.Destinacija
            };
            putovanjeDAO.Update(putovanje);
        }

        public PutovanjeDTO FindById(object id)
        {
            Putovanje putovanje = putovanjeDAO.FindById(id);
            PutovanjeDTO putovanjeDTO = new PutovanjeDTO()
            {
                Id = putovanje.Id,
                Destinacija = putovanje.Destinacija
            };
            return putovanjeDTO;
        }
    }
}
