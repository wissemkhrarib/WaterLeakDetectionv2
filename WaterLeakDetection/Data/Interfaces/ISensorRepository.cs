using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLeakDetection.Data.Modals;

namespace WaterLeakDetection.Data.Interfaces
{
    public interface ISensorRepository
    {
        public Sensor GetSensorById(int id);
        public void Add(Sensor sensor);
        public IEnumerable<Sensor> GetAllDepartementSensors(Departement departement);
        public void Delete(int id);
        public void update(Sensor sensor);
        public IEnumerable<Sensor> GetAllSensors();
    }
}
