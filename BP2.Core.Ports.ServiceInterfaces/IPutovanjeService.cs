using BP2.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Core.Ports.ServiceInterfaces
{
    public interface IPutovanjeService
    {
        void Create(PutovanjeDTO putovanje);
        void Update(int id, PutovanjeDTO putovanje);
        void Remove(int id);
        BindingList<PutovanjeDTO> GetAll();
    }
}
