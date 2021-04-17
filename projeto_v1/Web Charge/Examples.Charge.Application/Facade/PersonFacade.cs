using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private IExampleService _exampleService;
        private IPersonService _personService;
        private IMapper _mapper;

        public PersonFacade(IExampleService exampleService, IPersonService personService, IMapper mapper)
        {
            _exampleService = exampleService;
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<PersonListResponse> FindAllAsync()
        {
            var result = await _exampleService.FindAllAsync();
            var response = new PersonListResponse();
            response.Persons = new List<PersonDto>();
            response.Persons.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }

        public async Task<Person> GetById(int id)
        {
            var result = await _personService.GetById(id);
            var response = new Person
            {
                BusinessEntityID = result.BusinessEntityID,
                Name = result.Name,
                Phones = result.Phones
            };            
            return response;
        }

        public async Task<Person> Create(PersonRequest personRequest)
        {
            var phones = new List<PersonPhone>();
            phones.Add(personRequest.Phone);

            var person = new Person
            {
                Name = personRequest.Name,
                Phones = phones
            };
            var result = await _personService.Create(person);
            return result;

        }
        public async Task<Person> Update(PersonRequest personRequest)
        {
            var phones = new List<PersonPhone>();
            phones.Add(personRequest.Phone);

            var person = new Person
            {
                Name = personRequest.Name,
                Phones = phones
            };
            var result = await _personService.Update(person);
            return result;
        }

        public async Task Delete(int id)
        {
            await _personService.Delete(id);
        }       

    }
}
