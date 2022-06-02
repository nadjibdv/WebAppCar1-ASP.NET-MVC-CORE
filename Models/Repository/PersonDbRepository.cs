using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCar1.Models.ViewModels;

namespace WebAppCar1.Models.Repository
{
    public class PersonDbRepository : ICarPersonRepository<Person>
    {
        MyDbContext db;

        public PersonDbRepository(MyDbContext _db)
        {
            db = _db;
        }


        public void Add(Person entity)
        {
            db.person.Add(entity);
            db.SaveChanges();
        }

        public IList<CarListViewModels> carList()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var findd = Find(id);

            db.person.Remove(findd);
            db.SaveChanges();
        }

        public Person Find(int id)
        {
            return db.person.SingleOrDefault(x => x.person_ID == id);
        }

        public IList<Person> List()
        {
            return db.person.ToList();
        }

        public List<Person> Search(string term)
        {
            return db.person.Where(x => x.person_FName.Contains(term)).ToList();
        }

        public void Update(int id, Person entity)
        {
            db.person.Update(entity);
            db.SaveChanges();
        }
    }
}
