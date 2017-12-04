using Microsoft.AspNetCore.Mvc;
using PilotWorksAPI.Core.DataLayer;
using PilotWorksAPI.Responses;
using System;
using System.Collections.Generic;

namespace PilotWorksAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductionController : Controller
    {
        private readonly IPilotWorksRepository _pilotWorksRepository;

        public ProductionController(IPilotWorksRepository repository)
        {
            _pilotWorksRepository = repository;
        }

        // GET Production
        /// <summary>
        /// Retrieves a list of pairs with key:value
        /// </summary>
        /// <returns>List response</returns>
        [HttpGet]
        public IActionResult GetProducts()
        {
            var response = new ListModelResponse<KeyValuePair<string, string>>();

            try
            {
                IList<KeyValuePair<string, string>> allProducts = _pilotWorksRepository.GetAllProducts();
                response.Model = _pilotWorksRepository.GetAllProducts();
                response.Message = String.Format("Total of records: {0}", allProducts.Count);
            }
            catch (Exception ex)
            {
                response.HadError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        //GET Production/Product/{key}
        // <summary>
        // Retrieves a specific product by key
        // </summary>
        // <param name = "key" >Key ID</param>
        // <returns>Single response</returns>
        [HttpGet]
        [Route("Product/{key}")]
        public IActionResult GetProduct(string key)
        {
            var response = new SingleModelResponse<KeyValuePair<string, string>>();

            try
            {
                KeyValuePair<string, string> pair = _pilotWorksRepository.GetProduct(key);
                response.Model = pair;
                if (pair.Value != null)
                {
                    response.Message = "The record was obtained successfully.";
                }
                else
                {
                    response.HadError = true;
                    response.Message = "Failed";
                    response.Message = "The record was obtained unsuccessfully!";
                }
            }
            catch (Exception ex)
            {
                response.HadError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        // POST: api/Production/Product
        [HttpPost]
        [Route("Product")]
        public IActionResult Post(string key, string value)
        {
            var response = new SingleModelResponse<KeyValuePair<string, string>>();
            try
            {
                bool successs = _pilotWorksRepository.AddProduct(key, value);
                response.Model = new KeyValuePair<string, string>(key, value);
                if (successs)
                {
                    response.Message = "The record was added successfully.";
                }
                else
                {
                    response.HadError = true;
                    response.Message = "Failed";
                    response.ErrorMessage = "The record was added unsuccessfully!";
                }
            }
            catch (Exception ex)
            {
                response.HadError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        // PUT: api/Production/5
        [HttpPut("{id}")]
        public IActionResult Put(string key, string value)
        {
            var response = new SingleModelResponse<KeyValuePair<string, string>>();

            try
            {
                bool successs = _pilotWorksRepository.UpdateProduct(key, value);
                response.Model = new KeyValuePair<string, string>(key, value);

                if (successs)
                {
                    response.Message = "The record was updated successfully.";
                }
                else
                {
                    response.HadError = true;
                    response.Message = "Failed";
                    response.ErrorMessage = "The record was updated unsuccessfully!";
                }
            }
            catch (Exception ex)
            {
                response.HadError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("Product/{key}")]
        public IActionResult Delete(string key)
        {
            var response = new SingleModelResponse<KeyValuePair<string, string>>();

            try
            {
                bool successs = _pilotWorksRepository.DeleteProduct(key);
                response.Model = new KeyValuePair<string, string>(key, null);

                if (successs)
                {
                    response.Message = "The record was deleted successfully.";
                }
                else
                {
                    response.HadError = true;
                    response.Message = "Failed";
                    response.ErrorMessage = "The record was updated unsuccessfully!";
                }
            }
            catch (Exception ex)
            {
                response.HadError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }
    }
}