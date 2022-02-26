using Rehber.Business.Abstract;
using Rehber.DataAccess.Abstract;
using Rehber.Entities.DtoModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Business.Concrete
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<ContactInfoSetDto> AddPersonContact(ContactInfoSetDto contactInfo)
        {
            var addPersonContact = await _personRepository.AddPersonContact(contactInfo);
            return addPersonContact;
        }

        public async Task<PersonDto> CreatePerson(PersonSetDto person)
        {
            var newPerson = await _personRepository.CreateNewPerson(person);
            return newPerson;
        }

        public async Task DeletePerson(string personUID)
        {
            await _personRepository.DeletePerson(personUID);
        }

        public async Task DeletePersonContact(string personUID, int contactId)
        {
            await _personRepository.DeletePersonContact(personUID, contactId);
        }

        public async Task<List<PersonDto>> GetAllPerson()
        {
            var personList = await _personRepository.GetAllPerson();
            return personList;
        }

        public async Task<PersonGetDto> GetPersonByUID(string personUID)
        {
            var getPerson = await _personRepository.GetPersonByUID(personUID);
            if (getPerson != null)
            {
                return getPerson;
            }
            else
            {
                return null;
            }
            
        }

        public async Task<PersonGetDto> GetPersonDetail(string personUID)
        {
            var personDetail = await _personRepository.GetPersonDetail(personUID);
            return personDetail;
        }

        public async Task<bool> IsPersonContact(string personUID, int contactId)
        {
            var isPerconContact = await _personRepository.IsPersonContact(personUID, contactId);
            return isPerconContact;
        }

        public async Task<PersonDto> UpdatePerson(PersonDto person)
        {
            var updatePerson = await _personRepository.UpdatePerson(person);
            return updatePerson;
        }
    }
}
