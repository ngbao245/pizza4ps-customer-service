using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.CustomerService.API.Constants;
using Pizza4Ps.CustomerService.API.Models;
using Pizza4Ps.CustomerService.Application.DTOs.Districts;
using Pizza4Ps.CustomerService.Application.UserCases.V1.Districts.Queries.GetDistrictById;
using Pizza4Ps.CustomerService.Application.UserCases.V1.Districts.Queries.GetListDistrict;
using Pizza4Ps.CustomerService.Application.UserCases.V1.Districts.Queries.GetListDistrictIgnoreQueryFilter;

namespace Pizza4Ps.CustomerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public DistrictsController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpGet("ignore-filter")]
        public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListDistrictIgnoreQueryFilterQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListDistrictQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleByIdAsync([FromRoute] Guid id)
        {
            var result = await _sender.Send(new GetDistrictByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
