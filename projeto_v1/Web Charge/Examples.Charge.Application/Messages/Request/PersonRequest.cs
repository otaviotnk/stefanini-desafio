using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.Messages.Request
{
    public class PersonRequest
    {
        public string Name { get; set; }
        public PersonPhone Phone { get; set; }
    }
}
