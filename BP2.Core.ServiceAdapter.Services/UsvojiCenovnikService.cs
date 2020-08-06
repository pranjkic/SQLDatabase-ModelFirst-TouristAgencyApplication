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
    public class UsvojiCenovnikService
    {
        UsvojiCenovnikDAO usvojiCenovnikDAO = new UsvojiCenovnikDAO();

        public bool Create(UsvojiCenovnikDTO usvojiCenovnikDTO)
        {
            CenovnikKojiTuristickaAgencijaFormira cenovnik = new CenovnikKojiTuristickaAgencijaFormira()
            {
                KoeficijentNaplate = usvojiCenovnikDTO.KoeficijentNaplate,
                TuristickaAgencijaId = usvojiCenovnikDTO.IdTA,
                CenovnikId = usvojiCenovnikDTO.IdCenovnik
            };
            return usvojiCenovnikDAO.Insert(cenovnik);
        }

        public BindingList<UsvojiCenovnikDTO> GetAll()
        {
            List<CenovnikKojiTuristickaAgencijaFormira> all = usvojiCenovnikDAO.GetAll();
            BindingList<UsvojiCenovnikDTO> allDTO = new BindingList<UsvojiCenovnikDTO>();
            foreach (CenovnikKojiTuristickaAgencijaFormira cenovnikKojiTuristickaAgencijaFormira in all)
            {
                UsvojiCenovnikDTO usvojiCenovnikDTO = new UsvojiCenovnikDTO()
                {
                    IdTA = cenovnikKojiTuristickaAgencijaFormira.TuristickaAgencijaId,
                    IdCenovnik = cenovnikKojiTuristickaAgencijaFormira.CenovnikId,
                    KoeficijentNaplate = cenovnikKojiTuristickaAgencijaFormira.KoeficijentNaplate
                };
                allDTO.Add(usvojiCenovnikDTO);
            }
            return allDTO;
        }

        public void Remove(int idTA, int idCenovnik)
        {
            usvojiCenovnikDAO.DeleteCustom(idTA, idCenovnik);
        }

        public void Update(UsvojiCenovnikDTO usvojiCenovnikDTO)
        {
            CenovnikKojiTuristickaAgencijaFormira cenovnikKojiTuristickaAgencijaFormira = new CenovnikKojiTuristickaAgencijaFormira()
            {
                TuristickaAgencijaId = usvojiCenovnikDTO.IdTA,
                CenovnikId = usvojiCenovnikDTO.IdCenovnik,
                KoeficijentNaplate = usvojiCenovnikDTO.KoeficijentNaplate
            };
            usvojiCenovnikDAO.UpdateCustom(cenovnikKojiTuristickaAgencijaFormira);
        }
    }
}
