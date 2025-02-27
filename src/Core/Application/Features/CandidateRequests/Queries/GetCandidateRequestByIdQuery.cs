using Domain.Entitites.CandidateRequests;
using MediatR;

namespace Application.Features.CandidateRequests.Queries
{
    public record GetCandidateRequestByIdQuery(Guid id) : IRequest<CandidateRequest>;
}
