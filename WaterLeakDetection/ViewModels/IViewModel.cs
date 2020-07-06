using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLeakDetection.Data.Modals;

namespace WaterLeakDetection.ViewModels
{
    public interface IViewModel
    {
        public IEnumerable<Departement> Departements { get; set; }

    }
}
