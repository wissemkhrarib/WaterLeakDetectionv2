using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLeakDetection.Data.Modals;

namespace WaterLeakDetection.Data.Interfaces
{
    public interface IDepartementRepository
    {
        public IEnumerable<Departement> GetAllDepartments();
        public Departement GetDepartementById(int id);
        public void Add(Departement departement);
        public void Delete(int id);

    }
}
