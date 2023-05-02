using AutoMapper;
using BarbecueManager.Application.API.Dtos;
using BarbecueManager.Domain.Entities;
using BarbecueManager.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BarbecueManager.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;
        public readonly IMapper _mapper;

        public PersonController(IMapper mapper, IPersonService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            await _service.Add(person, personDto.BarbecueId);

            return Ok("Created!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);

            return Ok("Deleted!");
        }
    }
}
