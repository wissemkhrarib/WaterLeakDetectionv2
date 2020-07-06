using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WaterLeakDetection.Data.Modals;

namespace WaterLeakDetection.ViewModels
{
    public class DepartementViewModel:IViewModel
    {
        public IEnumerable<Departement> Departements { get; set; }

        public Departement   Departement { get; set; }
        public IEnumerable<Sensor> Sensors { get; set; }

        
        [Required(ErrorMessage = "Departement Name is required")]
        [Display(Name = "Departement Name")]

        public string DepartementName { get; set; }
       

    }
}
