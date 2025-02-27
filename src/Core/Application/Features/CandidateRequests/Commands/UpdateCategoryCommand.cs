using Domain.Entitites.CandidateRequests;
using MediatR;

namespace Application.Features.CandidateRequests.Commands
{
    public record UpdateCandidateRequestCommand(CandidateRequest candidateRequest) : IRequest<CandidateRequest>;
}
