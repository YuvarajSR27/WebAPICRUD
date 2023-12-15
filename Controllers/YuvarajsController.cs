using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YuvarajAPI.Data;
using YuvarajAPI.Models;

namespace YuvarajAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YuvarajsController : Controller
    {
        //private property which readonly property talk to In-Memory db

        private readonly YuvarajAPIDBContext dbContext;

        //injecting the dbcontext to the constructor of controller
        public YuvarajsController(YuvarajAPIDBContext dbContext)
        {
            this.dbContext = dbContext;
                
        }

        [HttpGet]
        public async Task<IActionResult> GetYuvarajs()
        {
            return Ok(await dbContext.Yuvarajs.ToListAsync());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetYuvaraj([FromRoute] Guid id)
        {
            var yuvaraj = await dbContext.Yuvarajs.FindAsync(id);
            if(yuvaraj == null)
            {
                return NotFound();

            }
            return Ok(yuvaraj);

        }

        [HttpPost]
        public async Task<IActionResult> AddYuvarajs(AddYuvarajRequest addYuvarajRequest)
        {
            var yuvaraj = new Yuvaraj()
            {
                Id = Guid.NewGuid(),
                Address = addYuvarajRequest.Address,
                Email = addYuvarajRequest.Email,
                FullName = addYuvarajRequest.FullName,
                Phone = addYuvarajRequest.Phone,
            };

            await dbContext.Yuvarajs.AddAsync(yuvaraj);
            await dbContext.SaveChangesAsync();

            return Ok(yuvaraj);
        }

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdateYuvarajs([FromRoute]Guid id, UpdateYuvarajRequest updateYuvarajRequest)
        {
            var yuvaraj = await dbContext.Yuvarajs.FindAsync(id);

            if(yuvaraj != null)
            {
                yuvaraj.FullName = updateYuvarajRequest.FullName;
                yuvaraj.Address = updateYuvarajRequest.Address;
                yuvaraj.Phone = updateYuvarajRequest.Phone;
                yuvaraj.Email = updateYuvarajRequest.Email;

                await dbContext.SaveChangesAsync();
        

                return Ok(yuvaraj);

            }

            return NotFound();

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteYuvaraj([FromRoute] Guid id)
        {
            var yuvaraj = await dbContext.Yuvarajs.FindAsync(id);

            if(yuvaraj != null)
            {
                dbContext.Remove(yuvaraj);
                await dbContext.SaveChangesAsync();
                return Ok(yuvaraj);
            }

            return NotFound();
        }

    }
}
