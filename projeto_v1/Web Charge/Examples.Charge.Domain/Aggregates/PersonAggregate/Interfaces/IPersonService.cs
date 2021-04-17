using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> FindAllAsync();
        Task<Person> GetById(int id);
        Task<Person> Create(Person person);
        Task<Person> Update(Person person);
        Task Delete(int id);

    }
}
