using HandCare.Core;
using HandCare.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HandCare.HandShakeScheduler.API.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private readonly IUnitOfWork _workService;

        public OfficesController(IUnitOfWork workService)
        {
            _workService = workService;
        }

        [HttpGet("officeId")]
        public ActionResult<Office> Get(string officeId)
        {
            if (Guid.TryParse(officeId, out var validOfficeId))
            {
                var office = _workService.Offices.Get(validOfficeId);
                if (office != null)
                    return office;
            }

            return NotFound();
        }
        
        [HttpGet]
        public IEnumerable<Office> GetAll()
        {
            var offices = _workService.Offices.GetAll();
            return offices;
        }
        
        [HttpPost]
        public ActionResult<Office> Office(Office office)
        {
            _workService.Offices.Add(office);
            _workService.Complete();

            //    return CreatedAtAction("PostTodoItem", new { id = todoItem.Id }, todoItem);
            return  CreatedAtAction(nameof(Office), new { id = office.OfficeId }, office);
        }

        [HttpPut("officeId")]
        public ActionResult Put(string officeId, Office updatedOffice)
        {
            if (!string.Equals(officeId, updatedOffice.OfficeId.ToString(), StringComparison.CurrentCultureIgnoreCase))
                return BadRequest();

            if (Guid.TryParse(officeId, out var validOfficeId))
            {
                var existingOffice = _workService.Offices.Get(validOfficeId);
                if (existingOffice != null)
                {
                    existingOffice.Address = updatedOffice.Address;
                    existingOffice.City = updatedOffice.City;
                    existingOffice.ZipCode = updatedOffice.ZipCode;
                    existingOffice.State = updatedOffice.State;
                    existingOffice.Closed = updatedOffice.Closed;
                    existingOffice.Phone = updatedOffice.Phone;
                }

                _workService.Complete();
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete]
        public ActionResult Delete(string officeId)
        {
            if (Guid.TryParse(officeId, out var validOfficeId))
            {
                var office = _workService.Offices.Get(validOfficeId);
                if (office != null)
                {
                    _workService.Offices.Remove((office));
                    _workService.Complete();
                    return Ok();
                }
            }

            return NotFound();
        }
        
    }
}
