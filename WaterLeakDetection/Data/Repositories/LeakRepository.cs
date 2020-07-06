using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLeakDetection.Data.Interfaces;
using WaterLeakDetection.Data.Modals;

namespace WaterLeakDetection.Data.Repositories
{
    public class LeakRepository : ILeakRepository
    {
        private readonly AppDbContext _appDbContext;

        public LeakRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Add(Leak leak)
        {
            _appDbContext.Leaks.Add(leak);
            _appDbContext.SaveChanges();
        }

        public Leak GetLastLeak(Sensor sensor)
        {
            return GetLeaks(sensor).LastOrDefault();
        }

        public IEnumerable<Leak> GetLeaks(Sensor sensor)
        {
            return _appDbContext.Leaks.Where(l => l.Sensor == sensor);
        }

        public void Update(Leak leak)
        {
            _appDbContext.Leaks.Update(leak);
            _appDbContext.SaveChanges();
        }
    }
}
