using BlueBank.System.Application.Commands.Interfaces;
using BlueBank.System.Application.Queries.Interfaces;
using BlueBank.System.Application.Requests;
using BlueBank.System.Domain.OrderManagement.Entities;
using Microsoft.AspNetCore.Mvc;
using System;


namespace BlueBank.System.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {       
        [HttpGet]
        public IActionResult Get([FromServices] IGetAllAccountQuery query)
        {
            return Ok(query.Handle(new GetAllAccountRequest()));
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById([FromServices] IGetAccountByIdQuery query, [FromRoute] Guid id)
        {
            var response = query.Handle(new GetAccountByIdRequest(id));
            return Ok(response);
        }
        
        [HttpPost]
        public IActionResult Add([FromServices] IAddAccountCommand command, [FromBody] AddAccountRequest request)    
        {
            return Created("", command.Handle(request));
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromServices] IRemoveAccountByIdCommand command, [FromRoute] Guid id)
        {            
            return Ok(command.Handle(new RemoveAccountByIdRequest(id)));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromServices] IUpdateAccountCommand command, [FromRoute] Guid id, [FromBody] UpdateAccountRequest request)
        {
            request.Id = id;
            try
            {
                return Ok(command.Handle(request));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        
        [HttpPatch]
        [Route("{id}")]
        public IActionResult ChangeStatus([FromServices] IChangeStatusCommand<Account> command, [FromRoute] Guid id, [FromBody] ChangeStatusRequest request)
        {
            request.Id = id;
            return Ok(command.Handle(request));
        }

        [HttpPost]
        [Route("operation")]
        public IActionResult Add([FromServices] IAddOperationCommand command, [FromBody] AddOperationRequest request)
        {            
            try
            {
                return Created("", command.Handle(request));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
            
        }

        [HttpGet]
        [Route("operation")]
        public IActionResult Get([FromServices] IGetAllOperationQuery query)
        {
            return Ok(query.Handle(new GetAllOperationRequest()));
        }
    }
}
