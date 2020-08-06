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
    public class TuristickaAgencijaService
    {

        TuristickaAgencijaDAO turistickaAgencijaDAO = new TuristickaAgencijaDAO();

        public TuristickaAgencijaDTO FindById(object id)
        {
            TuristickaAgencija turistickaAgencija = turistickaAgencijaDAO.FindById(id);
            TuristickaAgencijaDTO turistickaAgencijaDTO = new TuristickaAgencijaDTO()
            {
                Id = turistickaAgencija.Id,
                Naziv = turistickaAgencija.Naziv
            };
            return turistickaAgencijaDTO;
        }

        public void Create(string name)
        {
            TuristickaAgencija turistickaAgencija = new TuristickaAgencija()
            {
                Naziv = name
            };
            turistickaAgencijaDAO.Insert(turistickaAgencija);        
        }

        public BindingList<TuristickaAgencijaDTO> GetAll()
        {
            List<TuristickaAgencija> all = turistickaAgencijaDAO.GetAll();
            BindingList<TuristickaAgencijaDTO> allDTO = new BindingList<TuristickaAgencijaDTO>();
            foreach(TuristickaAgencija turistickaAgencija in all)
            {
                TuristickaAgencijaDTO turistickaAgencijaDTO = new TuristickaAgencijaDTO()
                {
                    Id = turistickaAgencija.Id,
                    Naziv = turistickaAgencija.Naziv
                };
                allDTO.Add(turistickaAgencijaDTO);
            }
            return allDTO;
        }

        public bool Remove(int id)
        {
            return turistickaAgencijaDAO.Delete(id);
        }

        public void Update(TuristickaAgencijaDTO turistickaAgencijaDTO)
        {
            TuristickaAgencija turistickaAgencija = new TuristickaAgencija()
            {
                Id = turistickaAgencijaDTO.Id,
                Naziv = turistickaAgencijaDTO.Naziv
            };
            turistickaAgencijaDAO.Update(turistickaAgencija);
        }
    }
}
