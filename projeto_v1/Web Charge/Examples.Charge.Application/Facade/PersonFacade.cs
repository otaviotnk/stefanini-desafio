using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private IPersonService _personService;
        private IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<PersonListResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonListResponse();
            response.Persons = new List<PersonDto>();
            response.Persons.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }

        public async Task Delete(int id)
        {
            await _personService.Delete(id);
        }

        async Task<PersonResponse> IPersonFacade.GetById(int id)
        {
            var result = await _personService.GetById(id);
            var response = new PersonResponse
            {
                Person = result
            };
            return response;
        }

        async Task<PersonResponse> IPersonFacade.Create(PersonRequest personRequest)
        {
            var phones = new List<PersonPhone>();
            phones.Add(personRequest.Phone);

            var person = new Person
            {
                Name = personRequest.Name,
                Phones = phones
            };

            var created = await _personService.Create(person);

            var result = new PersonResponse
            {
                Person = created
            };
            return result;
        }

        async Task<PersonResponse> IPersonFacade.Update(PersonRequest personRequest)
        {
            var phones = new List<PersonPhone>();
            phones.Add(personRequest.Phone);

            var person = new Person
            {
                Name = personRequest.Name,
                Phones = phones
            };
            var updated = await _personService.Update(person);

            var result = new PersonResponse
            {
                Person = updated
            };

            return result;
        }

        async Task<PersonResponse> IPersonFacade.Delete(int id)
        {
            var result = await _personService.GetById(id);

            var response = new PersonResponse
            {
                Person = result
            };
            await _personService.Delete(result.BusinessEntityID);
            return response;

        }
    }
}
