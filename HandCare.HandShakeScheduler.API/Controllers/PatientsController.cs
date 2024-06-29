using HandCare.Core;
using HandCare.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HandCare.HandShakeScheduler.API
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
    }
}