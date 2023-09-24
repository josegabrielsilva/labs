using Labs.Api.Common;
using Labs.Application.UseCases.Transactions;
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

        [HttpGet("{transactionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Obter por ID", Description = "Obter uma transação pelo Guid informado na rota")]
        public async Task<ActionResult<GetByTransactionIdResponse>> GetByTransactionId(
            [FromRoute][Required] Guid transactionId, 
            CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetByIdCommand(transactionId), cancellationToken);

            if (!response.ProcessedWithSuccess)
                return StatusCode((int)HttpStatusCode.InternalServerError, CommonMessages.INTERNAL_SERVER_ERROR_DEFAULT_MESSAGE);

            return response.Data != null
                ? Ok(response.Data.ToApiResponseContract())
                : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Criar transação", Description = "Criar uma transação com base nos dados enviados no body da requisição")]
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
