using HandCare.Core;
using HandCare.Core.Domain;
using Microsoft.AspNetCore.Mvc;

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
    }
}
