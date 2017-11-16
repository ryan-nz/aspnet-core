using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdventureWorksAPI.Core.DataLayer;
using AdventureWorksAPI.Responses;
using AdventureWorksAPI.ViewModels;
using AdventureWorksAPI.Extensions;
using Microsoft.EntityFrameworkCore;

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

        // GET Production/Product
        /// <summary>
        /// Retrieves a list of products
        /// </summary>
        /// <param name="pageSize">Page size</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="name">Name</param>
        /// <returns>List response</returns>
        [HttpGet]
        [Route("Product")]
        public async Task<IActionResult> GetProductsAsync(Int32? pageSize = 10, Int32? pageNumber = 1, String name = null)
        {
            var response = new ListModelResponse<ProductViewModel>();

            try
            {
                response.PageSize = (Int32)pageSize;
                response.PageNumber = (Int32)pageNumber;

                response.Model = await AdventureWorksRepository
                        .GetProducts(response.PageSize, response.PageNumber, name)
                        .Select(item => item.ToViewModel())
                        .ToListAsync();

                response.Message = String.Format("Total of records: {0}", response.Model.Count());
            }
            catch (Exception ex)
            {
                response.HadError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
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
