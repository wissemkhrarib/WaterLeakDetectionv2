using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLeakDetection.Data.Interfaces;
using WaterLeakDetection.Data.Modals;

namespace WaterLeakDetection.Data.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly AppDbContext _appDbContext;

        public SensorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Sensor sensor)
        {
            _appDbContext.Sensors.Add(sensor);
            _appDbContext.SaveChanges();
        }

        public void update(Sensor sensor)
        {
            _appDbContext.Sensors.Update(sensor);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var sensor = GetSensorById(id);
            _appDbContext.Sensors.Remove(sensor);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Sensor> GetAllDepartementSensors(Departement departement)
        {
            return _appDbContext.Sensors.Where(s=>s.Departement==departement);
        }

        public IEnumerable<Sensor> GetAllSensors()
        {
            return _appDbContext.Sensors.AsEnumerable();
        }

        public Sensor GetSensorById(int id)
        {
            return _appDbContext.Sensors.FirstOrDefault(s => s.Id == id);
        }
    }
}
