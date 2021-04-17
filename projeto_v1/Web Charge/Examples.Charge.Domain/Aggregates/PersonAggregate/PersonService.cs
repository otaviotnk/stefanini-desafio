using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;

        }

        public async Task<List<Person>> FindAllAsync() => (await _personRepository.FindAllAsync()).ToList();

        public async Task<Person> GetById(int id)
        {
            return await _personRepository.GetById(id);
        }

        public async Task<Person> Create(Person person)
        {
            return await _personRepository.Create(person);
        }

        public async Task<int> Delete(int id)
        {
            return await _personRepository.Delete(id);
        }        

        public async Task<Person> Update(Person person)
        {
            return await _personRepository.Update(person);
        }        

        Task IPersonService.Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
