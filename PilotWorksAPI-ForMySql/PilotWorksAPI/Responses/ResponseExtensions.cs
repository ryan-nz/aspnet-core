using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PilotWorksAPI.Responses
{
    public static class ResponseExtensions
    {
        public static IActionResult ToHttpResponse<TModel>(this IListModelResponse<TModel> response)
        {
            HttpStatusCode status = HttpStatusCode.OK;

            if (response.HadError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.Model == null)
            {
                status = HttpStatusCode.NoContent;
            }

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this ISingleModelResponse<TModel> response)
        {
            HttpStatusCode status = HttpStatusCode.OK;

            if (response.HadError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.Model == null)
            {
                status = HttpStatusCode.NotFound;
            }

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }
    }
}
