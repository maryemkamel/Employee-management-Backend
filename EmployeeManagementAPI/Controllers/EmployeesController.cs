using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagementAPI.Commands;
using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Queries;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EmployeesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var query = new GetAllEmployeesQuery();
            var employees = await _mediator.Send(query);
            var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(Guid id)
        {
            var query = new GetEmployeeQuery { Id = id };
            var employee = await _mediator.Send(query);

            if (employee == null)
            {
                return NotFound();
            }

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, UpdateEmployeeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> PostEmployee(CreateEmployeeCommand command)
        {
            var employee = await _mediator.Send(command);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employeeDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var command = new DeleteEmployeeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}