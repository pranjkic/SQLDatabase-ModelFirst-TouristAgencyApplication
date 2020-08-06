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
    public class RadnikService
    {
        RadnikDAO radnikDAO = new RadnikDAO();

        public void Create(RadnikDTO radnikDTO)
        {
            Radnik radnik = null;

            if (radnikDTO.TipRadnika == "Sekretarica")
            {
                radnik = new Sekretarica()
                {
                    Ime = radnikDTO.Ime,
                    Prezime = radnikDTO.Prezime,
                    JMBG = radnikDTO.Jmbg,
                    FilijalaId = radnikDTO.IdFilijala,
                    FilijalaTuristickaAgencijaId = radnikDTO.IdTA
                };
            }
            else if (radnikDTO.TipRadnika == "Menadzer")
            {
                Menadzer menadzer = new Menadzer()
                {
                    Ime = radnikDTO.Ime,
                    Prezime = radnikDTO.Prezime,
                    JMBG = radnikDTO.Jmbg,
                    FilijalaId = radnikDTO.IdFilijala,
                    FilijalaTuristickaAgencijaId = radnikDTO.IdTA
                };
                radnikDAO.InsertCustom(menadzer);
                return;
            }
            else if (radnikDTO.TipRadnika == "Vodic")
            {
                radnik = new Vodic()
                {
                    Ime = radnikDTO.Ime,
                    Prezime = radnikDTO.Prezime,
                    JMBG = radnikDTO.Jmbg,
                    FilijalaId = radnikDTO.IdFilijala,
                    FilijalaTuristickaAgencijaId = radnikDTO.IdTA
                };
            }

            radnikDAO.Insert(radnik);
        }

        public BindingList<RadnikDTO> GetAll()
        {
            List<Radnik> all = radnikDAO.GetAll();
            BindingList<RadnikDTO> allDTO = new BindingList<RadnikDTO>();
            foreach (Radnik radnik in all)
            {
                //string type = null;
                //if (radnik.GetType().ToString().Contains("Menadzer"))
                //    type = "Menadzer";
                //else if (radnik.GetType().ToString().Contains("Vodic"))
                //    type = "Vodic";
                //else if (radnik.GetType().ToString().Contains("Sekretarica"))
                //    type = "Sekretarica";
                RadnikDTO radnikDTO;
                if (radnik.GetType().ToString().Contains("Vodic"))
                {
                    List<AllVodicsPutovanja_Result> destinacije = radnikDAO.GetDestinacije(radnik.Id);
                    string s = "";
                    destinacije.ForEach(x => s += $"{x.Destinacija},");
                    radnikDTO = new RadnikDTO()
                    {
                        Id = radnik.Id,
                        Ime = radnik.Ime,
                        Prezime = radnik.Prezime,
                        Jmbg = radnik.JMBG,
                        Destinacije = s,
                        BrojPutovanja = radnikDAO.GetBrojPutovanja(radnik.Id),
                        IdFilijala = radnik.FilijalaId,
                        IdTA = radnik.FilijalaTuristickaAgencijaId,
                        TipRadnika = radnik.GetType().ToString().Split('.')[4].Split('_')[0],
                    };
                }
                else
                {
                    radnikDTO = new RadnikDTO()
                    {
                        Id = radnik.Id,
                        Ime = radnik.Ime,
                        Prezime = radnik.Prezime,
                        Jmbg = radnik.JMBG,
                        Destinacije = "None",
                        BrojPutovanja = 0,
                        IdFilijala = radnik.FilijalaId,
                        IdTA = radnik.FilijalaTuristickaAgencijaId,
                        TipRadnika = radnik.GetType().ToString().Split('.')[4].Split('_')[0],
                    };
                }

                
                allDTO.Add(radnikDTO);
            }
            return allDTO;
        }

        public BindingList<RadnikDTO> GetAllSekretarice(int taId)
        {
            List<Radnik> all = radnikDAO.GetAll();
            BindingList<RadnikDTO> allSekretarice = new BindingList<RadnikDTO>();
            foreach (Radnik radnik in all)
            {
                if(radnik.FilijalaTuristickaAgencijaId == taId && radnik.GetType().ToString().Split('.')[4].Split('_')[0] == "Sekretarica")
                {
                    RadnikDTO radnikDTO = new RadnikDTO()
                    {
                        Id = radnik.Id,
                        Ime = radnik.Ime,
                        Prezime = radnik.Prezime,
                        Jmbg = radnik.JMBG,
                        IdFilijala = radnik.FilijalaId,
                        IdTA = radnik.FilijalaTuristickaAgencijaId,
                        TipRadnika = radnik.GetType().ToString().Split('.')[4].Split('_')[0],
                    };
                    allSekretarice.Add(radnikDTO);
                }
            }
            return allSekretarice;
        }

        public BindingList<RadnikDTO> GetAllVodici()
        {
            BindingList<RadnikDTO> allDTO = GetAll();
            BindingList<RadnikDTO> allVodici = new BindingList<RadnikDTO>();
            foreach (RadnikDTO radnikDTO in allDTO)            
                if (radnikDTO.TipRadnika == "Vodic")
                    allVodici.Add(radnikDTO);
            
            return allVodici;
        }

        public bool Remove(int id)
        {
            return radnikDAO.Delete(id);
        }

        public void Update(RadnikDTO radnikDTO)
        {
            Radnik radnik = null;

            if (radnikDTO.TipRadnika == "Sekretarica")
            {
                radnik = new Sekretarica()
                {
                    Id = radnikDTO.Id,
                    Ime = radnikDTO.Ime,
                    Prezime = radnikDTO.Prezime,
                    JMBG = radnikDTO.Jmbg,
                    FilijalaId = radnikDTO.IdFilijala,
                    FilijalaTuristickaAgencijaId = radnikDTO.IdTA
                };
            }
            else if (radnikDTO.TipRadnika == "Menadzer")
            {
                radnik = new Menadzer()
                {
                    Id = radnikDTO.Id,
                    Ime = radnikDTO.Ime,
                    Prezime = radnikDTO.Prezime,
                    JMBG = radnikDTO.Jmbg,
                    FilijalaId = radnikDTO.IdFilijala,
                    FilijalaTuristickaAgencijaId = radnikDTO.IdTA,                   
                };                
            }
            else if (radnikDTO.TipRadnika == "Vodic")
            {
                radnik = new Vodic()
                {
                    Id = radnikDTO.Id,
                    Ime = radnikDTO.Ime,
                    Prezime = radnikDTO.Prezime,
                    JMBG = radnikDTO.Jmbg,
                    FilijalaId = radnikDTO.IdFilijala,
                    FilijalaTuristickaAgencijaId = radnikDTO.IdTA
                };
            }
            radnikDAO.Update(radnik);
        }

        public RadnikDTO FindById(object id)
        {
            Radnik radnik = radnikDAO.FindById(id);
            RadnikDTO radnikDTO = new RadnikDTO()
            {
                Id = radnik.Id,
                Ime = radnik.Ime,
                Prezime = radnik.Prezime
            };
            return radnikDTO;
        }
    }
}
