using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WaterLeakDetection.Data.Interfaces;
using WaterLeakDetection.Data.Modals;
using WaterLeakDetection.ViewModels;

namespace WaterLeakDetection.Controllers
{
    [Authorize]
    public class DepartementController : Controller
    {
        private readonly IDepartementRepository departementRepository;
        private readonly ISensorRepository sensorRepository;

        public DepartementController(IDepartementRepository departementRepository,ISensorRepository sensorRepository)
        {
            this.departementRepository = departementRepository;
            this.sensorRepository = sensorRepository;
        }
        public ActionResult Index()
        {
            var departementViewModel = GetDepartementViewModel();
            return View(departementViewModel);


        }
        public ActionResult Details(int id)
        {
            var departement = departementRepository.GetDepartementById(id);
            if (departement != null)
            {
                var sensors = sensorRepository.GetAllDepartementSensors(departement);
                var departementViewModel = GetDepartementViewModel();
                departementViewModel.Departement = departement;
                departementViewModel.Sensors = sensors;
                return View(departementViewModel);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            var departementViewModel =GetDepartementViewModel();
            return View(departementViewModel);
        }

        [HttpPost]
        public ActionResult Create(DepartementViewModel departementViewModel)
        {
            if (ModelState.IsValid)
            {
                var departement = new Departement { Name = departementViewModel.DepartementName };
                departementRepository.Add(departement);
                return RedirectToAction("Index");
            }
            departementViewModel.Departements = departementRepository.GetAllDepartments();
            return View(departementViewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            departementRepository.Delete(id);
            return RedirectToAction("Index", "Departement");

        }
        public DepartementViewModel GetDepartementViewModel()
        {
            var departementViewModel = new DepartementViewModel();
            var departements = departementRepository.GetAllDepartments();
            departementViewModel.Departements = departements;
            return departementViewModel;
        }
       
    }
}
