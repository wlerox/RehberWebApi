using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rehber.DataAccess.Abstract;
using Rehber.Entities.DtoModel;
using Rehber.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.DataAccess.Concrete
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _dbContext;
        private readonly IMapper _mapper;

        public PersonRepository(PersonDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PersonDto> CreateNewPerson(PersonSetDto person)
        {
            var personCreate = _mapper.Map<Person>(person);
            personCreate.UID = Guid.NewGuid().ToString();
            _dbContext.Persons.Add(personCreate);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PersonDto>(personCreate);
        }

        public Task<ContactInfoDto> CreatePersonInfo(ContactInfoDto personInfo)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePerson(string personUID)
        {
            var deletePerson = await GetPersonByUID(personUID);
            if (deletePerson != null)
            {
                var person = _mapper.Map<Person>(deletePerson);
                _dbContext.Persons.Remove(person);
                await _dbContext.SaveChangesAsync();
            }
            throw new NotImplementedException();
        }

        public Task DeletePersonContactInfo(int contactInfoId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonDto>> GetAllPerson()
        {
            throw new NotImplementedException();
        }

        public async Task<PersonDto> GetPersonByUID(string personUID)
        {
            var getPerson = await _dbContext.Persons.FirstOrDefaultAsync(p=>p.UID.Equals(personUID));
            if (getPerson != null)
            {
                var person = _mapper.Map<PersonDto>(getPerson);
                return person;
            }
            else
            {
                return null;
            }
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
