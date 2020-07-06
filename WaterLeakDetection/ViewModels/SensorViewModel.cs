using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WaterLeakDetection.Data.Modals;

namespace WaterLeakDetection.ViewModels
{
    public class SensorViewModel:IViewModel
    {
        public Sensor Sensor { get; set; }
        public IEnumerable<Departement> Departements { get; set; }

        [Required(ErrorMessage = "Sensor Name is required")]
        [Display(Name = "Sensor Name")]

        public string SensorName { get; set; }
        [Required]
        public int DepartementId { get; set; }
        public bool IsOn { get; set; }

    }
}
