using AutoMapper;
using HandCare.Core;
using HandCare.Core.Domain;
using HandCare.HandShakeScheduler.API.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandCare.HandShakeScheduler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IUnitOfWork _workService;
        private readonly IMapper _mapper;

        public AppointmentsController(IUnitOfWork workService, IMapper mapper)
        {
            _workService = workService;
            _mapper = mapper;
        }
        
        [HttpPost]
        public ActionResult<AppointmentDTO> Appointment(AppointmentDTO appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);
            _workService.Appointments.Add(appointment);
            _workService.Complete();
            return  CreatedAtAction(nameof(Appointment), new { id = appointment.AppointmentId }, appointmentDto);
        }
        
        [HttpGet("{appointmentId}")]
        public ActionResult<AppointmentDTO> GetById(string appointmentId)
        {
            // validate the guid
            if (Guid.TryParse(appointmentId, out var validAppointmentId))
            {
                var appointment = _workService.Appointments.Get(validAppointmentId);
                if (appointment != null)
                {
                    return _mapper.Map<AppointmentDTO>(appointment);
                }
            }
            return NotFound();
        
        }

        [HttpGet]
        public IEnumerable<AppointmentDTO> GetAll()
        {
            var appointments = _workService.Appointments.GetAll();
            List<AppointmentDTO> results = new List<AppointmentDTO>();

            foreach (var appt in appointments)
            {
                results.Add(_mapper.Map<AppointmentDTO>(appt));
            }
            return results;
        }
        
        [HttpPut("{appointmentId}")]
        public ActionResult Put(string appointmentId, AppointmentDTO appointmentDto)
        {
            if (!string.Equals(appointmentId, appointmentDto.AppointmentId.ToString(),StringComparison.CurrentCultureIgnoreCase))
                return BadRequest();
            
            if (Guid.TryParse(appointmentId, out var validappointmentId))
            {
                var existingAppointment = _workService.Appointments.Get(validappointmentId);
                if (existingAppointment != null)
                    _mapper.Map(appointmentDto, existingAppointment);

                _workService.Complete();
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{appointmentId}")]
        public ActionResult Delete(string appointmentId)
        {
            if (Guid.TryParse(appointmentId, out var validAppointmentId))
            {
                var appointment = _workService.Appointments.Get(validAppointmentId);
                if (appointment != null)
                {
                    _workService.Appointments.Remove((appointment));
                    _workService.Complete();
                    return Ok();
                }
            }

            return NotFound();
        }

    }
}
