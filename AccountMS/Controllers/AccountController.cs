using AccountMS.Application.Commands;
using AccountMS.Application.Queries;
using AccountMS.Commons.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMediator _mediator;

        public AccountController(ILogger<AccountController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountDto createAccountDto)
        {
            try
            {
                var command = new CreateAccountCommand(createAccountDto);
                var accountId = await _mediator.Send(command);
                return Ok(accountId);
            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred while trying to create an account {Message}", e.Message);
                return StatusCode(500, "An error occurred while trying to create an account");
            }
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAccount(Guid accountId)
        {
            try
            {
                var query = new GetAccountQuery(accountId);
                var account = await _mediator.Send(query);
                return Ok(account);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while getting account {Message}", e.Message);
                return StatusCode(500, "An error occurred while getting account.");
            }
        }
    }
}

