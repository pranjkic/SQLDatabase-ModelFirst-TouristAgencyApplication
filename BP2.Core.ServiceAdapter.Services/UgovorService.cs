using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BP2.Core.Model;
using BP2.Repository.DB;
using BP2.Repository.DB.DAO;

namespace BP2.Core.ServiceAdapter.Services
{
    public class UgovorService
    {
        UgovorDAO ugovorDAO = new UgovorDAO();

        public void Create(UgovorDTO ugovorDTO)
        {
            Ugovor ugovor = new Ugovor()
            {
                SifraOsiguranja = ugovorDTO.SifraOsiguranja,

                PutovanjeKojeNudiTuristickaAgencijaPutovanjeId = ugovorDTO.PutovanjeId,
                PutovanjeKojeNudiTuristickaAgencijaTuristickaAgencijaId = ugovorDTO.PutovanjeTAId,
                PutovanjeKojeNudiTuristickaAgencijaVodicId = ugovorDTO.PutovanjeVodicId,

                KlijentKojiPoslujeSaFilijalomKlijentId = ugovorDTO.KlijentId,
                KlijentKojiPoslujeSaFilijalomFilijalaId = ugovorDTO.KlijentFilijalaId,
                KlijentKojiPoslujeSaFilijalomFilijalaTuristickaAgencijaId = ugovorDTO.KlijentTAId,

                SekretaricaId = ugovorDTO.SekretaricaId
            };
            ugovorDAO.Insert(ugovor);
        }

        public BindingList<UgovorDTO> GetAll()
        {
            List<Ugovor> all = ugovorDAO.GetAll();
            BindingList<UgovorDTO> allDTO = new BindingList<UgovorDTO>();
            foreach (Ugovor ugovor in all)
            {
                UgovorDTO ugovorDTO = new UgovorDTO()
                {
                    Id = ugovor.Id,
                    SifraOsiguranja = ugovor.SifraOsiguranja,

                    PutovanjeId = ugovor.PutovanjeKojeNudiTuristickaAgencijaPutovanjeId,
                    PutovanjeTAId = ugovor.PutovanjeKojeNudiTuristickaAgencijaTuristickaAgencijaId,
                    PutovanjeVodicId = ugovor.PutovanjeKojeNudiTuristickaAgencijaVodicId,

                    KlijentId = ugovor.KlijentKojiPoslujeSaFilijalomKlijentId,
                    KlijentFilijalaId = ugovor.KlijentKojiPoslujeSaFilijalomFilijalaId,
                    KlijentTAId = ugovor.KlijentKojiPoslujeSaFilijalomFilijalaTuristickaAgencijaId,

                    SekretaricaId = ugovor.SekretaricaId
                };
                allDTO.Add(ugovorDTO);
            }
            return allDTO;
        }

        public void Remove(int id)
        {
            ugovorDAO.Delete(id);
        }
    }
}
