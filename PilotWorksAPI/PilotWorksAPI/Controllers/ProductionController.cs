using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PilotWorksAPI.Core.DataLayer;
using PilotWorksAPI.Responses;
using PilotWorksAPI.ViewModels;
using PilotWorksAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using PilotWorksAPI.Core.EntityLayer;

namespace PilotWorksAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductionController : Controller
    {
        private IPilotWorksRepository AdventureWorksRepository;

        public ProductionController(IPilotWorksRepository repository)
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

        // GET Production/Product/5
        /// <summary>
        /// Retrieves a specific product by id
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Single response</returns>
        [HttpGet]
        [Route("Product/{id}")]
        public async Task<IActionResult> GetProductAsync(Int32 id)
        {
            var response = new SingleModelResponse<ProductViewModel>();

            try
            {
                var entity = await AdventureWorksRepository.GetProductAsync(new Product { ProductID = id });

                response.Model = entity?.ToViewModel();
            }
            catch (Exception ex)
            {
                response.HadError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
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
