using API.Entity;
using API.Entity.DTOs;
using API.Interface;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;

namespace API.Controllers
{
    [Route("api/machine/{machineid}/times")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private IMachine _machineRepository;
        private ITime _timeRepository;
        private readonly IMapper _mapper;

        public TimeController(IMachine machineRepository, ITime timeRepository, IMapper mapper)
        {
            _machineRepository = machineRepository;
            _timeRepository = timeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll(int machineid)
        {
            var machine = _machineRepository.GetById(machineid);
            if (machine == null)
            {
                return NotFound($"Machine with id: {machineid} doesn't exist in the database.");
            }
            var times = _timeRepository.GetAll(machineid);
            return Ok(times);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int machineid,int id)
        {
            var machine = _machineRepository.GetById(machineid);
            if (machine == null)
            {
                return NotFound($"Machine with id: {machineid} doesn't exist in the database.");
            }
            var time = _timeRepository.GetById(machineid, id);
            if (time == null)
            {
                return NotFound($"Time with id: {id} doesn't exist in the database.");
            }
            return Ok(time);
        }
        
        [HttpPost]
        public IActionResult Create(int machineid,TimeDto timeDto)
        {
            var machine = _machineRepository.GetById(machineid);
            if (machine == null)
            {
                return NotFound($"Machine with id: {machineid} doesn't exist in the database.");
            }
            var times =_timeRepository.GetAll(machineid);
            foreach(var ti in times.ToList())
            {
                if (ti.StartTime == timeDto.StartTime || ti.EndTime == timeDto.EndTime)
                {
                    return BadRequest($"Time with start time: {timeDto.StartTime} and end time: {timeDto.EndTime} already exists in the database.");
                }
            }

            var time = _mapper.Map<Time>(timeDto);
            _timeRepository.Create(machineid,time);
            return Ok(new { message = "Time created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int machineid,int id, TimeDto timeDto)
        {
            var machine = _machineRepository.GetById(machineid);
            if (machine == null)
            {
                return NotFound($"Machine with id: {machineid} doesn't exist in the database.");
            }
            var time = _timeRepository.GetById(machineid, id);
            if (time == null)
            {
                return NotFound($"Time with id: {id} doesn't exist in the database.");
            }
            time = _mapper.Map<Time>(timeDto);
            _timeRepository.Update(machineid,id, time);
            return Ok(new { message = "Time updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int machineid,int id)
        {
            var machine = _machineRepository.GetById(machineid);
            if (machine == null)
            {
                return NotFound($"Machine with id: {machineid} doesn't exist in the database.");
            }
            var time = _timeRepository.GetById(machineid, id);
            if (time == null)
            {
                return NotFound($"Time with id: {id} doesn't exist in the database.");
            }
            _timeRepository.Delete(machineid,id);
            return Ok(new { message = "Time deleted" });
        }
    }
}
