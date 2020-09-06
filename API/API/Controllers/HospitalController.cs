using API.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class HospitalController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public HospitalController(TRepository repository) => this.repository = repository;

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get() => await repository.GetAllAsync().ConfigureAwait(false);

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(long id)
        {
            var movie = await repository.GetAsync(id).ConfigureAwait(false);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            await repository.UpdateAsync(entity).ConfigureAwait(false);

            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            await repository.AddAsync(entity).ConfigureAwait(false);

            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(long id)
        {
            var account = await repository.DeleteAsync(id).ConfigureAwait(false);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }
    }
}
