using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WaterLeakDetection.Data.Modals
{
    public class Departement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Sensor> Sensors { get; set; }
    }
}
