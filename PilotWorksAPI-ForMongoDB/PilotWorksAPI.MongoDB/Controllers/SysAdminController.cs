using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PilotWorksAPI.Core.DataLayer;
using PilotWorksAPI.MongoDB.Responses;
using PilotWorksAPI.Core.DataEntity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PilotWorksAPI.MongoDB.Controllers
{
    [Route("api/[controller]")]
    public class SysAdminController : Controller
    {
        private IPilotWorksRepository _pilotWorksRepository;

        public SysAdminController(IPilotWorksRepository repository)
        {
            _pilotWorksRepository = repository;
        }

        /// <summary>
        /// GET: api/sysadmin/parameter
        /// Call for an initialization if parameter is equal to "init".
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        [HttpGet("{setting}")]
        public IActionResult Get(string setting)
        {
            var response = new SingleModelResponse<string>();

            try
            {
                if (setting == "init")
                {
                    _pilotWorksRepository.DeleteAllProductsAsync();
                    _pilotWorksRepository.AddProductAsync(new Core.DataEntity.Product()
                    {
                        ProductName = "Product 01",
                        ProductNumber = "PP-0001",
                        Price = 10.99
                    });
                    _pilotWorksRepository.AddProductAsync(new Core.DataEntity.Product()
                    {
                        ProductName = "Product 02",
                        ProductNumber = "PP-0002",
                        Price = 20.99
                    });
                    _pilotWorksRepository.AddProductAsync(new Core.DataEntity.Product()
                    {
                        ProductName = "Product 03",
                        ProductNumber = "PP-0003",
                        Price = 30.99
                    });
                    _pilotWorksRepository.AddProductAsync(new Core.DataEntity.Product()
                    {
                        ProductName = "Product 04",
                        ProductNumber = "PP-0004",
                        Price = 40.99
                    });

                    response.Model = "PP-0001/PP-0002/PP-0003/PP-0004";
                    response.Message = "The initialisation was DONE.";
                }
                else
                {
                    response.HadError = true;
                    response.Message = "FAILED for parameter";
                    response.ErrorMessage = "Cannot initialise!";
                }

            }
            catch (Exception ex)
            {
                response.HadError = true;
                response.Message = "The initialisation was unsuccessfully";
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }
    }
}
