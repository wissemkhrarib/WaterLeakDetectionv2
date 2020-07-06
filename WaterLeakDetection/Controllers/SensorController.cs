using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WaterLeakDetection.Data.Interfaces;
using WaterLeakDetection.Data.Modals;
using WaterLeakDetection.Services;
using WaterLeakDetection.ViewModels;

namespace WaterLeakDetection.Controllers
{
    [Authorize]
    public class SensorController : Controller
    {
        private readonly ISensorRepository sensorRepository;

        private readonly IDepartementRepository departementRepository;
        private readonly ILeakRepository leakRepository;

        public SensorController(ISensorRepository sensorRepository,IDepartementRepository departementRepository,ILeakRepository leakRepository)
        {
            this.sensorRepository = sensorRepository;
            this.departementRepository = departementRepository;
            this.leakRepository = leakRepository;
        }
        
        [HttpGet]
        public JsonResult SensorsLevels(int id)
        {
            var sensorsUpdates = CsvReadWrite.ReadSensorsLevel(@"C:\Users\ASUS\Desktop\WaterLeakDetection\sensorsLevel.txt");
            foreach (var item in sensorsUpdates)
            {
                var sensor = sensorRepository.GetSensorById(item.Id);
                var leakDB = leakRepository.GetLastLeak(sensor);
                sensor.CurrentLevel = item.CurrentLevel;
                var leakState = leakDB != null ? leakDB.IsRepared : true;
                if(sensor.CurrentLevel > 200 && leakState)
                {
                    sensor.Count += 1;
                }
                if (sensor.CurrentLevel < 200 && leakState)
                {
                    sensor.Count = 0;
                }
                if (sensor.CurrentLevel < 200 && leakState)
                {
                    sensor.Count -= 1;
                }
                System.Diagnostics.Debug.WriteLine(sensor.Count);



                if (sensor.Count == -1 && leakState && leakDB !=null)
                {
                    leakDB.IsRepared = true;
                    leakRepository.Update(leakDB);
                    sensor.Count = 0;
                }
                if (sensor.Count == 1 && leakState)
                {
                    var leak = new Leak { Sensor = sensor, OccurrenceDate = DateTime.Now };
                    leakRepository.Add(leak);
                    sensor.Count = 0;
                    string subjet = "New Leak";
                    string body = string.Format("New leak has been occured .\n Sensor : {0}", sensor.Name);
                    string addresse = "khraribwissem@gmail.com";
                    SendEmail(addresse, subjet, body);
                    System.Diagnostics.Debug.WriteLine("email sent");

                }

                sensorRepository.update(sensor);
            }
            var departement = departementRepository.GetDepartementById(id);
            var sensors = sensorRepository.GetAllDepartementSensors(departement);
            var json = JsonConvert.SerializeObject(sensors);
            return Json(json);
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var sensorViewModel = GetSensorViewModel();
            var sensor = sensorRepository.GetSensorById(id);
            sensor.Leaks = leakRepository.GetLeaks(sensor).ToList();
            sensorViewModel.Sensor = sensor;
            return View(sensorViewModel);
        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            sensorRepository.Delete(id);
            return RedirectToAction("Index", "Departement");

        }

        public ActionResult Create()
        {
            var sensorViewModel = GetSensorViewModel();
            return View(sensorViewModel);
        }
        
        [HttpPost]
        public ActionResult Create(SensorViewModel sensorViewModel)
        {
            if (ModelState.IsValid)
            {
                var departement = departementRepository.GetDepartementById(sensorViewModel.DepartementId);
                var sensor = new Sensor();
                sensor.Name = sensorViewModel.SensorName;
                sensor.IsOn = sensorViewModel.IsOn;
                sensor.Departement = departement;
                sensorRepository.Add(sensor);
                return RedirectToAction("Details", "Departement", new { id = departement.Id });
            }
            sensorViewModel.Departements = departementRepository.GetAllDepartments();
            return View(sensorViewModel);
        }

        [HttpPost]
        public async void ChangeState(int id)
        {
            var sensor = sensorRepository.GetSensorById(id);
            sensor.IsOn = !sensor.IsOn;
            sensorRepository.update(sensor);
            var sensors = sensorRepository.GetAllSensors();
            await CsvReadWrite.AsyncWriteSensorsState(@"C:\Users\ASUS\Desktop\WaterLeakDetection\sensorsState.txt", sensors);
            await CsvReadWrite.AsyncWriteSensorsLevel(@"C:\Users\ASUS\Desktop\WaterLeakDetection\sensorsLevel.txt", sensors);
               

        }
        public SensorViewModel GetSensorViewModel()
        {
            var sensorViewModel = new SensorViewModel();
            var departements = departementRepository.GetAllDepartments();
            sensorViewModel.Departements = departements;
            return sensorViewModel;
        }

        public void SendEmail(string address, string subject, string message)
        {
            string email = "wisse5906@gmail.com";
            string password = "53109319";

            using (var msg = new MailMessage())
            {
                msg.From = new MailAddress(email);
                msg.To.Add(new MailAddress(address));
                msg.Subject = subject;
                msg.Body = message;
                msg.IsBodyHtml = true;
                //var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                using (var smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential(email, password)
                })
                { 
                    smtpClient.Send(msg);

                }
            }
            
        }
    }
}
