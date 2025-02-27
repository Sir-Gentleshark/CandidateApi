using Application.Features.CandidateRequests.Queries;
using Application.Services.CandidateRequests;
using Domain.Entitites.CandidateRequests;
using MediatR;

namespace Application.Features.Categories.Handlers.Read
{
    public class GetAllRequestsHandler : IRequestHandler<GetAllCandidateRequestsQuery, List<CandidateRequest>>
    {
        private readonly ICandidateRequestService _requestService;

        public GetAllRequestsHandler(ICandidateRequestService candidateRequests)
        {
            _requestService = candidateRequests;
        }

        public async Task<List<CandidateRequest>> Handle(GetAllCandidateRequestsQuery request, CancellationToken cancellationToken)
        {
            return await _requestService.GetRequestsAsync(cancellationToken);
        }
    }
}
