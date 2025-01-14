using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.CustomerService.API.Constants;
using Pizza4Ps.CustomerService.API.Models;
using Pizza4Ps.CustomerService.Application.DTOs.Points;
using Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Commands.CreatePoint;
using Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Commands.DeletePoint;
using Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Commands.RestorePoint;
using Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Commands.UpdatePoint;
using Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetListPoint;
using Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetListPointIgnoreQueryFilter;
using Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetPointById;

namespace Pizza4Ps.CustomerService.API.Controllers
{
    [Route("api/points")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public PointsController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePointDto request)
        {
            var result = await _sender.Send(new CreatePointCommand { CreatePointDto = request });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpGet("ignore-filter")]
        public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListPointIgnoreQueryFilterDto query)
        {
            var result = await _sender.Send(new GetListPointIgnoreQueryFilterQuery { GetListPointIgnoreQueryFilterDto = query });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListPointDto query)
        {
            var result = await _sender.Send(new GetListPointQuery { GetListPointDto = query });
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
            var result = await _sender.Send(new GetPointByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdatePointDto request)
        {
            var result = await _sender.Send(new UpdatePointCommand { Id = id, UpdatePointDto = request });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("restore")]
        public async Task<IActionResult> RestoreManyAsync(List<Guid> ids)
        {
            await _sender.Send(new RestorePointCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
        {
            await _sender.Send(new DeletePointCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}