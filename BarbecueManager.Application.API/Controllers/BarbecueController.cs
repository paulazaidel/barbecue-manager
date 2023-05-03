using AutoMapper;
using AutoMapper.Internal;
using BarbecueManager.Application.API.Dtos;
using BarbecueManager.Domain.Entities;
using BarbecueManager.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarbecueManager.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbecueController : ControllerBase
    {
        private readonly IBarbecueService _service;
        public readonly IMapper _mapper;

        public BarbecueController(IMapper mapper, IBarbecueService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var barbecues = await _service.GetAll();
            var barbecuesDto = _mapper.Map<IEnumerable<BarbecuesDto>>(barbecues);

            return Ok(barbecuesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var barbecue = await _service.FindById(id);

            if (barbecue == null)
                return NotFound();

            var barbecuesDto = _mapper.Map<BarbecuesDto>(barbecue);

            return Ok(barbecuesDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BarbecueDto barbecueDto)
        {
            var barbecue = _mapper.Map<Barbecue>(barbecueDto);

            if (barbecue.Date < DateTime.UtcNow)
                return BadRequest("Barbecue date can not be less than today!");


            await _service.Add(barbecue);


            return Ok("Created!");
        }
    }
}
