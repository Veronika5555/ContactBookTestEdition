using ContactBookTestEdition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBookTestEdition.Data.Repository
{
    public interface IRepository
    {
        void AddPerson(Person person);
        Person GetPerson(int id);
        List<Person> GetAllPeople();
        void UpdatePerson(Person person);
        void DeletePerson(int id);
        void SavePerson();
    }
}
