using HandCare.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandCare.HandShakeScheduler.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        [HttpGet("{patientId}")]
        public async Task<ActionResult<Patient>> GetPatient(string patientId)
        {

            var patient = new Patient()
            {
                FirstName = "Hacksd",
                LastName = "Hackson",
                PatientId = patientId,
                DateOfBirth = DateTime.Now
            };

            return patient == null ? NotFound() : Ok(patient);

        }
    }
}