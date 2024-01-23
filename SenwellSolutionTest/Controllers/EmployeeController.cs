using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenwellSolutionTest.Model;
using SenwellSolutionTest.Repository.Interface;

namespace SenwellSolutionTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeAsyncRepository employeeAsync;
        public EmployeeController(IEmployeeAsyncRepository employeeAsync)
        {
            this.employeeAsync = employeeAsync;
        }
        [HttpPost("RegisterEmployee")]
        public async Task<IActionResult> RegisterNewEmployee(Employee employee)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
              var result=await employeeAsync.RegisterEmployee(employee);
                if(result>0)
                {
                    baseResponse.StatusMessage = $"Employee registered successfully...!";
                    baseResponse.StatusCode = StatusCodes.Status200OK;
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);
                }
                else
                {
                    baseResponse.StatusMessage = $"Something is wrong...!";
                    baseResponse.StatusCode= StatusCodes.Status409Conflict;
                    return Ok(baseResponse);
                }
            }
            catch (Exception ex)
            {
                baseResponse.StatusMessage=ex.Message;
                baseResponse.StatusCode = StatusCodes.Status400BadRequest;
                return Ok(baseResponse);
            }
        }
        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployee()
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                var result = await employeeAsync.GetEmployees();
                if (result.Count() > 0)
                {
                    baseResponse.StatusMessage = $"Employee records fetch successfully...!";
                    baseResponse.StatusCode = StatusCodes.Status200OK;
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);
                }
                else
                {
                    baseResponse.StatusMessage = $"There is no any record...!";
                    baseResponse.StatusCode = StatusCodes.Status409Conflict;
                    return Ok(baseResponse);
                }
            }
            catch (Exception ex)
            {
                baseResponse.StatusMessage = ex.Message;
                baseResponse.StatusCode = StatusCodes.Status400BadRequest;
                return Ok(baseResponse);
            }
        }
    }
}
