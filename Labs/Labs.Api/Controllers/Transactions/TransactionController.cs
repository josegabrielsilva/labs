using Labs.Api.Common;
using Labs.Application.UseCases.Transactions;
using Labs.Application.UseCases.Transactions.GetByPeriod;
using Labs.Infrastructure.Contracts.Api.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Labs.Api.Controllers.Transactions
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator Mediator;
        public TransactionController(IMediator mediator) => Mediator = mediator;

        [HttpGet("GetById/{transactionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Description = "Obter uma transação pelo Guid informado na rota")]
        public async Task<ActionResult<GetTransactionResponse>> GetById(
            [FromRoute][Required] Guid transactionId, 
            CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetByIdQuery(transactionId), cancellationToken);

            if (!response.ProcessedWithSuccess)
                return StatusCode((int)HttpStatusCode.InternalServerError, CommonMessages.INTERNAL_SERVER_ERROR_DEFAULT_MESSAGE);

            return response.Data != null
                ? Ok(response.Data.ToApiResponseContract())
                : NotFound();
        }

        [HttpGet("GetByPeriod/{initialDate}/{finalDate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Description = "Obter transações por período")]
        public async Task<ActionResult<GetTransactionResponse>> GetByPeriod(
            [FromRoute][Required] DateTime initialDate, 
            [FromRoute][Required] DateTime finalDate,
            CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetByPeriodQuery(initialDate, finalDate), cancellationToken);

            if (!response.ProcessedWithSuccess)
                return StatusCode((int)HttpStatusCode.InternalServerError, CommonMessages.INTERNAL_SERVER_ERROR_DEFAULT_MESSAGE);

            return response.Data != null
                ? Ok(response.Data.ToApiResponseContract())
                : NotFound();
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Description = "Criar uma transação com base nos dados enviados no body da requisição")]
        public async Task<IActionResult> Create(
            [FromBody][Required] CreateTransactionCommand command, 
            CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(command, cancellationToken);

            if (!response.ProcessedWithSuccess)
                return StatusCode((int)HttpStatusCode.InternalServerError, CommonMessages.INTERNAL_SERVER_ERROR_DEFAULT_MESSAGE);

            return response.ValidationMessages.Any() 
                ? UnprocessableEntity(response.ValidationMessages)
                : CreatedAtAction("GetByTransactionId", new { transactionId = response.Data }, command);
        }
    }
}
