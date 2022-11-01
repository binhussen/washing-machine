using API.Entity;
using API.Entity.DTOs;
using API.Interface;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/machine")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private IMachine _machineRepository;
        private ITime _timeRepository;
        private readonly IMapper _mapper;

        public MachineController(IMachine machineRepository, ITime timeRepository, IMapper mapper)
        {
            _machineRepository = machineRepository;
            _timeRepository = timeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var machines = _machineRepository.GetAll();
            foreach (var item in machines.ToList())
            {
                var times = _timeRepository.GetAll(item.Id);
                item.Times = times.ToList();
            }
            return Ok(machines);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var machine = _machineRepository.GetById(id);
            var times = _timeRepository.GetAll(id);
            if (machine == null)
            {
                return NotFound($"Machine with id: {id} doesn't exist in the database.");
            }
            if (times != null)
            {
                machine.Times = times.ToList();
            }
            return Ok(machine);
        }

        [HttpPost]
        public IActionResult Create(MachineDto machineDto)
        {
            var machine = _mapper.Map<Machine>(machineDto);
            _machineRepository.Create(machine);
            return Ok(new { message = "Machine created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MachineDto machineDto)
        {
            var machine = _machineRepository.GetById(id);
            if (machine == null)
            {
                return NotFound($"Machine with id: {id} doesn't exist in the database.");
            }
            machine = _mapper.Map<Machine>(machineDto);
            _machineRepository.Update(id, machine);
            return Ok(new { message = "Machine updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var machine = _machineRepository.GetById(id);
            if (machine == null)
            {
                return NotFound($"Machine with id: {id} doesn't exist in the database.");
            }
            _machineRepository.Delete(id);
            return Ok(new { message = "Machine deleted" });
        }
    }
}
