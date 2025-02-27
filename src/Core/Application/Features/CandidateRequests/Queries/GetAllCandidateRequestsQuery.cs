using Domain.Entitites.CandidateRequests;
using MediatR;

namespace Application.Features.CandidateRequests.Queries
{
    public record GetAllCandidateRequestsQuery : IRequest<List<CandidateRequest>>;
}
