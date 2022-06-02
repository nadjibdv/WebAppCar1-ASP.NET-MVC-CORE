using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCar1.Models.ViewModels;

namespace WebAppCar1.Models.Repository
{
    public class CarDbRepositor : ICarPersonRepository<Car>
    {
        MyDbContext db;

        public CarDbRepositor(MyDbContext _db)
        {
            db = _db;
        }


        public IList<CarListViewModels> carList()
        {
            var Result = from g in db.car
                         join m in db.person on g.person_ID equals m.person_ID
                         //where g.car_ID == 1
                         select new CarListViewModels()
                         {
                             car_ID = g.car_ID,
                             car_Name = g.car_Name,
                             car_ImageUrl = g.car_ImageUrl,
                             car_Plate = g.car_Plate,
                             person_ID = m.person_ID ,
                             person_FName = m.person_FName,
                             person_LName =m.person_LName ,
                             person_Phone = m.person_Phone
                         };

            return Result.ToList();
        }

        public void Add(Car entity)
        {
            db.car.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var findd = Find(id);

            db.car.Remove(findd);
            db.SaveChanges();
        }

        public Car Find(int id)
        {
            return db.car.SingleOrDefault(x => x.car_ID == id);
        }

        public IList<Car> List()
        {
            return db.car.ToList();
        }


        public List<Car> Search(string term)
        {
            return db.car.Where(x => x.car_Name.Contains(term) ||
                                     x.car_Plate.Contains(term)).ToList();
        }

        public void Update(int id, Car entity)
        {
            db.car.Update(entity) ;
            db.SaveChanges();
        }
    }
}
