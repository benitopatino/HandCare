using System.Net;
using HandCare.Core;
using HandCare.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HandCare.HandShakeScheduler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IUnitOfWork _workService;

        public PatientsController(IUnitOfWork workService)
        {
            _workService = workService;
        }
        
        [HttpPost]
        public ActionResult<Patient> Patient(Patient patient)
        {
            _workService.Patients.Add(patient);
            _workService.Complete();

            //    return CreatedAtAction("PostTodoItem", new { id = todoItem.Id }, todoItem);
            return  CreatedAtAction(nameof(Patient), new { id = patient.PatientId }, patient);
        }
        
        [HttpGet("patientId")]
        public ActionResult<Patient> GetById(string patientId)
        {
            // validate the guid
            if (Guid.TryParse(patientId, out var validPatientId))
            {
                var patient = _workService.Patients.Get(validPatientId);
                if (patient != null)
                    return patient;
            }
            return NotFound();
        
        }

        [HttpGet]
        public IEnumerable<Patient> GetAll()
        {
            var patients = _workService.Patients.GetAll();
            return patients;
        }

        [HttpPut("patientId")]
        public ActionResult Put(string patientId, Patient updatedPatient)
        {
            if (!string.Equals(patientId, updatedPatient.PatientId.ToString(),StringComparison.CurrentCultureIgnoreCase))
                return BadRequest();
            
            if (Guid.TryParse(patientId, out var validPatientId))
            {
                var existingPatient = _workService.Patients.Get(validPatientId);
                if (existingPatient != null)
                {
                    existingPatient.Address = updatedPatient.Address;
                    existingPatient.City = updatedPatient.City;
                    existingPatient.State = updatedPatient.State;
                    existingPatient.ZipCode = updatedPatient.ZipCode;
                    existingPatient.CellPhone = updatedPatient.CellPhone;
                    existingPatient.FirstName = updatedPatient.FirstName;
                    existingPatient.LastName = updatedPatient.LastName;
                    existingPatient.DateOfBirth = updatedPatient.DateOfBirth;
                    existingPatient.Email = updatedPatient.Email;
                    existingPatient.Address = updatedPatient.Address;

                }
                _workService.Complete();
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete]
        public ActionResult Delete(string patientId)
        {
            if (Guid.TryParse(patientId, out var validPatientId))
            {
                var patient = _workService.Patients.Get(validPatientId);
                if (patient != null)
                {
                    _workService.Patients.Remove(patient);
                    _workService.Complete();
                    return Ok();
                }
            }

            return NotFound();
        }
        
        


    }
}