﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonAggregate.Person>> FindAllAsync();

        Task<Person> GetById(int id);

        Task<Person> Create(Person person);
        Task<Person> Update(Person person);
        Task<int> Delete(int id);
    }
}
