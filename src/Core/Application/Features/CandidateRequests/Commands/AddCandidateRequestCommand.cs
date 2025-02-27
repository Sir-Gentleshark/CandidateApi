using Domain.Entitites.CandidateRequests;
using MediatR;

namespace Application.Features.CandidateRequests.Commands
{
    public record AddCandidateRequestCommand(CandidateRequest category) : IRequest<CandidateRequest>;
}
