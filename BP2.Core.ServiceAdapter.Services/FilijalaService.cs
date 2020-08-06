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
    public class FilijalaService
    {
        FilijalaDAO filijalaDAO = new FilijalaDAO();

        public void Create(FilijalaDTO filijalaDTO, TuristickaAgencijaDTO turistickaAgencijaDTO)
        {
            Filijala filijala = new Filijala()
            {
                Naziv = filijalaDTO.Naziv,
                Adresa = filijalaDTO.Adresa,
                Grad = filijalaDTO.Grad,
                Email = filijalaDTO.Email,
                TuristickaAgencijaId = turistickaAgencijaDTO.Id
            };
            filijalaDAO.Insert(filijala);
        }

        public BindingList<FilijalaDTO> GetAll()
        {
            List<Filijala> all = filijalaDAO.GetAllCustom();
            BindingList<FilijalaDTO> allDTO = new BindingList<FilijalaDTO>();
            foreach (Filijala filijala in all)
            {
                FilijalaDTO filijalaDTO = new FilijalaDTO()
                {
                    Id = filijala.Id,
                    Naziv = filijala.Naziv,
                    Grad = filijala.Grad,
                    Adresa = filijala.Adresa,
                    Email = filijala.Email,
                    IdTA = filijala.TuristickaAgencijaId,
                    NazivTA = filijala.TuristickaAgencija.Naziv
                };
                allDTO.Add(filijalaDTO);
            }
            return allDTO;
        }

        public void Remove(int id, int idTA)
        {
            filijalaDAO.DeleteCustom(id, idTA);
        }

        public void Update(FilijalaDTO filijalaDTO)
        {
            Filijala filijala = new Filijala()
            {
                Id = filijalaDTO.Id,
                Naziv = filijalaDTO.Naziv,
                Adresa = filijalaDTO.Adresa,
                Grad = filijalaDTO.Grad,
                Email = filijalaDTO.Email,
                TuristickaAgencijaId = filijalaDTO.IdTA
            };
            filijalaDAO.UpdateCustom(filijala);
        }

        public FilijalaDTO FindById(int id, int idTA)
        {
            Filijala filijala = filijalaDAO.FindByIdCustom(id, idTA);
            FilijalaDTO filijalaDTO = new FilijalaDTO()
            {
                Id = filijala.Id,
                Naziv = filijala.Naziv,
                Grad = filijala.Grad,
                Adresa = filijala.Adresa,
                Email = filijala.Email,
                IdTA = filijala.TuristickaAgencijaId
            };
            return filijalaDTO;
        }
    }
}
