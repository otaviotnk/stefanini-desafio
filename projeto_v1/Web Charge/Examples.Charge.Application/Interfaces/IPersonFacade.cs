
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonListResponse> FindAllAsync();
        Task<PersonResponse> GetById(int id);
        Task<PersonResponse> Create(PersonRequest person);
        Task<PersonResponse> Update(PersonRequest person);
        Task<PersonResponse> Delete(int id);
    }
}
