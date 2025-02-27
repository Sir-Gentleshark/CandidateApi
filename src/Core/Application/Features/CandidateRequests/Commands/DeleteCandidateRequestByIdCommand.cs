using MediatR;

namespace Application.Features.CandidateRequests.Commands
{
    public record DeleteCandidateRequestByIdCommand(Guid id) : IRequest;
}
