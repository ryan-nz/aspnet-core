using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdventureWorksAPI.Core.DataLayer;

namespace AdventureWorksAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Production")]
    public class ProductionController : Controller
    {
        private IAdventureWorksRepository AdventureWorksRepository;

        public ProductionController(IAdventureWorksRepository repository)
        {
            AdventureWorksRepository = repository;
        }

        protected override void Dispose(Boolean disposing)
        {
            AdventureWorksRepository?.Dispose();

            base.Dispose(disposing);
        }

        // GET: api/Production
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Production/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Production
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Production/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
