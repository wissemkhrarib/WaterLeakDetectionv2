using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLeakDetection.Data.Interfaces;
using WaterLeakDetection.Data.Modals;

namespace WaterLeakDetection.Data.Mocks
{
    public class MockDepartmentRepository : IDepartementRepository
    {
        private readonly IEnumerable<Departement> departements;
        private readonly MockSensorRepository sensorRepository = new MockSensorRepository();
        public MockDepartmentRepository()
        {
            departements = new List<Departement>
            {
                new Departement{Id=1,Name="Mechanical Departement",Sensors=sensorRepository.GetAllSensors().Where(s=>s.Name.Contains("SM"))},
                new Departement{Id=2,Name="Electrical Departement",Sensors=sensorRepository.GetAllSensors().Where(s=>s.Name.Contains("SE"))},
                new Departement{Id=3,Name="Civil Departement",Sensors=sensorRepository.GetAllSensors()},
            };
        }

        public void Add(Departement departement)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Departement> GetAllDepartments()
        {
            return departements;
        }

        public Departement GetDepartementById(int id)
        {
            return departements.FirstOrDefault(d => d.Id == id);
        }
    }
}
