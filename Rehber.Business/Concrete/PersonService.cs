using Newtonsoft.Json;
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
        private readonly ICacheProcesses _cacheProcesses;

        public PersonService(IPersonRepository personRepository, ICacheProcesses cacheProcesses)
        {
            _personRepository = personRepository;
            _cacheProcesses = cacheProcesses;
        }

        public async Task<ContactInfoSetDto> AddPersonContact(ContactInfoSetDto contactInfo)
        {
            var addPersonContact = await _personRepository.AddPersonContact(contactInfo);
            var person = await _personRepository.GetPersonDetail(contactInfo.PersonUID);
            SetPersonInCache(person);
            return addPersonContact;
        }

        public async Task<PersonDto> CreatePerson(PersonSetDto person)
        {
            var newPerson = await _personRepository.CreateNewPerson(person);
            if (newPerson != null)
            {
                var allPerson = await _personRepository.GetAllPerson();
                SetAllPersonInCache(allPerson);
            }
            return newPerson;
        }

        public async Task DeletePerson(string personUID)
        {
            await _personRepository.DeletePerson(personUID);
            await _cacheProcesses.DeletePersonFromCache(personUID);
            var allPerson = await _personRepository.GetAllPerson();
            if (allPerson != null)
            {
                SetAllPersonInCache(allPerson);
            }
            else
            {
                await _cacheProcesses.DeletePersonFromCache("allPerson");
            }
            
        }

        public async Task DeletePersonContact(string personUID, int contactId)
        {
            await _personRepository.DeletePersonContact(personUID, contactId);
            var person = await _personRepository.GetPersonDetail(personUID);
            SetPersonInCache(person);
        }

        public async Task<List<PersonDto>> GetAllPerson()
        {
            var personList = new List<PersonDto>();
            if(String.IsNullOrEmpty(await _cacheProcesses.GetAllPersonFromCache())){
                var allPerson = await _personRepository.GetAllPerson();
                if (allPerson != null)
                {
                    SetAllPersonInCache(allPerson);
                    personList = allPerson;
                }
                else
                {
                    personList = null;
                }

            }
            else
            {
                personList = await GetAllPersonInCache();
            }
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
            var person = new PersonGetDto();
            if (String.IsNullOrEmpty(await _cacheProcesses.GetPersonWithDetailFromCache(personUID)))
            {
                var gPerson = await _personRepository.GetPersonDetail(personUID);
                if (gPerson != null)
                {
                    SetPersonInCache(gPerson);
                    person = gPerson;
                }
                else
                {
                    person = null;
                }

            }
            else
            {
                person = await GetPersonInCache(personUID);
            }
            return person;
        }

        public async Task<bool> IsPersonContact(string personUID, int contactId)
        {
            var isPerconContact = await _personRepository.IsPersonContact(personUID, contactId);
            return isPerconContact;
        }

        public async Task<PersonDto> UpdatePerson(PersonDto person)
        {
            var updatePerson = await _personRepository.UpdatePerson(person);
            if (updatePerson != null)
            {
                var allPerson = await _personRepository.GetAllPerson();
                SetAllPersonInCache(allPerson);

                var uPerson = await _personRepository.GetPersonDetail(person.UID);
                SetPersonInCache(uPerson);
            }
            return updatePerson;
        }

        private async void SetAllPersonInCache(List<PersonDto> allPerson)
        {
            var personsConvertToString = JsonConvert.SerializeObject(allPerson);
            await _cacheProcesses.SetAllPersonToCache(personsConvertToString);
        }
        private async void SetPersonInCache(PersonGetDto person)
        {
            var personConvertToString = JsonConvert.SerializeObject(person);
            await _cacheProcesses.SetPersonWithDetailToCache(personConvertToString, person.UID);
        }
        private async Task<List<PersonDto>> GetAllPersonInCache()
        {
            var strPerson = await _cacheProcesses.GetAllPersonFromCache();
            var allPerson = JsonConvert.DeserializeObject<List<PersonDto>>(strPerson);
            return allPerson;
        }
        private async Task<PersonGetDto> GetPersonInCache(string personUID)
        {
            var strPerson = await _cacheProcesses.GetPersonWithDetailFromCache(personUID);
            var person = JsonConvert.DeserializeObject<PersonGetDto>(strPerson);
            return person;
        }
    }
}
