
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonListResponse> FindAllAsync();
        Task<Person> GetById(int id);
        Task<Person> Create(PersonRequest person);
        Task<Person> Update(PersonRequest person);
        Task Delete(int id);
    }
}
