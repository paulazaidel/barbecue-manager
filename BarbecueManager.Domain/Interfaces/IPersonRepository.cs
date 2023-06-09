﻿using BarbecueManager.Domain.Entities;

namespace BarbecueManager.Domain.Interfaces
{
    public interface IPersonRepository : IRepository<Person> {
        Task Delete(Person person);
    }
}
