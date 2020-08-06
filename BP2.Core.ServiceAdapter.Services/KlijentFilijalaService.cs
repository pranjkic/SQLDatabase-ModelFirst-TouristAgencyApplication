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
    public class KlijentFilijalaService
    {
        KlijentFilijalaDAO klijentFilijalaDAO = new KlijentFilijalaDAO();

        public BindingList<KlijentFilijalaDTO> GetAll()
        {
            List<KlijentKojiPoslujeSaFilijalom> all = klijentFilijalaDAO.GetAll();
            BindingList<KlijentFilijalaDTO> allDTO = new BindingList<KlijentFilijalaDTO>();
            foreach (KlijentKojiPoslujeSaFilijalom  klijentKojiPoslujeSaFilijalom in all)
            {
                KlijentFilijalaDTO klijentFilijala = new KlijentFilijalaDTO()
                {
                    KlijentId = klijentKojiPoslujeSaFilijalom.KlijentId,
                    IdFilijala = klijentKojiPoslujeSaFilijalom.FilijalaId,
                    IdTA = klijentKojiPoslujeSaFilijalom.FilijalaTuristickaAgencijaId
                };
                allDTO.Add(klijentFilijala);
            }
            return allDTO;
        }

        public BindingList<KlijentFilijalaDTO> GetAllById(int taId)
        {
            List<KlijentKojiPoslujeSaFilijalom> all = klijentFilijalaDAO.GetAllById(taId);
            BindingList<KlijentFilijalaDTO> allDTO = new BindingList<KlijentFilijalaDTO>();
            foreach (KlijentKojiPoslujeSaFilijalom klijentKojiPoslujeSaFilijalom in all)
            {
                KlijentFilijalaDTO klijentFilijala = new KlijentFilijalaDTO()
                {
                    KlijentId = klijentKojiPoslujeSaFilijalom.KlijentId,
                    IdFilijala = klijentKojiPoslujeSaFilijalom.FilijalaId,
                    IdTA = klijentKojiPoslujeSaFilijalom.FilijalaTuristickaAgencijaId
                };
                allDTO.Add(klijentFilijala);
            }
            return allDTO;
        }

        public bool Create(KlijentFilijalaDTO klijentFilijalaDTO)
        {
            KlijentKojiPoslujeSaFilijalom klijentKojiPoslujeSaFilijalom = new KlijentKojiPoslujeSaFilijalom()
            {
                KlijentId = klijentFilijalaDTO.KlijentId,
                FilijalaId = klijentFilijalaDTO.IdFilijala,
                FilijalaTuristickaAgencijaId = klijentFilijalaDTO.IdTA
            };
            return klijentFilijalaDAO.Insert(klijentKojiPoslujeSaFilijalom);
        }

        public bool Remove(int klijentId, int filijalaId, int taId)
        {
            return klijentFilijalaDAO.DeleteCustom(klijentId, filijalaId, taId);
        }
    }
}
