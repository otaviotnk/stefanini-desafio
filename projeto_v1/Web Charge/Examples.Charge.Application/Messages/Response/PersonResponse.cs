using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System.Collections.Generic;

namespace Examples.Charge.Application.Messages.Response
{
    public class PersonResponse : BaseResponse
    {
        public Person Person { get; set; }
    }
}
