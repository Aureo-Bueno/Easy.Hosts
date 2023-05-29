﻿using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.OrderService;
using Easy.Hosts.Core.Events;
using Easy.Hosts.Core.Persistence.Context;
using Easy.Hosts.Core.Repositories.Interface;
using Easy.Hosts.Core.Validators.OrderService;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.Hosts.Controllers
{
    [Route("api/easyhosts/[controller]")]
    [ApiController]
    public class OrderServiceController : ControllerBase
    {
        private readonly ILogger<OrderServiceController> _logger;
        private readonly IOrderServiceRepository _orderServiceRepository;
        public OrderServiceController(ILogger<OrderServiceController> logger, IOrderServiceRepository orderServiceRepository)
        {
            _logger = logger;
            _orderServiceRepository = orderServiceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<OrderServiceReadDto> result = await _orderServiceRepository.FindAllAsync();
            _logger.LogInformation(MyLogEvents.GetItem, "Get all Order Services");
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            OrderServiceReadDto result = await _orderServiceRepository.GetByIdAsync(id);
            _logger.LogInformation(MyLogEvents.GetItem, $"Get Oder Service, Id: {id}");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] OrderServiceCreateDto orderServiceCreateDto)
        {
            OrderServiceCreateDtoValidator validator = new();

            ValidationResult validate = await validator.ValidateAsync(orderServiceCreateDto);

            if (validate.IsValid)
            {
                OrderServiceReadDto result = await _orderServiceRepository.InsertAsync(orderServiceCreateDto);
                _logger.LogInformation(MyLogEvents.InsertItem, $"Insert Order Service, Description {result.Description}");
                return Ok(result);
            }

            return BadRequest(validate.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, OrderServiceUpdateDto orderServiceUpdateDto)
        {
            OrderServiceUpdateDtoValidator validator = new();
            ValidationResult validate = await validator.ValidateAsync(orderServiceUpdateDto);

            if (validate.IsValid) 
            {
                OrderServiceReadDto result = await _orderServiceRepository.UpdateAsync(id, orderServiceUpdateDto);
                _logger.LogInformation(MyLogEvents.UpdateItem, $"Update Order Service, Id: {id}.");
                return Ok(result);
            }
            
            return BadRequest(validate.Errors);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _orderServiceRepository.DeleteAsync(id);
            return Ok();
        }
    }
}