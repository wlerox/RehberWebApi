using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rehber.DataAccess.Abstract;
using Rehber.Entities.DtoModel;
using Rehber.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ContactInfoSetDto> AddPersonContact(ContactInfoSetDto personInfo)
        {
            var person = await GetPersonByUID(personInfo.PersonUID);
            var infoType = await _dbContext.InfoTypes.AsNoTracking().FirstOrDefaultAsync(t => t.InfoTypeID.Equals(personInfo.InfoTypeID));
            if(person!=null && infoType != null)
            {
                var addPersonContact = _mapper.Map<ContactInfo>(personInfo);
                _dbContext.ContactInfos.Add(addPersonContact);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<ContactInfoSetDto>(addPersonContact);
            }
            else
            {
                return null;
            }
            
        }

        public async Task<PersonDto> CreateNewPerson(PersonSetDto person)
        {
            var personCreate = _mapper.Map<Person>(person);
            personCreate.UID = Guid.NewGuid().ToString();
            _dbContext.Persons.Add(personCreate);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PersonDto>(personCreate);
        }

        public async Task DeletePerson(string personUID)
        {
            var deletePerson = await GetPersonByUID(personUID);
            if (deletePerson != null)
            {
                var person = _mapper.Map<Person>(deletePerson);
                if (person.ContactInfos != null)
                {
                    _dbContext.ContactInfos.RemoveRange(person.ContactInfos);
                }
                _dbContext.Persons.Remove(person);
                
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeletePersonContact(string personUID, int contactId)
        {
            var contact = await _dbContext.ContactInfos.FirstOrDefaultAsync(p =>p.PersonUID.Equals(personUID) && p.ContactInfoID.Equals(contactId));
            var deleteContact = _mapper.Map<ContactInfo>(contact);
            _dbContext.ContactInfos.Remove(deleteContact);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<PersonDto>> GetAllPerson()
        {
            var getAllPerson = await _dbContext.Persons.ToListAsync();
            if(getAllPerson != null)
            {
                var personList = _mapper.Map<List<PersonDto>>(getAllPerson);
                return personList;
            }
            else
            {
                return null;
            }
        }

        public async Task<PersonGetDto> GetPersonByUID(string personUID)
        {
            var getPerson = await _dbContext.Persons.Include(c=>c.ContactInfos).AsNoTracking().FirstOrDefaultAsync(p=>p.UID.Equals(personUID));
            if (getPerson != null)
            {
                var person = _mapper.Map<PersonGetDto>(getPerson);
                return person;
            }
            else
            {
                return null;
            }
        }

        public async Task<PersonGetDto> GetPersonDetail(string personUID)
        {
            //var personDetail = await GetPersonByUID(personUID);
            var personDetail = await _dbContext.Persons.Include(a => a.ContactInfos)
                                            .ThenInclude(g => g.InfoType)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync(x => x.UID.Equals(personUID));
            if (personDetail != null)
            {
                var person = _mapper.Map<PersonGetDto>(personDetail);
                return person;
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> IsPersonContact(string personUID, int contactId)
        {
            var contact = await _dbContext.ContactInfos.FirstOrDefaultAsync(p => p.PersonUID.Equals(personUID) && p.ContactInfoID.Equals(contactId));
            if (contact != null) {
                return true;
            }
            else
            {
                //var a = await _dbContext.Persons.Include(person => person.ContactInfos.Where(c =>c.InfoTypeID == 3).GroupBy(g => g.InfoContent).ToList());
               
                return false;
            }

        }

        public async Task<List<ReportDto>> GetReports()
        {
            
            var reports = await _dbContext.ContactInfos.Where(t => t.InfoTypeID==3 )
                                            .GroupBy(p => new { p.InfoContent })
                                            .Select(g => new ReportDto { 
                                                                Location = g.Key.InfoContent,
                                                                Count = g.Count(),
                                                                PersonCount=g.Count()
                                                                })
                                            .OrderByDescending(i => i.Count)
                                            .ToListAsync();
            return reports;
        }

        public async Task<PersonDto> UpdatePerson(PersonDto person)
        {
            var uPerson = await GetPersonByUID(person.UID);
            if (uPerson != null)
            {
                var updatePerson = _mapper.Map<Person>(person);
                _dbContext.Persons.Update(updatePerson);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<PersonDto>(updatePerson);
            }
            else
            {
                return null;
            }
        }
    }
}
