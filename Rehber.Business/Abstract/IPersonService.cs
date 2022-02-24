﻿using Rehber.Entities.DtoModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Business.Abstract
{
    public interface IPersonService
    {
        Task<PersonDto> CreatePerson(PersonSetDto person);
        Task<PersonDto> UpdatePerson(PersonDto person);
        Task DeletePerson(string personUID);
        Task<PersonDto> GetPersonByUID(string personUID);
        Task<List<PersonDto>> GetAllPerson();
        Task<PersonDto> GetPersonDetail(String personUID);
    }
}