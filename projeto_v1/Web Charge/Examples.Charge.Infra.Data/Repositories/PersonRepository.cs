using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Person>> FindAllAsync() => await Task.Run(() => _context.Person);

        public async Task<Person> GetById(int id)
        {
            return await _context.Person.Where(x => x.BusinessEntityID == id).FirstOrDefaultAsync();
        }                     

        public async Task<int> Update(Person person)
        {
            _context.Person.Update(person);
            await _context.SaveChangesAsync();

            return person.BusinessEntityID;
        }

        async Task<Person> IPersonRepository.Create(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();

            return person;
        }

        async Task<Person> IPersonRepository.Update(Person person)
        {
            _context.Person.Update(person);
            await _context.SaveChangesAsync();

            return person;
        }

        public async Task<int> Delete(int id)
        {
            var person = await _context.Person.Where(x => x.BusinessEntityID == id).FirstOrDefaultAsync();
            _context.Person.Remove(person);

            return person.BusinessEntityID;
        }

    }
}
