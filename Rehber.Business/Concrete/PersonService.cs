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

        public async Task<PersonDto> CreatePerson(PersonSetDto person)
        {
            var newPerson = await _personRepository.CreateNewPerson(person);
            return newPerson;
        }

        public Task DeletePerson(string personUID)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonDto>> GetAllPerson()
        {
            throw new NotImplementedException();
        }

        public Task<PersonDto> GetPersonByUID(string personUID)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDto> GetPersonDetail(string personUID)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDto> UpdatePerson(PersonDto person)
        {
            throw new NotImplementedException();
        }
    }
}
