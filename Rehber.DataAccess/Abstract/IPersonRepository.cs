using Rehber.Entities.DtoModel;
using System;
using System.Collections;
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
        Task<PersonGetDto> GetPersonByUID(string personUID);
        Task<List<PersonDto>> GetAllPerson();
        Task<PersonGetDto> GetPersonDetail(String personUID);
        Task<ContactInfoSetDto> AddPersonContact(ContactInfoSetDto personInfo);
        Task DeletePersonContact(string personUID,int contactId);
        Task<Boolean> IsPersonContact(string personUID, int contactId);

        Task<List<ReportDto>> GetReports();
    }
}
