using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WaterLeakDetection.Data.Modals
{
    public class Sensor
    {
        public int Id { get; set; }

        [JsonIgnore]
        public string Name { get; set; }
        public int CurrentLevel { get; set; }
        public bool IsOn { get; set; }

        [JsonIgnore]
        public int DepartementId { get; set; }

        [JsonIgnore]
        public virtual Departement Departement { get; set; }

        [JsonIgnore]
        public List<Leak> Leaks { get; set; }

        [JsonIgnore]
        public int Count { get; set; }

    }
}
