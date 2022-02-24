﻿using Rehber.Entities.DtoModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.DataAccess.Abstract
{
    public interface IPersonRepository
    {
        Task<PersonDto> CreateNewPerson (PersonSetDto person);
        Task<PersonDto> UpdatePerson (PersonDto person);
        Task DeletePerson(string personUID);
        Task<PersonDto> GetPersonByUID(string personUID);
        Task<List<PersonDto>> GetAllPerson();
        Task<PersonDto> GetPersonDetail(String personUID);
        Task<ContactInfoDto> CreatePersonInfo(ContactInfoDto personInfo);
        Task DeletePersonContactInfo(int contactInfoId);
    }
}