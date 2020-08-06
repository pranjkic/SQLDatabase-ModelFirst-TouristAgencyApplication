using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Repository.DB.DAO
{
    public class RadnikDAO : BaseRepo<Radnik>
    {
        public void InsertCustom(Menadzer radnik)
        {
            using (var db = new ModelBP2Container())
            {
                radnik.Filijala1 = db.FilijalaSet.SingleOrDefault(x => x.Id == radnik.FilijalaId && x.TuristickaAgencijaId == radnik.FilijalaTuristickaAgencijaId);
                db.RadnikSet.Add(radnik);
                db.SaveChanges();
            }
        }

        public int GetBrojPutovanja(int vodicId)
        {
            using (var db = new ModelBP2Container())
            {
                ObjectParameter retval = new ObjectParameter("count", typeof(Int32));
                db.GetVodicsPutovanja(vodicId, retval);

                return Convert.ToInt32(retval.Value);
            }
        }

        public List<AllVodicsPutovanja_Result> GetDestinacije(int vodicId)
        {
            using (var db = new ModelBP2Container())
            {
                ObjectParameter retval = new ObjectParameter("count", typeof(Int32));
                List<AllVodicsPutovanja_Result> dest = db.AllVodicsPutovanja(vodicId).ToList();

                return dest;
            }
        }
    }
}
