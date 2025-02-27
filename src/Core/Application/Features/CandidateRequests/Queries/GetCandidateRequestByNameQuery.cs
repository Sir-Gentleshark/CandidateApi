using Domain.Entitites.CandidateRequests;
using MediatR;

namespace Application.Features.CandidateRequests.Queries
{
    public record GetCandidateRequestByNameQuery(string name) : IRequest<CandidateRequest>;
    
}
