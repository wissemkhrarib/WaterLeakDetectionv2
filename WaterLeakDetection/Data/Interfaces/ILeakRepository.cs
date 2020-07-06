using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLeakDetection.Data.Modals;

namespace WaterLeakDetection.Data.Interfaces
{
    public interface ILeakRepository
    {
        public void Add(Leak leak);
        public void Update(Leak leak);
        public Leak GetLastLeak(Sensor sensor);
        public IEnumerable<Leak> GetLeaks(Sensor sensor);
       
    }
}
