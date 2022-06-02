using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAppCar1.Models;
using WebAppCar1.Models.ViewModels;

namespace WebAppCar1.Controllers
{
    public class CarController : Controller
    {
        public string ddd = "";
        public readonly ICarPersonRepository<Person> personDbb;
        public readonly ICarPersonRepository<Car> carDbb;
        public readonly IHostingEnvironment hosting;
        


        public CarController(ICarPersonRepository<Car> _carDbb , ICarPersonRepository<Person> _personDbb, IHostingEnvironment _hosting )
        {
            this.personDbb = _personDbb;
            this.carDbb = _carDbb;
            this.hosting = _hosting;
         
        }


        // GET: CarController
        public ActionResult Index()
        {
            int lenn = carDbb.carList().Count;


            return View(carDbb.carList());
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {

            var carEdit = carDbb.Find(id);

            var newCarEdit = new CarViewMoels2()
            {
                car_ID = carEdit.car_ID,
                person_ID = carEdit.person_ID,
                car_Name = carEdit.car_Name,
                car_ImageUrl = carEdit.car_ImageUrl,
                car_Plate = carEdit.car_Plate,
                car_Person_List = personDbb.List().ToList()
            };

            return View(newCarEdit);
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            var carM2 = new CarViewMoels2() {
                car_Person_List = personDbb.List().ToList()
            };

            return View(carM2);
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarViewMoels2 newCar)
        {
            try
            {
                var newCar2 = new Car()
                {
                    car_ImageUrl = UploadFile(newCar.car_File),
                    car_Name = newCar.car_Name,
                    car_Plate = newCar.car_Plate,
                    person_ID = newCar.person_ID
                };

                carDbb.Add(newCar2);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        string UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath ,"uploads");
                string fullPath = Path.Combine(uploads, file.FileName); ;

                file.CopyTo(new FileStream(fullPath , FileMode.Create));

                return file.FileName;
            }

            return null;
        }



        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            var carEdit = carDbb.Find(id);

            var newCarEdit = new CarViewMoels2()
            {
                car_ID = carEdit.car_ID,
                person_ID = carEdit.person_ID,
                car_Name = carEdit.car_Name,
                car_ImageUrl = carEdit.car_ImageUrl,
                car_Plate = carEdit.car_Plate,
                car_Person_List = personDbb.List().ToList()
            };

            return View(newCarEdit);
        }



        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CarViewMoels2 updateCar)
        {
            try
            {
                var oldImage = carDbb.Find(id).car_ImageUrl;

                var newCar = carDbb.Find(id);

                newCar.car_Name = updateCar.car_Name;
                newCar.car_Plate = updateCar.car_Plate;
                newCar.car_ImageUrl = UploadFileEdit(updateCar.car_File, oldImage);
                newCar.person_ID = updateCar.person_ID;

                carDbb.Update(id, newCar);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }


        string UploadFileEdit(IFormFile file , string imagUrl)
        {
            try { 
              if (file != null)
              {
                string uploads = Path.Combine(hosting.WebRootPath, "uploads");
                string newPath = Path.Combine(uploads, file.FileName); ;

                string oldPath = Path.Combine(uploads, imagUrl); ;

                if (newPath != oldPath)
                {
                   
                    try { System.IO.File.Delete(oldPath);  } catch { }

                    file.CopyTo(new FileStream(newPath, FileMode.Create));

                }

                return file.FileName;
            }

            return imagUrl;

            }
            catch { 
                return null; }

        }



        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {

            var carEdit = carDbb.Find(id);

            var newCarEdit = new CarViewMoels2()
            {
                car_ID = carEdit.car_ID,
                person_ID = carEdit.person_ID,
                car_Name = carEdit.car_Name,
                car_ImageUrl = carEdit.car_ImageUrl,
                car_Plate = carEdit.car_Plate,
                car_Person_List = personDbb.List().ToList()
            };


            return View(newCarEdit);
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                carDbb.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
