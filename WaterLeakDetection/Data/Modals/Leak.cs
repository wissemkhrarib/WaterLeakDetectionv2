using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterLeakDetection.Data.Modals
{
    public class Leak
    {
        public int Id { get; set; }
        public DateTime OccurrenceDate { get; set; }
        public bool IsRepared { get; set; }
        public int SensorId { get; set; }
        public virtual Sensor Sensor { get; set; }


    }
}
