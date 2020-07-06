using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLeakDetection.Data.Interfaces;
using WaterLeakDetection.Data.Modals;

namespace WaterLeakDetection.Data.Mocks
{
    public class MockSensorRepository : ISensorRepository
    {
        IEnumerable<Sensor> sensors;
        public MockSensorRepository()
        {
            sensors = new List<Sensor>
            {
                new Sensor{Id=1,Name="SE-1"},
                new Sensor{Id=2,Name="SE-2"},
                new Sensor{Id=3,Name="SE-3"},
                new Sensor{Id=4,Name="SM-1"},
                new Sensor{Id=5,Name="SM-2"},
                new Sensor{Id=6,Name="SM-3"},

            };
        }

        public void Add(Sensor sensor)
        {
            throw new NotImplementedException();
        }

        public void ChangeState(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sensor> GetAllDepartementSensors(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sensor> GetAllDepartementSensors(Departement departement)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sensor> GetAllSensors()
        {
            return sensors;
        }

        public Sensor GetSensorById(int id)
        {
            return sensors.FirstOrDefault(s => s.Id == id);
        }

        public void update(Sensor sensor)
        {
            throw new NotImplementedException();
        }
    }
}
