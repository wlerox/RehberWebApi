﻿using Microsoft.AspNetCore.Mvc;
using Rehber.Business.Abstract;
using Rehber.Entities.DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController: ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewPerson([FromBody]PersonSetDto person)
        {
            var newPerson = await _personService.CreatePerson(person);
            return Ok(newPerson);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson([FromBody] PersonDto person)
        {
            var updatePerson = await _personService.UpdatePerson(person);
            if(updatePerson!= null)
            {
                return Ok(updatePerson);
            }
            return NotFound();
        }

        [HttpDelete("{personUID}")]
        public async Task<IActionResult> DeletePerson(string personUID)
        {
            if (await _personService.GetPersonByUID(personUID) != null)
            {
                await _personService.DeletePerson(personUID);
                return Ok();
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPerson()
        {
            var personList = await _personService.GetAllPerson();
            if (personList != null)
            {
                return Ok(personList);
            }
            else
            {
                return NotFound();
            }
        }
    }
}