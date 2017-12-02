using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PilotWorksAPI.Core.DataLayer;
using PilotWorksAPI.MongoDB.Responses;
using PilotWorksAPI.Core.DataEntity;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PilotWorksAPI.MongoDB.Controllers
{
    [Route("api/[controller]")]
    public class ProductionController : Controller
    {
        private IPilotWorksRepository _pilotWorksRepository;

        public ProductionController(IPilotWorksRepository repository)
        {
            _pilotWorksRepository = repository;
        }

        // GET: api/production
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var response = new ListModelResponse<Product>();

            try
            {
                response.Model = await _pilotWorksRepository.GetAllProductsAsync();

                response.Message = String.Format("Total of records: {0}", response.Model.Count());
            }
            catch (Exception ex)
            {
                response.HadError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        // GET api/production/productnumber
        [HttpGet("Product/{number}")]
        public async Task<IActionResult> Get(string number)
        {
            var response = new SingleModelResponse<Product>();

            try
            {
                response.Model = await _pilotWorksRepository.GetProductAsync(number);
                response.Message = "The record was obtained successfully";
            }
            catch (Exception ex)
            {
                response.HadError = true;
                response.Message = "The record was obtained unsuccessfully";
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        // POST api/production
        [HttpPost]
        public IActionResult Post([FromBody]Product value)
        {
            var response = new SingleModelResponse<Product>();

            try
            {
                _pilotWorksRepository.AddProductAsync(value);

                response.Model = value;
                response.Message = "The record was added successfully";
            }
            catch (Exception ex)
            {
                response.HadError = true;
                response.Message = "The record was added unsuccessfully";
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        // PUT api/production
        [HttpPut]
        public IActionResult Put([FromBody]Product value)
        {
            var response = new SingleModelResponse<Product>();

            try
            {
                _pilotWorksRepository.UpdateProductAsync(value);

                response.Model = value;
                response.Message = "The record was updated successfully";
            }
            catch (Exception ex)
            {
                response.HadError = true;
                response.Message = "The record was updated unsuccessfully";
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        // DELETE api/production/productnumber
        [HttpDelete("{number}")]
        public IActionResult Delete(string number)
        {
            var response = new SingleModelResponse<string>();

            try
            {
                _pilotWorksRepository.DeleteProductAsync(number);

                response.Model = number;
                response.Message = "The record was deleted successfully";
            }
            catch (Exception ex)
            {
                response.HadError = true;
                response.Message = "The record was deleted unsuccessfully";
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }
    }
}
