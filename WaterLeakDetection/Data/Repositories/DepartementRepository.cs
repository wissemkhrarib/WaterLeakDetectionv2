using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLeakDetection.Data.Interfaces;
using WaterLeakDetection.Data.Modals;

namespace WaterLeakDetection.Data.Repositories
{
    public class DepartementRepository : IDepartementRepository
    {
        private readonly AppDbContext _appDbContext;
        public DepartementRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Departement departement)
        {
            _appDbContext.Add(departement);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var departement = GetDepartementById(id);
            _appDbContext.Departements.Remove(departement);
            _appDbContext.SaveChanges();
         }

        public IEnumerable<Departement> GetAllDepartments()
        {
            return _appDbContext.Departements;
        }

        public Departement GetDepartementById(int id)
        {
            return _appDbContext.Departements.FirstOrDefault(d=>d.Id==id);
        }

    }
}
