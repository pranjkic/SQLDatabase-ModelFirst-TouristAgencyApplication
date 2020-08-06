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
    public class UsvojiPutovanjeService
    {
        UsvojiPutovanjeDAO usvojiPutovanjeDAO = new UsvojiPutovanjeDAO();

        public void Create(UsvojenoPutovanje usvojenoPutovanje)
        {
            PutovanjeKojeNudiTuristickaAgencija putovanjeKojeNudiTuristickaAgencija = new PutovanjeKojeNudiTuristickaAgencija()
            {
                TuristickaAgencijaId = usvojenoPutovanje.TaId,
                PutovanjeId = usvojenoPutovanje.DestinationId,
                VodicId = usvojenoPutovanje.GuideId,
                DatumDolaska = usvojenoPutovanje.StartDate,
                Trajanje = usvojenoPutovanje.Duration,
                CenaPutovanja = usvojenoPutovanje.Price,
                NazivSmestaja = usvojenoPutovanje.Accomodation
            };
            usvojiPutovanjeDAO.Insert(putovanjeKojeNudiTuristickaAgencija);
        }

        public BindingList<UsvojenoPutovanje> GetAll()
        {
            List<PutovanjeKojeNudiTuristickaAgencija> all = usvojiPutovanjeDAO.GetAll();
            BindingList<UsvojenoPutovanje> allDTO = new BindingList<UsvojenoPutovanje>();
            foreach (PutovanjeKojeNudiTuristickaAgencija putovanjeKojeNudiTuristickaAgencija in all)
            {
                UsvojenoPutovanje usvojenoPutovanje = new UsvojenoPutovanje()
                {
                    TaId = putovanjeKojeNudiTuristickaAgencija.TuristickaAgencijaId,
                    DestinationId = putovanjeKojeNudiTuristickaAgencija.PutovanjeId,
                    GuideId = putovanjeKojeNudiTuristickaAgencija.VodicId,
                    StartDate = putovanjeKojeNudiTuristickaAgencija.DatumDolaska,
                    Duration = putovanjeKojeNudiTuristickaAgencija.Trajanje,
                    Price = putovanjeKojeNudiTuristickaAgencija.CenaPutovanja,
                    Accomodation = putovanjeKojeNudiTuristickaAgencija.NazivSmestaja
                };
                allDTO.Add(usvojenoPutovanje);
            }
            return allDTO;
        }

        public BindingList<UsvojenoPutovanje> GetAllById(int taId)
        {
            List<PutovanjeKojeNudiTuristickaAgencija> all = usvojiPutovanjeDAO.GetAllById(taId);
            BindingList<UsvojenoPutovanje> allDTO = new BindingList<UsvojenoPutovanje>();
            foreach (PutovanjeKojeNudiTuristickaAgencija putovanjeKojeNudiTuristickaAgencija in all)
            {
                UsvojenoPutovanje usvojenoPutovanje = new UsvojenoPutovanje()
                {
                    TaId = putovanjeKojeNudiTuristickaAgencija.TuristickaAgencijaId,
                    DestinationId = putovanjeKojeNudiTuristickaAgencija.PutovanjeId,
                    GuideId = putovanjeKojeNudiTuristickaAgencija.VodicId,
                    StartDate = putovanjeKojeNudiTuristickaAgencija.DatumDolaska,
                    Duration = putovanjeKojeNudiTuristickaAgencija.Trajanje,
                    Price = putovanjeKojeNudiTuristickaAgencija.CenaPutovanja,
                    Accomodation = putovanjeKojeNudiTuristickaAgencija.NazivSmestaja
                };
                allDTO.Add(usvojenoPutovanje);
            }
            return allDTO;
        }

        public bool Remove(int TAID, int putovanjeId, int vodicId)
        {
            return usvojiPutovanjeDAO.DeleteCustom(TAID, putovanjeId, vodicId);
        }

        public void Update(UsvojenoPutovanje usvojenoPutovanje)
        {
            PutovanjeKojeNudiTuristickaAgencija putovanjeKojeNudiTuristickaAgencija = new PutovanjeKojeNudiTuristickaAgencija()
            {
                TuristickaAgencijaId = usvojenoPutovanje.TaId,
                PutovanjeId = usvojenoPutovanje.DestinationId,
                VodicId = usvojenoPutovanje.GuideId,
                DatumDolaska = usvojenoPutovanje.StartDate,
                Trajanje = usvojenoPutovanje.Duration,
                CenaPutovanja = usvojenoPutovanje.Price,
                NazivSmestaja = usvojenoPutovanje.Accomodation
            };
            usvojiPutovanjeDAO.UpdateCustom(putovanjeKojeNudiTuristickaAgencija);
        }
    }
}
