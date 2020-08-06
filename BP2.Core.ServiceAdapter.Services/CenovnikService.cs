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
    public class CenovnikService
    {
        CenovnikDAO cenovnikDAO = new CenovnikDAO();

        public CenovnikDTO FindById(object id)
        {
            Cenovnik cenovnik = cenovnikDAO.FindById(id);
            CenovnikDTO cenovnikDTO = new CenovnikDTO()
            {
                Id = cenovnik.Id,
                StartDate = cenovnik.PocetakVazenja,
                EndDate = cenovnik.KrajVazenja
            };
            return cenovnikDTO;
        }

        public void Create(CenovnikDTO cenovnikDTO)
        {
            Cenovnik cenovnik = new Cenovnik()
            {
                PocetakVazenja = cenovnikDTO.StartDate,
                KrajVazenja = cenovnikDTO.EndDate
            };
            cenovnikDAO.Insert(cenovnik);
        }

        public BindingList<CenovnikDTO> GetAll()
        {
            List<Cenovnik> all = cenovnikDAO.GetAll();
            BindingList<CenovnikDTO> allDTO = new BindingList<CenovnikDTO>();
            foreach (Cenovnik cenovnik in all)
            {
                CenovnikDTO cenovnikDTO = new CenovnikDTO()
                {
                    Id = cenovnik.Id,
                    StartDate = cenovnik.PocetakVazenja,
                    EndDate = cenovnik.KrajVazenja
                };
                allDTO.Add(cenovnikDTO);
            }
            return allDTO;
        }

        public bool Remove(int id)
        {
            return cenovnikDAO.Delete(id);
        }

        public void Update(CenovnikDTO cenovnikDTO)
        {
            Cenovnik cenovnik = new Cenovnik()
            {
                Id = cenovnikDTO.Id,
                PocetakVazenja = cenovnikDTO.StartDate,
                KrajVazenja = cenovnikDTO.EndDate
            };
            cenovnikDAO.Update(cenovnik);
        }
    }
}
