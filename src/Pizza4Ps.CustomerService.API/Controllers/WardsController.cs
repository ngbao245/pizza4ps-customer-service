﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.CustomerService.API.Constants;
using Pizza4Ps.CustomerService.API.Models;
using Pizza4Ps.CustomerService.Application.UserCases.V1.Wards.Queries.GetListWard;
using Pizza4Ps.CustomerService.Application.UserCases.V1.Wards.Queries.GetListWardIgnoreQueryFilter;
using Pizza4Ps.CustomerService.Application.UserCases.V1.Wards.Queries.GetWardById;

namespace Pizza4Ps.CustomerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public WardsController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpGet("ignore-filter")]
        public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListWardIgnoreQueryFilterQuery query)
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
        public async Task<IActionResult> GetListAsync([FromQuery] GetListWardQuery query)
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
            var result = await _sender.Send(new GetWardByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
