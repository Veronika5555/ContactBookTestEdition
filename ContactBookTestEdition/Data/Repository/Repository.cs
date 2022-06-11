using ContactBookTestEdition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBookTestEdition.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _ctx;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddPerson(Person person)
        {
            _ctx.Contacts.Add(person);
        }

        public Person GetPerson(int id)
        {
            return _ctx.Contacts.FirstOrDefault(p => p.Id == id);
        }

        public List<Person> GetAllPeople()
        {
            return _ctx.Contacts.ToList();
        }

        public void UpdatePerson(Person person)
        {
            _ctx.Contacts.Update(person);
        }

        public void DeletePerson(int id)
        {
            _ctx.Contacts.Remove(GetPerson(id));
        }

        public void SavePerson()
        {
            _ctx.SaveChanges();
        }
    }
}
