using BMS.Core.Common;
using Microsoft.AspNetCore.Mvc;
using StatusCodes = BMS.Domain.Constants.StatusCodes;

namespace BMS.API.Controllers
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        internal ObjectResult GetResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                switch (result.StatusCode)
                {
                    case StatusCodes.StandardSuccessCode:
                        return Ok(result.Value);
                    default:
                        return Ok(result.Value);
                }
            }
            else
            {
                var errModel = new ErrorModel
                {
                    Code = result.StatusCode,
                    Message = result.ErrorMessage,
                    IsErrorOrEcxception = false
                };

                switch (result.StatusCode)
                {
                    default:
                        return new BadRequestObjectResult(errModel);
                }
            }
        }
    }
}
