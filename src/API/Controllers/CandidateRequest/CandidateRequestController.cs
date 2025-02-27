using Application.Features.CandidateRequests.Commands;
using Application.Features.CandidateRequests.Queries;
using AutoMapper;
using Domain.Entitites.CandidateRequests;
using DTO.CandidateRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.CandidateRequests
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CandidateRequestController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllRequests(CancellationToken ct)
        { 
            var requests = await _mediator.Send(new GetAllCandidateRequestsQuery(), ct);
            return Ok(requests);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetRequestById(Guid id, CancellationToken ct)
        { 
            var request = await _mediator.Send(new GetCandidateRequestByIdQuery(id), ct);
            return Ok(request);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddRequest([FromBody] AddRequestDto requestToAdd, CancellationToken ct)
        { 
            // Map the DTO to a domain model
            CandidateRequest mappedRequestToAdd = _mapper.Map<CandidateRequest>(requestToAdd);

            // Add the request to the application database
            CandidateRequest addedRequest = await _mediator.Send(new AddCandidateRequestCommand(mappedRequestToAdd), ct);

            // Map created request to response DTO
            CandidateRequestResponseDto mappedRequestToReturn = _mapper.Map<CandidateRequestResponseDto>(addedRequest);

            // Return the mapped request
            return Ok(mappedRequestToReturn);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateRequest([FromBody] UpdateRequestDto requestToUpdate, CancellationToken ct)
        {
            // Map the DTO to a domain model
            CandidateRequest mappedRequestToUpdate = _mapper.Map<CandidateRequest>(requestToUpdate);

            // Update the request in the application database
            CandidateRequest updatedRequest = await _mediator.Send(new UpdateCandidateRequestCommand(mappedRequestToUpdate), ct);

            // Map updated request to response DTO
            CandidateRequestResponseDto mappedRequestToReturn = _mapper.Map<CandidateRequestResponseDto>(updatedRequest);

            // Return the mapped request
            return Ok(mappedRequestToReturn);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteRequest(Guid id, CancellationToken ct)
        { 
            // Delete the request from the application database
            await _mediator.Send(new DeleteCandidateRequestByIdCommand(id), ct);

            // Return a success message
            return Ok("Request deleted successfully");
        }
    }
}
