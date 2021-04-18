using AutoMapper;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private IPersonFacade _facade;

        public PersonController(IPersonFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonListResponse>> Get() => Response(await _facade.FindAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetByIdAsync(int id)
        {
            return Response(await _facade.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PersonRequest request)
        {
            return Response(await _facade.Create(request));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PersonRequest request)
        {
            return Response(await _facade.Update(request));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Response(await _facade.Delete(id));

        }
    }
}
